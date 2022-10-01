package main

import (
	"fmt"
	"strings"
)

func main() {
	t := scani()
	x := fmt.Sprintf("%x", t)
	if len(x) == 1 {
		x = "0" + x
	}
	fmt.Println(strings.ToUpper(x))
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