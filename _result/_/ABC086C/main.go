package main

import (
	"fmt"
)

func main() {
	N := scani()
	var px, py, pt int
	px = 0
	py = 0
	pt = 0
	ok := true
	for i := 0; i < N; i++ {
		t := scani()
		x := scani()
		y := scani()

		md := abs(x-px) + abs(y-py)
		dt := t - pt
		if md > dt {
			ok = false
		} else if md%2 != dt%2 {
			ok = false
		}

		pt = t
		px = x
		py = y
	}

	if ok {
		fmt.Println("Yes")
	} else {
		fmt.Println("No")
	}
}

func abs(x int) int {
	if x < 0 {
		return -x
	}
	return x
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