touch ./Submit.cs
cat Library.cs | grep using >> Submit.cs
cat Program.cs >> Submit.cs
cat Library.cs | grep -v using >> Submit.cs
