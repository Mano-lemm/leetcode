package main

// use pass by value/reference to keep adding to the answer
// while discarding attempts that dont work out
// because every ( needs an ) the length of a valid string with n braces
// will always be n*2
func recurse(answer *[]string, n, left_brace, right_brace int, current []rune) {
	if left_brace + right_brace == n*2 {
		*answer = append(*answer, string(current))
	}

	// less than the allowed amount of left braces
	if left_brace < n {
		current[left_brace + right_brace] = rune('(')
		recurse(answer, n, left_brace + 1, right_brace, current)
	}

	if right_brace < left_brace {
		current[left_brace + right_brace] = rune(')')
		recurse(answer, n, left_brace, right_brace + 1, current)
	}
}

func generateParenthesis(n int) []string {
	r := []string{}
	cur := make([]rune, n*2)
	recurse(&r, n, 0, 0, cur)
	return r;
}
