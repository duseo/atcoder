#!/bin/bash

mode=$(cat ./.mode)

if test "$mode" = "go" ; then
  oj s main.go
fi

if test "$mode" = "cpp"; then
  oj s main.cpp
fi

if test "$mode" = "cs"; then
  oj s Program.cs -l 5003
fi
