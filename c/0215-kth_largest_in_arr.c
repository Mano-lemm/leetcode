#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <limits.h>

typedef struct heap {
    int cursize;
    int max;
    int* arr;
} heap;

void swap(int *a, int *b){
    int tmp = *a;
    *a = *b;
    *b = tmp;
}

heap* init_heap(int max){
    heap* h = malloc(sizeof(heap));
    h->arr = malloc(sizeof(int) * max);
    for(int i = 0; i < max; i++)
	h->arr[i] = INT_MAX;
    h->cursize = 0;
    h->max = max;
    return h;
}

void deinit_heap(heap* h){
    free(h->arr);
}

void heapify(heap* heap, int idx){
    int smallest = idx;
    int leftChild = 2 * idx + 1;
    int rightChild = 2 * idx + 2;

    if(leftChild < heap->cursize && heap->arr[leftChild] < heap->arr[smallest])
	smallest = leftChild;

    if(rightChild < heap->cursize && heap->arr[rightChild] < heap->arr[smallest])
	smallest = rightChild;

    if(smallest != idx){
	swap(&heap->arr[idx], &heap->arr[smallest]);
	heapify(heap, smallest);
    }
}

#define heapify(a) heapify(a, 0)

void bottom_heapify(heap* heap, int idx){
    int parent = (idx - 1) / 2;
    if(parent < 0) return;
    if(heap->arr[idx] < heap->arr[parent]){
	swap(&heap->arr[idx], &heap->arr[parent]);
	bottom_heapify(heap, parent);
    }
}

#define bottom_heapify(heap) bottom_heapify(heap, heap->cursize - 1)


void push(heap* heap, int toInsert){
    heap->arr[heap->cursize] = toInsert;
    heap->cursize++;
    bottom_heapify(heap);
}

int top(heap* heap){
    return heap->arr[0];
}

int pop(heap* heap){
    int top = heap->arr[0];
    heap->arr[0] = heap->arr[heap->cursize - 1];
    heap->cursize--;
    heapify(heap);
    return top;
}

int findKthLargest(int* nums, int numsSize, int k){
    heap* topK = init_heap(k);
    for(int i = 0; i < k; i++){
	push(topK, nums[i]);
    }
    for(int i = k; i < numsSize; i++){
	if(nums[i] <= top(topK)) continue;
	pop(topK);
	push(topK, nums[i]);
    }
    int r = top(topK);
    deinit_heap(topK);
    free(topK);
    return r;
}

int main(void){
    int k[6] = {3,2,1,5,6,4};
    printf("real:\t\t%d\n", findKthLargest(k, 6, 2));
    printf("expected:\t5\n");
    int k_[9] = {3,2,3,1,2,4,5,5,6};
    printf("real:\t\t%d\n", findKthLargest(k_, 9, 4));
    printf("expected:\t4\n");
    int k__[] = {2,1};
    printf("real:\t\t%d\n", findKthLargest(k__, 2, 2));
    printf("expected:\t1\n");
    int k___[] = {3,2,1,5,6,4};
    printf("real:\t\t%d\n", findKthLargest(k___, 6, 2));
    printf("expected:\t5\n");
    int k____[] = {7,6,5,4,3,2,1};
    printf("real:\t\t%d\n", findKthLargest(k____, 7, 5));
    printf("expected:\t3\n");
    return 0;
}
