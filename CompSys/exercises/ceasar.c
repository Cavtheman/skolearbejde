#include <stdlib.h>
#include <stdio.h>

int main (int argc, char* argv[]) {
  FILE * filep;
  
  if (argc == 2) {
    As = 0;
      filep = fopen(argv[1], "r");
    
    if (filep == NULL) {
      printf("File not Found\n");
      return EXIT_FAILURE;
    } else {
      while(!feof(filep)) {
        if (fgetc(filep) == 'A') {
          As++;
        }
      }
    }
  }
}
