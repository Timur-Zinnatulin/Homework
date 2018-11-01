#include <stdio.h>

const int lower = 0;
const int higher = 10;
const int minsum = 0;
const int maxsum = 27;

int main()
{
    int ans = 0;
    int sums[28];
    for (int i = lower ; i < higher ; i++)
        for(int j = lower ; j < higher ; j++)
            for(int k = lower ; k < higher ; k++)
                sums[i + j + k]++;
    for (int i = minsum ; i <= maxsum ; i++)
    {
        ans += (sums[i]) * (sums[i]);
        printf("%d %d\n", i, sums[i]);
    }
    printf("%d", ans);
    return 0;
}
