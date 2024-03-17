from typing import Counter

def nc2(x):
    return (x * (x-1))/2

c = Counter(input())
res = nc2(c.total())

dup = False
for x in c.values():
    res -= nc2(x)  
    if x > 1:
        dup = True

if dup:
    res+=1

print(int(res))



