package main

import (
	"fmt"
)

func main() {
	N := scani()
	arr := scanis(N)
	m := make(map[int]int)
	for _, v := range arr {
		m[v] = 1
	}
	for i := 1; N >= 0; i++ {
		if m[i]	== 1 {
			N--
		} else {
			N = N - 2
		}
		if N < 0 {
			fmt.Println(i - 1)
			break
		}

	}


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