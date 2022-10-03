package main

import (
	"fmt"
)

func main() {
	N := scani()
	M := scani()

	a := make([]int, N)

	for i := 0; i < M; i++ {
		ki := scani()
		for j := 0; j < ki; j++ {
			tmp := scani()
			tmp--
			a[tmp] |= 1 << i
		}
	}

	p := 0
	for i := 0; i < M; i++ {
		x := scani()
		p |= x << i  	
	}

	res := 0
	for i := 0; i < (1 << N) ; i++ {
		t := 0
		for j := 0; j < N; j++ {
			if i >> j & 1 != 0 {
				t ^= a[j]
			}
		}
		if (t == p) {
			res++
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