#include<stdio.h>
#include<string.h>

#define MAX 256

int main(void)
{
  char str1[MAX];
  char str2[MAX];

  printf("str1:");  scanf("%s",str1);
  printf("str2:");  scanf("%s",str2);

  strcat(str1,str2);
  printf("%s",str1);

  return 0;

}
