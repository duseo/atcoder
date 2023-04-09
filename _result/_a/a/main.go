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
	n, d := ni2()
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

func ns() string {
	sc.Scan()
	return sc.Text()
}

func ns2() (string, string) {
	return ns(), ns()
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
func binarySearch2(l, r, x, cs *big.Int, left bool) *big.Int {
	for r.Sub(r, l).Cmp(big.NewInt(1)) == 1 {
		mid := new(big.Int).Add(l, new(big.Int).Sub(r, l).Div(r.Sub(r, l), big.NewInt(2)))
		if good2(mid, x, cs) {
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

func good2(n, x, cs *big.Int) bool {
	diff := new(big.Int).Sub(cs, n)
	sum := new(big.Int).Add(cs, n)
	prod := new(big.Int).Mul(diff, sum)
	if prod.Cmp(x) >= 0 {
		return true
	}
	return false
}

func binarySearch(l, r, x *big.Int, left bool) *big.Int {
	for r.Sub(r, l).Cmp(big.NewInt(1)) == 1 {
		mid := new(big.Int).Add(l, new(big.Int).Sub(r, l).Div(r.Sub(r, l), big.NewInt(2)))
		if good(mid, x) {
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

func good(n, x *big.Int) bool {
	if n.Mul(n, n).Cmp(x) >= 0 {
		return true
	}
	return false
}

func tdm(n, m int) [][]int {
	tmp := make([][]int, n)
	for i := 0; i < n; i++ {
		tmp[i] = make([]int, n)
		for j := 0; j < n; j++ {
			tmp[i][j] = ni()
		}
	}
	return tmp
}

// region union find
type dsu struct {
	id    []int
	sz    []int
	count int
}

func newDsu(n int) *dsu {
	newDsu := dsu{}
	newDsu.count = n
	newDsu.id = make([]int, n)
	for i := 0; i < n; i++ {
		newDsu.id[i] = i
	}

	newDsu.sz = make([]int, n)
	for i := 0; i < n; i++ {
		newDsu.sz[i] = 1
	}
	return &newDsu
}

func (uf dsu) connected(q, p int) bool {
	return uf.find(q) == uf.find(p)
}

func (uf dsu) find(p int) int {
	for p != uf.id[p] {
		p = uf.id[p]
	}
	return p
}

func (uf dsu) union(p, q int) {
	i := uf.find(p)
	j := uf.find(q)
	if i == j {
		return
	}

	if uf.sz[i] < uf.sz[j] {
		uf.id[i] = j
		uf.sz[j] += uf.sz[i]
	} else {
		uf.id[j] = i
		uf.sz[i] += uf.sz[j]
	}
	uf.count--
}

//endregion

func hasbit(a int, n int) bool {
	return (a>>uint(n))&1 == 1
}

func nthbit(a int, n int) int {
	return int((a >> uint(n)) & 1)
}

func bigint(x int) *big.Int {
	return big.NewInt(int64(x))
}

func multiply(x, y *big.Int) *big.Int {
	return new(big.Int).Mul(x, y)
}

func min2(a, b *big.Int) *big.Int {
	if a.Cmp(b) < 0 {
		return a
	} else {
		return b
	}
}
