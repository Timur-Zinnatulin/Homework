import pretty_print
import settings as s

def main():
    pretty_print.print_title()
    sec = pretty_print.print_separation(s.A, s.B)

    for section in sec:
        print("=" * 50)
        print('Отрезок: [', round(section[0], 6), '; ', round(section[1], 6), ']')
        print("=" * 50)
        pretty_print.print_methods(section)

if __name__ == '__main__':
    main()