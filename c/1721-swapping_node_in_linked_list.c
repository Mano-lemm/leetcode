#import <stdlib.h>
#import <stdbool.h>
#import <stdio.h>

struct ListNode {
    int val;
    struct ListNode *next;
};

struct ListNode* swapNodes(struct ListNode* head, int k){
    struct ListNode** nodes = malloc(sizeof(struct ListNode*) * 2);
    struct ListNode* tmpHead = head;
    struct ListNode* tmpAss = head;
    for(int i = 0; i < k - 1; i++) tmpAss = tmpAss->next;
    nodes[0] = tmpAss;

    while(tmpAss->next != NULL){
	tmpHead = tmpHead->next;
	tmpAss = tmpAss->next;
    }
    nodes[1] = tmpHead;

    printf("kth:\t%d\nkth-end:\t%d", nodes[0]->val, nodes[1]->val);

    int tmpval = nodes[0]->val;
    nodes[0]->val = nodes[1]->val;
    nodes[1]->val = tmpval;

    free(nodes);
    return head;
}

int main(){
    return 0;
}

