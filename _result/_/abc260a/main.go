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
	s := scans()
	tmp := true
	for i := 0; i < len(s); i++ {
		tmp = true
		for j := 0; j < len(s); j++ {
			if i != j && s[i] == s[j] {
				tmp = false
			}
		}
		if tmp {
			fmt.Println(string(s[i]))
			break
		}
	}
	if !tmp {
		fmt.Println("-1")
	}
}

// ==================================================
// init
// ==================================================

const inf = math.MaxInt64

func init() {
	sc.Buffer([]byte{}, math.MaxInt64)
	sc.Split(bufio.ScanWords)
}

// ==================================================
// io
// ==================================================
func min(a, b int) int {
	if a > b {
		return b
	} else {
		return a
	}
}

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

func out(v ...interface{}) {
	_, e := fmt.Fprintln(wtr, v...)
	if e != nil {
		panic(e)
	}
}

func outis(sl []int) {
	r := make([]string, len(sl))
	for i, v := range sl {
		r[i] = itoa(v)
	}
	out(strings.Join(r, " "))
}

func itoa(i int) string {
	return strconv.Itoa(i)
}

func flush() {
	e := wtr.Flush()
	if e != nil {
		panic(e)
	}
}

// ==================================================
// bst
// ==================================================
type TreeNode struct {
	key   int
	value int
	left  *TreeNode
	right *TreeNode
}

type BST struct {
	root *TreeNode
}

func (t *BST) Insert(key int, value int) {
	var newNode *TreeNode = &TreeNode{key: key, value: value}
	if t.root == nil {
		t.root = newNode
	} else {
		InsertNode(t.root, newNode)
	}
}

func InsertNode(parent *TreeNode, newNode *TreeNode) {
	if newNode.key <= parent.key {
		if parent.left == nil {
			parent.left = newNode
		} else {
			InsertNode(parent.left, newNode)
		}
	}

	if newNode.key > parent.key {
		if parent.right == nil {
			parent.right = newNode
		} else {
			InsertNode(parent.right, newNode)
		}
	}
}

func (tree *BST) MinNode() *TreeNode {
	return minNode(tree.root)
}

func (tree *BST) MaxNode() *TreeNode {
	return maxNode(tree.root)
}

func minNode(treeNode *TreeNode) *TreeNode {
	if treeNode.left != nil {
		return minNode(treeNode.left)
	} else {
		return treeNode
	}
}

func maxNode(treeNode *TreeNode) *TreeNode {
	if treeNode.right != nil {
		return minNode(treeNode.right)
	} else {
		return treeNode
	}
}

func (tree *BST) Delete(key int) bool {
	removeNode(tree.root, key)
	return false
}

// removeNode method
func removeNode(treeNode *TreeNode, key int) *TreeNode {
	if treeNode == nil {
		return nil
	}
	if key <= treeNode.key {
		treeNode.left = removeNode(treeNode.left, key)
		return treeNode
	}
	if key > treeNode.key {
		treeNode.right = removeNode(treeNode.right, key)
		return treeNode
	}

	if treeNode.left == nil && treeNode.right == nil {
		treeNode = nil
		return nil
	}
	if treeNode.left == nil {
		treeNode = treeNode.right
		return treeNode
	}
	if treeNode.right == nil {
		treeNode = treeNode.left
		return treeNode
	}
	var leftmostright *TreeNode
	leftmostright = treeNode.right
	for {

		if leftmostright != nil && leftmostright.left != nil {
			leftmostright = leftmostright.left
		} else {
			break
		}
	}
	treeNode.key, treeNode.value = leftmostright.key, leftmostright.value
	treeNode.right = removeNode(treeNode.right, treeNode.key)
	return treeNode
}
