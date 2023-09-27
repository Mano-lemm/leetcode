package main

func removeDuplicateLetters(s string) string {
	stack := []rune{}
	counts := map[rune]int{}
	seen := map[rune]struct{}{}
	for _, c := range s {
		counts[c] += 1
	}
	for _, c := range s {
		if _, ok := seen[c]; ok {
			counts[c] -= 1
			continue
		}
		for len(stack) != 0 && counts[stack[len(stack)-1]] > 0 && stack[len(stack)-1] > c {
			delete(seen, stack[len(stack)-1])
			stack = stack[0 : len(stack)-1]
		}
		seen[c] = struct{}{}
		counts[c] -= 1
		stack = append(stack, c)
	}
	return string(stack)
}
