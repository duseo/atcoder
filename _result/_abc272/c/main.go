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
var a = make([]int, 0)

func main() {
	N := scani()
	for i := 0; i < N; i++ {
		tmp := scani()
		a = append(a, tmp)
	}

	even := make([]int, 0)
	odd := make([]int, 0)

	for i := 0; i < N; i++ {
		if a[i]%2 == 0 {
			even = append(even, a[i])
		} else {
			odd = append(odd, a[i])
		}
	}

	res := 0

	sort.Ints(even)
	sort.Ints(odd)
	i := len(even) -1
    j := len(odd) -1
	maxEven := -1 
	maxOdd := -1

	if i >=1 {
		maxEven = even[i] + even[i-1]
	} 	

	if j >=1 {
		maxOdd = odd[j] + odd[j-1]
	} 	

	if maxEven > maxOdd {
		res = maxEven
	} else {
		res = maxOdd
	}


	fmt.Println(res)
}

func IsEven(x int) bool{
	return x%2 == 0
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