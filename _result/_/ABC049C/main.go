package main

import (
	"fmt"
)

func main() {
	var S string
	fmt.Scan(&S)
	arr := make([]int, len(S) + 1)
	for i := 0; i <= len(S); i++ {
		arr[i] = -1
	}
	arr[0] = 0

	for i := 0; i < len(S); i++ {
		if arr[i] != 0 {
			continue
		}

		s5 := S[i:min(len(S), i+5)]
		s6 := S[i:min(len(S), i+6)]
		s7 := S[i:min(len(S), i+7)]

		if (s5 == "dream" || s5 == "erase") {
			arr[i+5] = 0
		}
		if (s6 == "eraser") {
			arr[i+6] = 0
		}
		if (s7 == "dreamer") {
			arr[i+7] = 0
		}

	}

	if (arr[len(S)] == 0) {
		fmt.Println("YES")
	} else {
		fmt.Println("NO")
	}

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

func min(a, b int) int {
    if a < b {
        return a
    }
    return b
}
