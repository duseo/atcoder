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
	n, m := ni2()
	a := nis(n)
	total := 0
	sort.Ints(a)

	uf := NewUnionFind(n)

	for i := 0; i < n; i++ {
		total += a[i]
		j := (i + 1) % n
		if a[i] == a[j] || (a[i]+1)%m == a[j] {
			uf.Union(a[i], a[j])
		}
	}

	resm := make(map[int]int)
	for i := 0; i < n; i++ {
		resm[uf.Find(a[i])] += a[i]
	}

	max := 0
	for _, v := range resm {
		if v > max {
			max = v
		}
	}

	fmt.Println(total - max)
}

// ==================================================
// Union-find
// ==================================================
type UnionFind struct {
	id  map[int]int
	sz  map[int]int
	cnt int
}

func Get(m map[int]int, k int) int {
	if val, ok := m[k]; ok {
		return val
	}
	return -1
}

func NewUnionFind(n int) *UnionFind {
	uf := new(UnionFind)
	uf.id = make(map[int]int)
	uf.sz = make(map[int]int)
	uf.cnt = n
	return uf
}

func (uf *UnionFind) Count() int {
	return uf.cnt
}

func (uf *UnionFind) Connected(p, q int) bool {
	return uf.Find(p) == uf.Find(q)
}

func (uf *UnionFind) Find(p int) int {
	for Get(uf.id, p) != -1 {
		p = uf.id[p]
	}
	return p
}

func (uf *UnionFind) Union(p, q int) {
	i := uf.Find(p)
	j := uf.Find(q)
	if i == j {
		return
	}

	if uf.sz[i] < uf.sz[j] {
		uf.id[i] = j
		if uf.sz[j] == 0 {
			uf.sz[j] = 1
		}
		uf.sz[j] += uf.sz[i]
	} else {
		uf.id[j] = i
		if uf.sz[i] == 0 {
			uf.sz[i] = 1
		}
		uf.sz[i] += uf.sz[j]
	}

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
