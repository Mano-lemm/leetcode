#include <stddef.h>
#include <string.h>
#include <stdlib.h>
#include <stdio.h>
#include <stdbool.h>

struct Node {
    int val;
    struct Node* next;
    struct Node* random;
};

void freeLL(struct Node* head){
    if(head == NULL){
	return;
    }
    if(head->next != NULL){
	freeLL(head->next);
    }
    free(head);
}

struct Node* copyRandomList(struct Node* head) {
    if (head == NULL) return NULL;
    struct Node* tmp = head;
    while (tmp != NULL) {
	struct Node* new = malloc(sizeof(struct Node));
	memcpy(new, tmp, sizeof(struct Node));
	tmp->next = new;
	tmp = tmp->next->next;
    }
    return NULL;
}

void printLL(struct Node* head){
    while(true) {
	if (head == NULL) {
	    printf("NULL");
	    break;
	} else {
	    if (head->random == NULL) {
		printf("(val: %d, rand: NULL) -> ", head->val);
	    } else {
		printf("(val: %d, rand: %d) -> ", head->val, head->random->val);
	    }
	}
	head = head->next;
    }
    printf("\n");
}

int main(void){
    // a tad verbose perhaps 
    struct Node* head = malloc(sizeof(struct Node));
    head->val = 7;
    head->next = malloc(sizeof(struct Node));
    head->random = NULL;
    head->next->val = 13;
    head->next->random = head;
    head->next->next = malloc(sizeof(struct Node));
    head->next->next->val = 11;
    head->next->next->next = malloc(sizeof(struct Node));
    head->next->next->next->val = 10;
    head->next->next->next->random = head->next->next;
    head->next->next->next->next = malloc(sizeof(struct Node));
    head->next->next->next->next->val = 1;
    head->next->next->next->next->next = NULL;
    head->next->next->next->next->random = head;
    head->next->next->random = head->next->next->next->next;
    printLL(head);
    struct Node* copy = copyRandomList(head);
    printLL(copy);
    freeLL(copy);
    freeLL(head);
}
