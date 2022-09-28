package main

import (
	"fmt"
)

func main() {
	N := scani()
	var S string
	fmt.Scan(&S)
	cnt := 0

	for i := 0; i < N - 2; i++ {
		substr := S[i:i+3]
		if substr == "ABC" {
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

func scanis(N int) []int{
	arr := make([]int, 0)
	for i := 0; i < N; i++ {
		var tmp int
		fmt.Scan(&tmp)
		arr = append(arr, tmp)
	}
	return arr
}