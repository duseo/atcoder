package main

import (
	"fmt"
	"sort"
)

func scanis(N int) []int{
	arr := make([]int, 0)
	for i := 0; i < N; i++ {
		var tmp int
		fmt.Scan(&tmp)
		arr = append(arr, tmp)
	}
	return arr
}

func main() {
	var N int
	fmt.Scan(&N)
	arr := scanis(N)

	sort.Slice(arr, func(i, j int) bool {
		return arr[i] > arr[j]
	})

	for i := 0; i < N - 1; i++ {
		if arr[i] == arr[i+1] {
			arr = append(arr[:i], arr[i+1:]...)
			i--
			N--
		}
	}

	fmt.Println(len(arr))



}
