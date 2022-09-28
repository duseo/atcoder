package main

import (
	"fmt"
)

func main() {
	cnt := 0
	N := scani()	

	for i := 1; i <= N; i++ {
		if nod(i)%2 != 0 {
			cnt++
		}
	}

	fmt.Println(cnt)
}

func nod(n int) int {
	ds := 0
	for n >= 1 {
		ds++
		n = n/10
	}
	
	return ds
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