package main

import (
	"fmt"
	"strings"
)

func main() {
	var n int
	fmt.Scan(&n)

	var suffix string

	suffix = strings.Repeat(" Eve", 25-n)

	fmt.Println("Christmas" + suffix)
}
