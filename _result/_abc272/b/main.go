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
	N := scani()
	M := scani()
	p := make([][]int, M)
	for i := 0; i < M; i++ {
		k := scani()
		for j := 0; j < k; j++ {
			tmp := scani()	
			tmp--
			p[i] = append(p[i], tmp)
		}
	}	

	ok := true

	for i := 0; i < N; i++ {
		for j := 0; j < N; j++ {
			if i != j && !DidMeet(i, j, p){
				ok = false
			}	
		}	
	}

	if ok {
		fmt.Println("Yes")
	} else {
		fmt.Println("No")
	}
}

func DidMeet(a int, b int, p [][]int) bool {
	for i := 0; i < len(p); i++ {
		if Contains(p[i], a) && Contains(p[i], b){
			return true
		}
	}

	return false
}

func Contains(x []int, a int) bool {
	for i := 0; i < len(x); i++ {
		if x[i] == a {
			return true
		}
	}	
	
	return false
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