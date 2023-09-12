#include <stdlib.h>
#include <stdio.h>
#include <string.h>

void merge(int* nums1, int nums1Size, int m, int* nums2, int nums2Size, int n){
    int n1 = 0;
    int n2 = 0;
    int* helper = malloc(sizeof(int) * nums1Size);
    memcpy(helper, nums1, sizeof(int) * nums1Size);
    for (int i = 0; i < (m + n); i++) {
	if (n1 < m && n2 < n) {
	    if (helper[n1] < nums2[n2]) {
	        nums1[i] = helper[n1];
		n1++;
	    } else {
	        nums1[i] = nums2[n2];
		n2++;
	    }
	} else if (n1 < m) {
	    nums1[i] = helper[n1];
	    n1++;
	} else if (n2 < n) {
	    nums1[i] = nums2[n2];
	    n2++;
	} else {
	    fprintf(stderr, "n1 > nums1Size && n2 > nums2Size");
	    exit(1);
	}
    }
    free(helper);
}

int main(void)
{
    int m = 3;
    int n = 3;
    int nums1[] = {1, 2, 3, 0, 0, 0};
    int nums2[] = {2, 5, 6};
    merge(nums1, m + n, m, nums2, n, n);
    for (int i = 0; i < m + n; i++) {
	printf("%d  ", nums1[i]);
    }
    printf("\n");
}
