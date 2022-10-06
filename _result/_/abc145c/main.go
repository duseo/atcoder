package main

import (
	"fmt"
	"math"
	"sort"
)

func main() {
	N := scani()
	c := make([]coords, N)
	ind := make([]int, N)
	n := float64(1)
	for i := 0; i < N; i++ {
		ind[i] = i;
		tmp := float64(scani())
		tmp2 := float64(scani())
		x := coords{x: tmp, y: tmp2}
		c[i] = x
	}
	acc := float64(0)
	if N > 0 {
		for i := 1; i < N; i++ {
			acc += dist(c[ind[i-1]], c[ind[i]])
		}
	}

	for i := 1; NextPermutation(sort.IntSlice(ind)); i++ {
		n++
		for j := 1; j < N; j++ {
			acc += dist(c[ind[j-1]], c[ind[j]])
		}
	}

	fmt.Println(acc/n)
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
	

type coords struct {
	x float64
	y float64
}

func dist(p1 coords, p2 coords) float64 {
	return math.Sqrt(((p1.x-p2.x)*(p1.x-p2.x))+((p1.y-p2.y)*(p1.y-p2.y)))
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