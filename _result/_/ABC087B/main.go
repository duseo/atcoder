package main

import (
	"fmt"
)

func main() {
	var A, B, C int
	var T int
	fmt.Scan(&A)
	fmt.Scan(&B)
	fmt.Scan(&C)
	fmt.Scan(&T)
	cnt := 0

	for i := 0; i <= A; i++ {
		for j := 0; j <= B; j++ {
			for k := 0; k <= C; k++ {
				if 500*i+100*j+50*k == T {
					cnt++
				}
			}
		}
	}

	fmt.Println(cnt)

}
