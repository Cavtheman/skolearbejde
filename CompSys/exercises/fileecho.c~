#include <stdlib.h>
#include <stdio.h>

int main (int argc, char* argv[]) {
  FILE * filep;

  int n;
  
  if (argc == 2) {
    filep = fopen(argv[1], "r");
    if (filep == NULL) {
      printf("File not found\n");
      return EXIT_FAILURE;
    } else {
      while(!feof(filep)) {
        n = fgetc(filep);
        printf("%c", n);
      }
    }
  }
  fclose(filep);
}
