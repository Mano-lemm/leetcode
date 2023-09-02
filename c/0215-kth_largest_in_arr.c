#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <limits.h>

// TODO: somewhere, a bug is hiding among us
void insert(int* nums, int numsSize, int toInsert){
    int start = 0;
    int end = numsSize - 1;
    int where = (start + end) / 2;
    while(start <= end){
	if(nums[where] < toInsert){
	    end = where - 1;
	} else if(nums[where] > toInsert){
	    start = where + 1;
	} else {
	    break;
	}
	where = (start + end) / 2;
    }
    if(nums[where] > toInsert && where == numsSize - 1)
	return;
    memmove(&nums[where + 1], &nums[where], sizeof(int) * (numsSize - (where + 1)));
    nums[where] = toInsert;
}

int findKthLargest(int* nums, int numsSize, int k){
    int* topK = malloc(sizeof(int) * k);
    for(int i = 0; i < k; i++)
	topK[i] = INT_MIN;
    for(int i = 0; i < numsSize; i++){
	insert(topK, k, nums[i]);
    }
    int r = topK[k-1];
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
    return 0;
}
