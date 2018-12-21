#include <stdio.h>

int sign(int a)
{
    return a >= 0 ? 1 : -1;
}

int main()
{
    int a, b;
    scanf("%d %d", &a, &b);
    if (b == 0)
    {
        printf("NO ANSWER");
        return 0;
    }
    int moda = sign(a);
    int modb = sign(b);
    a *= moda;
    b *= modb;
    int x = 1;
    if (a == 0)
    {
        printf("%d", a);
        return 0;
    }
    while(a > (x + 1) * b)
    {
        x++;
    }
    if (a == (x + 1) * b){
        printf("%d", x + 1);
        return 0;
    }
    if (moda < 0)
        x++;
    if (moda * modb < 0)
        x *= -1;
    printf("%d", x);
    return 0;
}
