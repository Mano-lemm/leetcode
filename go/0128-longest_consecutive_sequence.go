package main

import (
	ts "github.com/emirpasic/gods/sets/treeset"
)

func longestConsecutive(nums []int) int {
	sus := ts.NewWithIntComparator()
	for _, value := range nums {
		sus.Add(value)
	}

	max := 0
	for _, val := range sus.Values() {
		len := 1
		if sus.Contains(val.(int) + 1) {
			for sus.Contains(val.(int) + len){
				sus.Remove(val.(int) + len)
				len++
			}
		}
		if len > max {
			max = len
		}
	}
	return max
}
