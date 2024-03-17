#!/bin/zsh

mode=$(cat ./.mode)

if test "$mode" = "go" ; then
  go build main.go
  ./main i
fi

if test "$mode" = "cpp"; then
  g++ -D=__LOCAL -o main main.cpp
  ./main
fi

if test "$mode" = "cs"; then
    dotnet run --project atcoder.csproj
fi

if test "$mode" = "py"; then
    python3 main.py
fi
