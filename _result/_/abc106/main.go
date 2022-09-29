package main

import (
	"fmt"
)

func isFactor(i int, n int) bool {
	return n == (n/i)*i
}

func hasEight(n int) bool {
	cnt := 0
	for i := 1; i <= n; i++ {
		if isFactor(i, n) {
			cnt++
		}
	}
	return cnt == 8
}

func main() {
	cnt := 0
	N := scani()
	for i := 1; i <= N; i = i + 2 {
		if hasEight(i) {
			cnt++	
		}
	}
	fmt.Println(cnt)
}

func scani() int {
	var x int
	fmt.Scan(&x)
	return x
}

func scans() string {
	var x string
	fmt.Scan(&x)
	return x
}

func scanis(N int) []int{
	arr := make([]int, 0)
	for i := 0; i < N; i++ {
		var tmp int
		fmt.Scan(&tmp)
		arr = append(arr, tmp)
	}
	return arr
}