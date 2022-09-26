package main

import (
	"fmt"
)

func main() {
	var N, Y int
	ok := false
	fmt.Scan(&N)
	fmt.Scan(&Y)
	out:
	for i := 0; i <= N; i++ {
		for j := 0; j <= N; j++ {
			k := N - i - j
			if 10000*i+5000*j+1000*k == Y && i+j+k == N && k >= 0 {
				fmt.Printf("%d %d %d\n", i, j, k)
				ok = true
				break out
			}	
		}	
	}

	if !ok {
		fmt.Printf("%d %d %d\n", -1, -1, -1)
	}

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