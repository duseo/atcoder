package main

import (
	"fmt"
)

func canDivBoth(a int, b int, div int) bool {
	return (a/div)*div == a && (b/div)*div == b
}

func main() {
	a := scani()
	b := scani()
	k := scani()

	cnt := 0
	prevdiv := 0

	i := max(a,b) 
	prevdiv = i
	for i > 0 {
		if canDivBoth(a, b, i) {
			prevdiv = i
			cnt++
			if cnt == k {
				break;
			}
		}
		i--
	}
	fmt.Println(prevdiv)
}

func max(a int, b int) int {
	if a > b {
		return b
	} else {
		return a
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