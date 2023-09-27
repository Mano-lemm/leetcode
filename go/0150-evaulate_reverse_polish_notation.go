package main

import (
	"strconv"
)

type stack []int

func (s *stack) push(n int) {
	*s = append(*s, n)
}

func (s *stack) pop() int {
	r := (*s)[len(*s)-1]
	*s = (*s)[0 : len(*s)-1]
	return r
}

func evalRPN(tokens []string) int {
	st := make(stack, 0)
	for _, value := range tokens {
		switch value {
		case "+":
			left := st.pop()
			right := st.pop()
			st.push(right + left)
		case "-":
			left := st.pop()
			right := st.pop()
			st.push(right - left)
		case "/":
			left := st.pop()
			right := st.pop()
			st.push(right / left)
		case "*":
			left := st.pop()
			right := st.pop()
			st.push(right * left)
		default:
			v, _ := strconv.ParseInt(value, 10, 16)
			st.push(int(v))
		}
	}
	return st.pop()
}
