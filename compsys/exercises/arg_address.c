#include <stdlib.h>
#include <stdio.h>

int main (int argc, char *argv[]) {
  for (int i = 1; i < argc; i++){
    printf("Argument %d: %p\n", i, argv[i]);
  }
  return EXIT_SUCCESS;
}
