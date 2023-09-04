#include <stdlib.h>
#include <stdio.h>
#include <string.h>

void reverse(int* nums, int start, int end){
    int tmp;
    while (start < end) {
	tmp = nums[start];
	nums[start] = nums[end];
	nums[end] = tmp;
	start++;
	end--;
    }
}

void rotate_o1(int* nums, int numsSize, int k){
    k = k % numsSize;
    reverse(nums, 0, numsSize - k - 1);
    reverse(nums, numsSize - k, numsSize - 1);
    reverse(nums, 0, numsSize - 1);
}

void rotate(int* nums, int numsSize, int k){
    k = k % numsSize;
    int* tmp = malloc(sizeof(int) * k);
    memcpy(tmp, &nums[numsSize - k], sizeof(int) * k);
    memmove(&nums[k], nums, sizeof(int) * (numsSize - k));
    memcpy(nums, tmp, sizeof(int) * k);
    free(tmp);
}

int main(void){
    int nums[] = {1,2,3,4,5,6,7};
    rotate_o1(nums, 7, 3);
    printf("nums: \n\t");
    for (int i = 0; i < 7; i++) {
	printf("%d, ", nums[i]);
    }
    printf("\n");
    return 0;
}
