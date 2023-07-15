package main

import (
	"bufio"
	"container/list"
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
	h, w := ni2()
	m := make([][]byte, h)
	for i := 0; i < h; i++ {
		m[i] = []byte(ns())
	}

	snuke := make(map[byte]byte)
	snuke['s'] = 'n'
	snuke['n'] = 'u'
	snuke['u'] = 'k'
	snuke['k'] = 'e'
	snuke['e'] = 's'

	getNext := func(c byte) byte {
		return snuke[c]
	}

	visited := make(map[point]bool)
	pok := func(from, to point) bool {
		if to.x >= 0 && to.x < h && to.y < w && to.y >= 0 && !visited[to] {
			if getNext(m[from.x][from.y]) == m[to.x][to.y] {
				visited[to] = true
				return true
			}
		}
		return false
	}

	p := point{0, 0}
	if m[0][0] != 's' {
		printyn(false)
		return
	}
	isOk := false
	q := list.New()
	q.PushBack(p)
	e := q.Front()
	for e != nil {
		t := e.Value.(point)
		if t.x == h-1 && t.y == w-1 {
			isOk = true
		}

		top := point{t.x - 1, t.y}
		bot := point{t.x + 1, t.y}
		rig := point{t.x, t.y + 1}
		lef := point{t.x, t.y - 1}

		if pok(t, top) {
			q.PushBack(top)
		}
		if pok(t, bot) {
			q.PushBack(bot)
		}
		if pok(t, rig) {
			q.PushBack(rig)
		}
		if pok(t, lef) {
			q.PushBack(lef)
		}

		e = e.Next()
	}

	printyn(isOk)

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
