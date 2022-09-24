package main

import (
	"fmt"
)

func digitSum(x int) int {
	res := 0
	for x >= 1 {
		m := x%10
		res = res + m
		x = x - m
		x = x/10
	}
	return res
}

func main() {
	var N, A, B int
	fmt.Scan(&N)
	fmt.Scan(&A)
	fmt.Scan(&B)

	var ds int
	res := 0

	for i := 1; i <= N; i++ {
		ds = digitSum(i)
		if ds <= B && ds >= A {
			res = res + i
		}
	}

	fmt.Println(res)
}
