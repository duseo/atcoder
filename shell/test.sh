#!/bin/bash

mode=$(cat ./.mode)
sendfile=""

if test "$mode" = "go" ; then
  go build main.go
  oj t -c "./main"
fi

if test "$mode" = "cpp"; then
  g++ main.cpp; oj t 
fi

if test "$mode" = "fsharp"; then
  oj t -c "dotnet run --project ./fsharp/fsharp.fsproj"
fi

if test "$mode" = "cs"; then
  oj t -c "dotnet run --project atcoder.csproj"
fi
