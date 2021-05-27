import socket
from threading import Thread
import requests


serverSocket = socket.socket()  # Create socket
localHostIp = "0.0.0.0"  # work for all ips of the server
port = 2874

# Reserve port
serverSocket.bind((localHostIp, port))

# Listen to up to 15 client connections
serverSocket.listen(15)

allThreads = set()  # Store records of all threads

buffer = 2048  # Buffer size


def handle_client_connection(client_socket, client_address):
    client_header = ""
    while True:
        data = client_socket.recv(buffer)  # Receive request from client

        try:
            client_header += data.decode("utf-8")
        except UnicodeDecodeError: #
            break

        if len(data) < buffer:
            break

    list_header = list(map(str, client_header.strip().split("\r\n")))  # Split headers

    # Handle either HTTP or HTTPS request
    if list(map(str, list_header[0].split(" ")))[0].strip() == "GET":
        handle_http_request(client_socket, list_header)
    else:
        handle_https_request(client_socket, client_header, list_header)


def handle_http_request(client_socket, list_header):
    web_request = requests.get(list(map(str, list_header[0].split(" ")))[1]) # Get 

    # 200 OK
    if web_request.status_code == 200:
        response = "HTTP/1.1 200 OK\r\nProxy-Agent: simple-proxy-server\r\n\r\n"
        client_socket.send(response.encode("utf-8"))
        client_socket.sendall(web_request.text.encode("utf-8"))
    else:
        # 404 Not Found
        response = "HTTP/1.1 404 Not Found\r\nProxy-Agent: simple-proxy-server\r\n\r\Website not Found\r\n"
        client_socket.send(response.encode("utf-8"))


def handle_https_request(client_socket, client_header, list_header):
    web_server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

    try:
        web_host = list(map(str, list_header[0].split(" ")))[1]
        web_host = list(map(str, web_host.split(":")))[0]
    except IndexError:
        print("Index error while fetching https request")
        return

    try:
        web_host_ip = socket.gethostbyname(web_host)
    except socket.gaierror:
        print("Unknown host error while fetching https request")
        return

    # 200 OK
    web_server_socket.connect((web_host_ip, 443))
    response = "HTTP/1.1 200 Connection Established\r\nProxy-Agent: simple-proxy-server\r\n\r\n"
    client_socket.send(response.encode("utf-8"))

    transfer_thread = Thread(target=client_to_server_transfer, args=(client_socket, web_server_socket))
    transfer_thread.setDaemon(True)
    transfer_thread.start()

    while True:
        server_data = web_server_socket.recv(buffer)
        client_socket.send(server_data)
        if len(server_data) < 1:
            break


def client_to_server_transfer(client_socket, web_server_socket):
    while True:
        client_data = client_socket.recv(buffer)
        web_server_socket.send(client_data)
        if len(client_data) < 1:
            break


while True:
    client_socket, client_address = serverSocket.accept()  # Connection with client

    # Create new thread for handling client requests
    print("Connection accepted from ", client_address)
 
    thread = Thread(target=handle_client_connection, args=(client_socket, client_address))
    allThreads.add(thread)  # Add thread to the list
    thread.start()