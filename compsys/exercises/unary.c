#include <stdlib.h>
#include <stdio.h>

int main (int argc, char* argv[]) {
  if (argc == 2) {
    printf(argv[1]);
    return EXIT_SUCCESS;
  } else {
    fprintf(stderr, "Usage: unary arg\n");
    return EXIT_FAILURE;
  }
}
