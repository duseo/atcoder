touch ./Submit.cs
cat Library/CollectionExtensions.cs | grep using >> Submit.cs
cat Library/Graphs.cs | grep using >> Submit.cs
cat Library/IOManager.cs | grep using >> Submit.cs
cat Library/ModularArithmetic.cs | grep using >> Submit.cs
cat Library/IOracle.cs | grep using >> Submit.cs
cat Library/SegmentTree.cs | grep using >> Submit.cs
cat Library/PriorityQueue.cs | grep using >> Submit.cs
cat Library/BinarySearch.cs | grep using >> Submit.cs
cat Program.cs >> Submit.cs
echo "namespace Library {" >> Submit.cs
cat Library/CollectionExtensions.cs | grep -v using | grep -v namespace >> Submit.cs
cat Library/Graphs.cs | grep -v using | grep -v namespace >> Submit.cs
cat Library/IOManager.cs | grep -v using | grep -v namespace >> Submit.cs
cat Library/ModularArithmetic.cs | grep -v using | grep -v namespace >> Submit.cs
cat Library/IOracle.cs | grep -v using | grep -v namespace >> Submit.cs
cat Library/SegmentTree.cs | grep -v using | grep -v namespace >> Submit.cs
cat Library/PriorityQueue.cs | grep -v using | grep -v namespace >> Submit.cs
cat Library/BinarySearch.cs | grep -v using | grep -v namespace >> Submit.cs
echo "}" >> Submit.cs
