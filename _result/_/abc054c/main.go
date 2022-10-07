package main

import (
	"fmt"
	"sort"
)

func main() {
	N := scani()
	M := scani()
	arr := make([][]int, N)
	perm := make([]int, N - 1)
	for i := 0; i < N - 1; i++ {
		perm[i] = i	+ 1
	}

	for i := 0; i < M; i++ {
		a := scani()
		b := scani()
		a--
		b--
		arr[a] = append(arr[a], b)	
		arr[b] = append(arr[b], a)	
	}

	cnt := 0
	ok := true
	for i := 0; i < N - 1; i++ {
		if i == 0 {
			if !IsConnected(0, perm[0], arr){
				ok = false
			} 
		} else {
			if !IsConnected(perm[i-1], perm[i], arr){
				ok = false
			}
		}

	}
	if ok {
		cnt++
	}

	for k := 0; NextPermutation(sort.IntSlice(perm)); k++ {
		ok = true
		for i := 0; i < N - 1; i++ {
			if i == 0 {
				if !IsConnected(0, perm[0], arr) {
					ok = false
				}
			} else {
				if !IsConnected(perm[i-1], perm[i], arr) {
					ok = false
				}
			}
		}
		if ok {
			cnt++
		}
	}
	fmt.Println(cnt)
}

func IsConnected(a int, b int, arr [][]int) bool{
	return Contains(arr[a], b) || Contains(arr[b], a)
} 

func Contains(s []int, str int) bool {
	for _, v := range s {
		if v == str {
			return true
		}
	}

	return false
}


func NextPermutation(x sort.Interface) bool {
	n := x.Len() - 1
	if n < 1 {
		return false
	}
	j := n - 1
	for ; !x.Less(j, j+1); j-- {
		if j == 0 {
			return false
		}
	}
	l := n
	for !x.Less(j, l) {
		l--
	}
	x.Swap(j, l)
	for k, l := j+1, n; k < l; {
		x.Swap(k, l)
		k++
		l--
	}
	return true
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