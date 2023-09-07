#include <stdlib.h>
#include <stdio.h>
#include <assert.h>
#include <string.h>

int removeDuplicates(int* nums, int numsSize){
    int r = 0;
    while (r < numsSize - 1) {
	if(nums[r] == nums[r+1]){
	    int idx = r;
	    while (idx < numsSize - 1 && nums[idx] == nums[idx + 1]) idx++;
	    memmove(&nums[r + 1], &nums[idx + 1], sizeof(int) * (numsSize - idx - 1));
	    numsSize -= (idx - r);
	}
	r++;
    }

    return numsSize;
}

int main(void){
    int nums[] = {1, 1, 2};
    int expectedNums[] = {1, 2};
    int expectedLen = 2;
    int k = removeDuplicates(nums, 3); 

    assert(k == expectedLen);
    for (int i = 0; i < k; i++) {
	assert(nums[i] == expectedNums[i]);
    }

    int nums_[] = {0,0,1,1,1,2,2,3,3,4};
    int expectedNums_[] = {0,1,2,3,4};
    int expectedLen_ = 5;
    k = removeDuplicates(nums_, 10);

    assert(k == expectedLen_);
    for (int i = 0; i < k; i++) {
	assert(nums_[i] == expectedNums_[i]);
    }
}
