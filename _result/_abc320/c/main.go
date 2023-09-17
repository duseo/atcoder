package main

import (
	"bufio"
	"fmt"
	"math"
	"os"
	"sort"
	"strconv"
	"strings"
)

var sc = bufio.NewScanner(os.Stdin)
var wtr = bufio.NewWriter(os.Stdout)

func main() {
	m := ni()
	s := make(map[int][]int)
	s[1] = strToIntSlice(ns())
	s[2] = strToIntSlice(ns())
	s[3] = strToIntSlice(ns())
	s[1] = append(s[1], append(s[1], s[1]...)...)
	s[2] = append(s[2], append(s[2], s[2]...)...)
	s[3] = append(s[3], append(s[3], s[3]...)...)

	found := false

	calc := func(num, one, two, three int) int {
		ignore := make(map[int]bool)
		i1, i2, i3 := -1, -1, -1
		for i := 0; i < 3*m; i++ {
			if !ignore[one] && s[one][i] == num {
				i1 = i
				ignore[one] = true
			} else if !ignore[two] && s[two][i] == num {
				i2 = i
				ignore[two] = true
			} else if !ignore[three] && s[three][i] == num {
				i3 = i
				ignore[three] = true
			}
			if i1 != -1 && i2 != -1 && i3 != -1 {
				found = true
				return max(i1, max(i2, i3))
			}
		}
		return 500000
	}

	getNext := func(num int) int {
		erg := 50000
		for i := 1; i < 4; i++ {
			for j := 1; j < 4; j++ {
				for k := 1; k < 4; k++ {
					if i != j && i != k && j != k {
						erg = min(erg, calc(num, i, j, k))
					}
				}
			}
		}
		return erg
	}

	res := 500
	for i := 0; i < 10; i++ {
		res = min(getNext(i), res)
	}

	if !found {
		fmt.Println(-1)
		return
	}
	fmt.Println(res)
}

func contains(arr []int, number int) bool {
	res := false
	for i := 0; i < len(arr); i++ {
		if arr[i] == number {
			return true
		}
	}
	return res
}

func strToIntSlice(s string) []int {
	res := make([]int, len(s))
	for i := 0; i < len(s); i++ {
		res[i] = atoi(string(s[i]))
	}
	return res
}

type point struct {
	x int
	y int
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
const inf = math.MaxInt64
const mod1000000007 = 1000000007
const mod998244353 = 998244353
const mod = mod998244353

var mpowcache map[[3]int]int

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
func min3(a, b, c int) int {
	return min(a, min(b, c))

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

func prefix2d(h, w int) [][]int {
	arr := make([][]int, h)
	first := nis(w)
	for i := 1; i < w; i++ {
		first[i] += first[i-1]
	}
	arr[0] = first
	for i := 1; i < h; i++ {
		tmp := nis(w)
		for j := 1; j < w; j++ {
			tmp[j] = tmp[j-1] + tmp[j]
		}
		for j := 0; j < w; j++ {
			tmp[j] += arr[i-1][j]
		}
		arr[i] = tmp

	}
	return arr
}

// ==================================================
// mod
// ==================================================

func madd(a, b int) int {
	a += b
	if a >= mod || a <= -mod {
		a %= mod
	}
	if a < 0 {
		a += mod
	}
	return a
}

func mmul(a, b int) int {
	return a * b % mod
}

func mdiv(a, b int) int {
	a %= mod
	return a * minvfermat(b, mod) % mod
}

func mpow(a, n, m int) int {
	if v, ok := mpowcache[[3]int{a, n, m}]; ok {
		return v
	}
	fa := a
	fn := n
	if m == 1 {
		return 0
	}
	r := 1
	for n > 0 {
		if n&1 == 1 {
			r = r * a % m
		}
		a, n = a*a%m, n>>1
	}
	mpowcache[[3]int{fa, fn, m}] = r
	return r
}

func minv(a, m int) int {
	p, x, u := m, 1, 0
	for p != 0 {
		t := a / p
		a, p = p, a-t*p
		x, u = u, x-t*u
	}
	x %= m
	if x < 0 {
		x += m
	}
	return x
}

// m only allow prime number
func minvfermat(a, m int) int {
	return mpow(a, m-2, mod)
}
