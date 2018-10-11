#include <stdlib.h>
#include <stdio.h>

#define INVALID_CHAR 'A'

int main (int argc, char* argv[]) {
  if (argc == 2) {
    if (argv[1][0] == INVALID_CHAR) {
      printf("No beginning A's are allowed\n");
    } else {
      printf("%s\n", argv[1]);
    }
  }
}
