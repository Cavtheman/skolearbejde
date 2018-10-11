#include <stdlib.h>
#include <stdio.h>
#include <math.h>

int main (int argc, char* argv[]) {
  long int value = atoi(argv[1]);
  long int index = atoi(argv[2]);
  long int powind = 1;
  
  if (argc == 3) {
    
    for (int i = 0; i < index; i++) {
        powind = powind*2;
    }
    printf("%ld\n", value^powind);
    return EXIT_SUCCESS;
  } else {
    printf("Usage: ./bitflip value index");
    return EXIT_FAILURE;
  }
}
