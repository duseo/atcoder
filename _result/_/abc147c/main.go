package main

import (
	"fmt"
)

func main() {
	N := scani()
	a := make([][]int, N)
	for i := 0; i < N; i++ {
		a[i] = make([]int, N)
		for j := 0; j < N; j++ {
			a[i][j] = -1	
		}
	}

	for i := 0; i < N; i++ {
		k := scani()
		for j := 0; j < k; j++ {
			x := scani()			
			p := scani()			
			x--
			a[i][x] = p
		}
	}
	ans := 0
	for i := 0; i < 1<<N; i++ {
		d := make([]int, N)	
		for j := 0; j < N; j++ {
			if i>>j&1 == 1 {
				d[j] = 1
			}	
		}
		res := true

		for j := 0; j < N; j++ {
			if d[j] == 1 {
				for k := 0; k < N; k++ {
					if a[j][k] == -1 {
						continue
					}	
					if a[j][k] != d[k] {
						res = false
					}
				}
			}
		}

		if res {
			ans = max(ans, popcount(i))
		}

	}

	fmt.Println(ans)
}

func popcount(n int) int {
	cnt := 0
	for n > 0 {
		if n & 1 == 1 {
			cnt++
		}
		n = n >> 1
	}
	return cnt
}

func max(a int, b int) int {
	if a > b {
		return a
	} else {
		return b
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