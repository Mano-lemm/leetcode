#include <stdbool.h>
#include <stdlib.h>
#include <stdio.h>

struct ListNode {
    int val;
    struct ListNode *next;
};

struct ListNode* addTwoNumbers(struct ListNode* l1, struct ListNode* l2){
    struct ListNode* head = NULL;
    struct ListNode** ass = &head;
    bool carry = false;
    while (l1 != NULL && l2 != NULL) {
        (*ass) = malloc(sizeof(struct ListNode));
        (*ass)->val = (l1->val + l2->val + ((carry) ? 1 : 0)) % 10;
        carry = (l1->val + l2->val + ((carry) ? 1 : 0)) >= 10;
        l1 = l1->next;
        l2 = l2->next;
        ass = &(*ass)->next;
    }
    while (l1 != NULL) {
        (*ass) = malloc(sizeof(struct ListNode));
        (*ass)->val = (l1->val + ((carry) ? 1 : 0)) % 10;
        carry = (l1->val + ((carry) ? 1 : 0)) >= 10;
        l1 = l1->next;
        ass = &(*ass)->next;
    }
    while (l2 != NULL) {
        (*ass) = malloc(sizeof(struct ListNode));
        (*ass)->val = (l2->val + ((carry) ? 1 : 0)) % 10;
        carry = (l2->val + ((carry) ? 1 : 0)) >= 10;
        l2 = l2->next;
        ass = &(*ass)->next;
    }
    if (carry) {
        (*ass) = malloc(sizeof(struct ListNode));
        (*ass)->val = 1;
        (*ass)->next = NULL;
        ass = &(*ass)->next;
    }
    (*ass) = NULL;
    return head;
}

int main(void) {
    struct ListNode* l1 = malloc(sizeof(struct ListNode));
    l1->val = 2;
    l1->next = malloc(sizeof(struct ListNode));
    l1->next->val = 4;
    l1->next->next = malloc(sizeof(struct ListNode));
    l1->next->next->val = 3;
    l1->next->next->next = NULL;
    struct ListNode* l2 = malloc(sizeof(struct ListNode));
    l2->val = 5;
    l2->next = malloc(sizeof(struct ListNode));
    l2->next->val = 6;
    l2->next->next = malloc(sizeof(struct ListNode));
    l2->next->next->val = 4;
    l2->next->next->next = NULL;
    struct ListNode* sus = addTwoNumbers(l1, l2);
    printf("among us");
    return 0;
}
