package main

import (
	"fmt"
)


func main() {
	var S string
	fmt.Scan(&S)
	
	
	max := 0
	prevmax := 0
	
	for i := 0; i < len(S); i++ {
		if isACGT(S[i]) {
			max++
		} else {
			if max > prevmax {
				prevmax = max
			}
			max = 0
		}
	}

	if max > prevmax {
		prevmax = max
	}

	fmt.Println(prevmax)
}

func isACGT(x byte) bool {
	s := string(x)
	return s == "A" || s == "C" || s == "G" || s == "T"
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