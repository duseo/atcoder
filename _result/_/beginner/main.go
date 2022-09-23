package main

import (
	"fmt"
)

func main() {
	var a, b, c int
	var s string
	fmt.Scan(&a)
	fmt.Scan(&b)
	fmt.Scan(&c)
	fmt.Scan(&s)
	fmt.Printf("%d %s", a+b+c, s)
	fmt.Println()
}