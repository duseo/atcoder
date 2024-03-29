#!/bin/bash

mode=$(cat ./.mode)
sendfile=""

if test "$mode" = "go" ; then
  sendfile="main.go"
fi

if test "$mode" = "cpp"; then
  sendfile="main.cpp"
fi

if test "$mode" = "cs"; then
  sendfile="Program.cs"
fi

echo -e CONTEST?
read dir
echo -n QUESTION?
read q
mkdir -p _result/_$dir/$q
mv -i Program.cs _result/_$dir/$q
git add _result/_$dir/$q/$sendfile
git commit -m "$dir $q"
cp -i _template/$sendfile ./$sendfile

