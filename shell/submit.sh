#!/bin/bash

mode=$(cat ./.mode)

if test "$mode" = "go" ; then
  oj s main.go
fi

if test "$mode" = "cpp"; then
  oj s main.cpp
fi

if test "$mode" = "cs"; then
  /bin/bash ./shell/bundle.sh
  oj s Submit.cs -l 5003
  rm Submit.cs
fi
