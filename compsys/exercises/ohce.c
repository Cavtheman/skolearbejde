#include <stdlib.h>
#include <stdio.h>
#include <string.h>

int main (int argc, char *argv[]) {
  if (argc == 2) {
    int length = strlen(argv[1]);

    char retVal[length+1];

    retVal[length] = '\0';
    int count = 0;
    for (int i = length-1; i >= 0; i--) {
      retVal[count] = (*argv[1])+i*sizeof(char);
      //printf("%c\n", retVal[count]);
      count++;
    }
    
    printf("%s\n", retVal);
    return EXIT_SUCCESS;
  } else {
    printf("Usage: ./ohce arg\n");
    return EXIT_FAILURE;
  }
}
