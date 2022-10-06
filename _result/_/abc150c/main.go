package main

import (
	"fmt"
	"sort"
)

func main() {
	N := scani()
	P := make([]int, N)
	Q := make([]int, N)
	perm := make([]int, N)
	for i := 0; i < N; i++ {
		perm[i] = i+1
		P[i] = scani()	
	}
	for i := 0; i < N; i++ {
		Q[i] = scani()	
	}
	a := 0
	b := 0
	cnt := 1

	if (Equal(P, perm)) {
		a = 1
	}

	if (Equal(Q, perm)) {
		b = 1
	}

	for i := 0; NextPermutation(sort.IntSlice(perm)); i++ {
		cnt++	
		if (Equal(P, perm)){
			a = cnt
		}
		if (Equal(Q, perm)){
			b = cnt
		}
	}
	fmt.Println(Abs(a-b))
}

func Equal(a []int, b []int) bool {
	for i := 0; i < len(a); i++ {
		if (a[i] != b[i]) {
			return false
		}	
	}
	return true
}

func Abs(a int) int{
	if a < 0 {
		return -a
	} else {
		return a
	}
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