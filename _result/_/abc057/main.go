package main

import (
	"fmt"
	"math"
)

func dc(n int) int{
	ds := 0
	for n > 0 {
		ds++
		n = n/10
	}
	return ds
}

func F(A int, B int) int {
	if (dc(A) > dc(B)) {
		return dc(A)
	} else {
		return dc(B)
	}
}

func main() {
	N := scani()
	tmp := math.Sqrt(float64(N)) + 3

	res := N
	cur := res
	for i := 1; i <= int(tmp); i++ {
		j := N/i
		if i * j == N {
			cur = F(i,j)
			if (cur < res) {
				res = cur
			}
		}	
	}
	fmt.Println(res)
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