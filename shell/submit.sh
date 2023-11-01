#!/bin/bash

mode=$(cat ./.mode)

if test "$mode" = "go" ; then
  oj s main.go
fi

if test "$mode" = "cpp"; then
  oj s main.cpp
fi

if test "$mode" = "fsharp"; then
  oj s main.cpp
fi

if test "$mode" = "csharp"; then
  oj s ./csharp Program.cs
fi
