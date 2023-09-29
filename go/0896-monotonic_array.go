package main

const (
	UNK int = iota
	INC
	DEC
)

func isMonotonic(nums []int) bool {
	s := UNK
    for i := 0; i < len(nums) - 1; i++ {
		if nums[i] < nums[i+1] {
			if s == INC {
				return false
			}
			s = DEC
		} else if nums[i] > nums[i+1] {
			if s == DEC {
				return false
			}
			s = INC
		}
	}
	return true
}
