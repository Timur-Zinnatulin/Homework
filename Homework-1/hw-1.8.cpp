#include <iostream>

using namespace std;

int arr[1000];
int ans;

int main()
{
    int n = 0;
    while (arr[n - 1] != (-1))
    //�.�. � ������ �� ������� ���������� ��������� � �������, ����� ����� ���� �� -1
    {
        scanf("%d", &arr[n]);
        if (arr[n] == 0)
            ans++;
        n++;
    }
    printf("%d", ans);
    return 0;
}
