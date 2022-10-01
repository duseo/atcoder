package main

import (
	"fmt"
	"math"
)

func main() {
	A := scani()
	B := scani()
	AB := scani()
	X := scani()
	Y := scani()
	min := math.MaxInt32

	for c := 0; c <= max(2*X, 2*Y); c = c + 2 {
		x := max(X - c/2, 0)	
		y := max(Y - c/2, 0)
		xg := c/2 + x
		yg := c/2 + y

		if xg >= X && yg >= Y {
			cost := c * AB + x * A + y * B
			if cost < min {
				min = cost
			}
		}
	}

	fmt.Println(min)
}

func max(a int, b int) int{
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