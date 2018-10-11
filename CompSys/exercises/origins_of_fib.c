#include <stdlib.h>
#include <stdio.h>
#include <string.h>

int main (int argc, char *argv[]) {
  if (argc == 2) {
    int fib();
    fib(atoi(argv[1]));
    //printf("%d", fib(atoi(argv[1])));
    return EXIT_SUCCESS;
  } else {
    printf("Usage: ./origins_of_fib num\n");
    return EXIT_FAILURE;
  }
}

int fib (int input) {

  int retVal;
  
  switch (input) {
    
  case 1 :
  case 2 :
    retVal = 1;
    printf("Input:          %d\n", input);
    printf("Output:         %d\n", retVal);
    printf("Return address: %p\n", __builtin_return_address(0));
    return retVal;
  default :
    retVal = fib(input-1) + fib(input-2);
    printf("Input:          %d\n", input);
    printf("Output:         %d\n", retVal);
    printf("Return address: %p\n", __builtin_return_address(0));
    return retVal;
  }
}
