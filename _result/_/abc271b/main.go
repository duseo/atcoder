package main

import (
	"fmt"
	"bufio"
	"os"
	"strings"
	"strconv"
)

func main() {
	N := scani()
	Q := scani()
	M := make([][]int, 0)
	reader := bufio.NewReader(os.Stdin)

	for i := 0; i < N; i++ {
		text, _ := reader.ReadString('\n')
		text = strings.Replace(text, "\n", "", -1)
		st := strings.Split(text, " ")

		tmp := make([]int, len(st) + 1)

		for i, s := range st {
			tmp[i], _ = strconv.Atoi(s)
		}

		M = append(M, tmp)

	}

	for i := 0; i < Q; i++ {
		text, _ := reader.ReadString('\n')
		text = strings.Replace(text, "\n", "", -1)
		st := strings.Split(text, " ")
		tmp := make([]int, len(st) + 1)

		for i, s := range st {
			tmp[i], _ = strconv.Atoi(s)
		}
		fmt.Println(M[tmp[0]-1][tmp[1]])
	}
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