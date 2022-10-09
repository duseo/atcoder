package main

import (
	"fmt"
	"sort"
	"bufio"
	"os"
	"strconv"
)

var sc = bufio.NewScanner(os.Stdin)
var wtr = bufio.NewWriter(os.Stdout)

func main() {
	a := scani()
	b := scani()
	snk := 0

	m := make([]bool, 3)

	if a == 1 || b == 1 {
		m[0] = true
	}
	if a == 2 || b == 2 {
		m[1] = true
	}
	if a == 3 || b == 3 {
		m[0] = true
		m[1] = true
	}
	if a == 4 || b == 4 {
		m[2] = true
	}
	if a == 5 || b == 5 {
		m[0] = true
		m[2] = true
	}
	if a == 6 || b == 6 {
		m[1] = true
		m[2] = true
	}
	if a == 7 || b == 7 {
		m[0] = true
		m[1] = true
		m[2] = true
	}

	if m[0] {
		snk += 1
	}
	if m[1] {
		snk += 2
	}
	if m[2] {
		snk += 4
	}

	fmt.Println(snk)
}

// ==================================================
// io
// ==================================================

func ni() int {
	sc.Scan()
	i, e := strconv.Atoi(sc.Text())
	if e != nil {
		panic(e)
	}
	return i
}

func ni2() (int, int) {
	return ni(), ni()
}

func ni3() (int, int, int) {
	return ni(), ni(), ni()
}

func ni4() (int, int, int, int) {
	return ni(), ni(), ni(), ni()
}

func ni2a(n int) [][2]int {
	a := make([][2]int, n)
	for i := 0; i < n; i++ {
		a[i][0], a[i][1] = ni2()
	}
	return a
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