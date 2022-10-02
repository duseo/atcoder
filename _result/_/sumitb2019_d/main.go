package main

import (
	"fmt"
	"strings"
)

func canGenerate(pin string, s string) bool {
	i1 := strings.Index(s, string(pin[0]))
	if i1 != -1 {
		i2 := strings.Index(s[i1+1:], string(pin[1]))
			if i2 != -1 {
				i3 := strings.Index(s[len(s[:i1+1])+i2+1:], string(pin[2]))
				if i3 != -1{
					return true	
				}
			}
	}

	return false
}

func main() {
	N := scani()
	S := scans()
	res := 0
	res = N
	res = 0

	for i := 0; i < 1000; i++ {
		pin := fmt.Sprintf("%03d", i)
		if canGenerate(pin, S) {
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