#include <stdio.h>

void shuffle(int arr[], int l, int r)
{
    for (int i = 0 ; i <= ((r - 1) / 2) ; i++)
    {
        int sub = arr[l + r - 1 - i];
        arr[l + r - 1 - i] = arr[l + i];
        arr[l + i] = sub;
    }
}

int main()
{
    int m, n;
    int arr[1000];
    scanf("%d %d", &m, &n);
    for (int i = 0  ; i < m + n ; i++)
        scanf("%d", &arr[i]);
    shuffle(arr, 0, m);                                 //��������� 1 ����������
    shuffle(arr, m, n);                                 //��������� 2 ����������
    shuffle(arr, 0, m + n);                             //��������� ����� �������
    for (int i = 0 ; i < m + n ; i++)
        printf("%d ", arr[i]);
    return 0;
}
