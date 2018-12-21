#include <iostream>

using namespace std;

bool prime(int n)
{
    if (n < 4)
        return true;
    for(int i = 2 ; i <= n / 2 + 1 ; i++)
        if (n % i == 0)
            return false;
    return true;
}

int num;

int main()
{
    scanf("%d", &num);
    for (int i = 2 ; i <= num ; i++)
        if (prime(i))
            printf("%d ", i);
    return 0;
}
