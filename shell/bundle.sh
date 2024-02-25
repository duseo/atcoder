touch ./Submit.cs
dotnet-combine single-file ./Library -o "./tmp.cs"
cat tmp.cs | grep using >> Submit.cs
cat Program.cs grep -v using Dumpify >> Submit.cs
cat tmp.cs | grep -v using >> Submit.cs
rm -rf ./tmp.cs
