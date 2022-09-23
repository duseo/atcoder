package main

import (
	"fmt"
)

func scanis(n int) []int {
	arr := make([]int, 0)

	for i := 0; i < n; i++ {
		var Ai int
		fmt.Scan(&Ai)
		arr = append(arr, Ai)
	}

	return arr
}

func solve(N int, L int, K int, arr []int, mid int) bool {
	var pre = 0
	var cnt = 0
	for i, a := range arr {
		if a-pre >= mid && L-a >= mid {
			cnt++
			pre = a
			i++
			i--
		}
	}
	return cnt >= K
}

func main() {
	var N, L, K int
	var arr []int
	fmt.Scan(&N)
	fmt.Scan(&L)
	fmt.Scan(&K)
	arr = scanis(N)

	var left = -1
	var right = L + 1
	var mid int

	for right-left > 1 {
		mid = left + (right-left)/2
		if !solve(N, L, K, arr, mid) {
			right = mid
		} else {
			left = mid
		}
	}

	fmt.Println(left)
}
