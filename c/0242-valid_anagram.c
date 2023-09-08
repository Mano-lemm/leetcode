#include <stdbool.h>
#include <assert.h>
#include <stdlib.h>
#include <stddef.h>
#include <stdio.h>

typedef struct {
    char character;
    int count;
} char_count;

typedef struct {
    char_count* chars;
    size_t size;
} char_map;

void insert_char_map(char_map* map, char character){
    int key = (int)(character) % 97;
    assert(map->chars[key].character == character);
    map->chars[key].count += 1;
}

bool check_char_map(char_map* map, char character){
    int key = (int)(character) % 97;
    assert(map->chars[key].character == character);
    map->chars[key].count -= 1;
    return map->chars[key].count >= 0;
}

bool isAnagram(char * s, char * t){
    char_map map;
    map.size = 32;
    map.chars = malloc(sizeof(char_count) * map.size);
    for (size_t i = 0; i < map.size; ++i) {
        map.chars[i].character = (char)(i + 97);
        map.chars[i].count = 0;
    }
    while (*s != '\0') {
	insert_char_map(&map, *s);
	s++;
    }
    while (*t != '\0') {
	if(!check_char_map(&map, *t)) {
	    free(map.chars);
	    return false;
	}
	t++;
    }
    for (size_t i = 0; i < map.size; ++i) {
        if(map.chars[i].count != 0){
	    free(map.chars);
	    return false;
	}
    }
    free(map.chars);
    return true;
}

int main(void){
    printf("%s\n", isAnagram("anagram", "nagaram") ? "true" : "false");
    printf("%s\n", isAnagram("car", "rat") ? "true" : "false");
    return 0;
}
