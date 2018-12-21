#include <iostream>
#include <string.h>

using namespace std;

char brackets[1000];
int ctr = 0;
bool flag = true;

int main()
{
    scanf("%s", brackets);
    for(int i = 0 ; i < strlen(brackets); i++)
    {
        if(brackets[i] == '(')
            ctr++;
        else
            ctr--;
        if(ctr < 0)
            flag = false;
    }
    if(ctr == 0 && flag)
        printf("Correct\n");
    else
        printf("Incorrect\n");
    return 0;
}
