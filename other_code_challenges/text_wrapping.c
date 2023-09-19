#include <stddef.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char* word_wrap(char* str, size_t string_size, size_t line_size){
    char* r = malloc(sizeof(char) * string_size);
    r = memcpy(r, str, sizeof(char) * string_size);

    size_t last_space = 0;
    size_t cur_len = 0;
    for (size_t i = 0; i < string_size; i++) {
       if (str[i] == ' ') {
           last_space = i;
       }
       cur_len++;
       if (cur_len > line_size && last_space != 0) {
           r[last_space] = '\n';
           cur_len = 0;
       }
    }
    return r;
}

int main() {
    char original[] = "The imposter is among us, he is unescapable, unstoppable and immortal sussyi estji kdosap among us ssy baaka lsd;";
    char* wrapped = word_wrap(original, 114, 45);
    printf("%s\n", original);
    printf("%s\n", wrapped);
    free(wrapped);
    return 0;
}
