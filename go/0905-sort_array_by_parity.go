package main

func sortArrayByParity(nums []int) []int {
	cidx := -1
	for i := 0; i < len(nums)-1; i++ {
		if nums[i]%2 == 0 {
			cidx++
			nums[cidx], nums[i] = nums[i], nums[cidx]
		}
	}
	nums[cidx+1], nums[len(nums)-1] = nums[len(nums)-1], nums[cidx+1]
	return nums
}
