package main

import (
	"fmt"
	"sort"
)

func main() {
	var N int
	arr := make([]int, 0)

	fmt.Scan(&N)

	for i := 0; i < N; i++ {
		var tmp int
		fmt.Scan(&tmp)	
		arr = append(arr, tmp)
	}

	sort.Slice(arr, func(i, j int) bool {
		return arr[i] > arr[j]
	})

	alice := 0
	bob := 0

	for i := 0; i < N; i++ {
		if i%2 == 0 {
			alice = alice + arr[i]
		} else {
			bob = bob + arr[i]
		}
	}

	fmt.Println(alice-bob)
}
