package main

import (
	"fmt"
)

func main() {
	var x string
	fmt.Scan(&x)
	fmt.Printf("%c", x[len(x)/2])
	fmt.Print("\n")
}