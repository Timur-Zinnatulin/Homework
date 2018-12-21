#include <iostream>
#include <string.h>

using namespace std;

char s[1000], s1[1000];
bool flag;
int ans = 0;

int main()
{
    scanf("%s %s", s, s1);
    for (int i = 0 ; i < strlen(s) - strlen(s1) + 1 ; i++)
    {
        if (s[i] == s1[0])
        {
            flag = true;
            for (int j = 0 ; j < strlen(s1) ; j++)
            {
                if (s[i + j] != s1[j])
                    flag = false;
            }
            if (flag)
                ans++;
        }
    }
    printf("%d", ans);
    return 0;
}
