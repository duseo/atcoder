package main

import (
	"fmt"
)

func main() {
	N := scani()
	res := false
	out:
	for i := 1; i < 10; i++ {
		for j := 1; j < 10; j++ {
			if i*j == N {
				res = true
				break out
			} 	
		}	
	}
	
	if res {
		fmt.Println("Yes")
	} else {
		fmt.Println("No")
	}

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