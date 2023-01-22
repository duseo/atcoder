package main

import (
	"bufio"
	"fmt"
	"math"
	"math/big"
	"os"
	"sort"
	"strconv"
	"strings"
)

var sc = bufio.NewScanner(os.Stdin)
var wtr = bufio.NewWriter(os.Stdout)

func main() {
	n := scani()
	a := scans()
	b := scans()
	ba := []byte(a)
	bb := []byte(b)

	bLarger := false
	// startindex finden
	start := 1
	for i := 0; i < n; i++ {
		if int(ba[i]) == int(bb[i]) {
			continue
		}
		if int(ba[i]) < int(bb[i]) {
			bLarger = true
			start = i + 1
			break
		} else {
			start = i + 1
			break
		}
	}

	for i := start; i < n; i++ {
		if bLarger {
			if int(ba[i]) > int(bb[i]) {
				tmp := bb[i]
				bb[i] = ba[i]
				ba[i] = tmp
			}
		} else {
			if int(ba[i]) < int(bb[i]) {
				tmp := bb[i]
				bb[i] = ba[i]
				ba[i] = tmp
			}
		}
	}

	x := new(big.Int)
	y := new(big.Int)
	md := new(big.Int)
	x, _ = x.SetString(string(ba), 10)
	y, _ = y.SetString(string(bb), 10)
	md, _ = md.SetString("998244353", 10)

	res := big.NewInt(0).Mul(x, y)
	www := big.NewInt(0).Rem(res, md)
	fmt.Println(www)
}

func rec(k int) int {
	if k == 0 {
		return 1
	}

	return k * rec(k-1)
}

// ==================================================
// init
// ==================================================

func init() {
	sc.Buffer([]byte{}, math.MaxInt64)
	sc.Split(bufio.ScanWords)
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

func nis(arg ...int) []int {
	n := arg[0]
	t := 0
	if len(arg) == 2 {
		t = arg[1]
	}

	a := make([]int, n)
	for i := 0; i < n; i++ {
		a[i] = ni() - t
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

func atoi(s string) int {
	i, e := strconv.Atoi(s)
	if e != nil {
		panic(e)
	}
	return i
}

func itoa(i int) string {
	return strconv.Itoa(i)
}

func btoi(b byte) int {
	return atoi(string(b))
}

func scans() string {
	var x string
	fmt.Scan(&x)
	return x
}

func scanis(N int) []int {
	arr := make([]int, 0)
	for i := 0; i < N; i++ {
		var tmp int
		fmt.Scan(&tmp)
		arr = append(arr, tmp)
	}
	return arr
}

func printyn(b bool) {
	if b {
		fmt.Println("Yes")
	} else {
		fmt.Println("No")
	}
}

func min(a, b int) int {
	if a < b {
		return a
	} else {
		return b
	}
}

func max(a, b int) int {
	if a > b {
		return a
	} else {
		return b
	}
}

func abs(a int) int {
	if a < 0 {
		return -a
	} else {
		return a
	}
}

func intSliceToString(x []int) string {
	s := make([]string, 0)
	for _, v := range x {
		s = append(s, itoa(v))
	}
	return strings.Join(s, " ")
}

func binarySearch(l, r int, left bool) int {
	for r-l > 1 {
		mid := (r + l) / 2
		if good(mid) {
			r = mid
		} else {
			l = mid
		}
	}

	if left {
		return l
	}

	return r
}

func good(n int) bool {
	if n > 5 {
		return true
	}
	return false
}

func tdm(n, m int) [][]int {
	tmp := make([][]int, n)
	for i := 0; i < n; i++ {
		tmp[i] = make([]int, m)
	}
	return tmp
}
