package main

import (
	"fmt"
	"math"
)

func getCnt(n int) int {
	cnt := 0
	for n%2 == 0 {
		n = n/2
		cnt++	
	}
	return cnt 
}

func main() {
	var N int
	arr := make([]int, 0)
	fmt.Scan(&N)
	for N > 0 {
		var tmp int
		fmt.Scan(&tmp)
		arr = append(arr, tmp)
		N--
	}

	min := math.MaxInt32 
	for i, x := range arr {
		i++
		i--
		cnt := getCnt(x)
		if cnt < min {
			min = cnt
		}
	}
	fmt.Println(min)
}
