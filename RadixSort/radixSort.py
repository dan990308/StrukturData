arrayLenght = int(input("Panjang : "))
to_sort = []
awal = []
for i in range(arrayLenght):
  inp = int(input("Array Ke  "+str(i)+": "))
  to_sort.append(inp)
  awal.append(inp)



Division = 1
Mod = 10
start = True
iterasi = 0
maxInt = max(to_sort)
digits = len(str(maxInt))
for i in range(digits):  
  bucket = [[], [], [], [], [], [], [], [], [], []]
  post = ["satuan","puluhan","ratusan","ribuan","Puluhan Ribu","Ratusan Ribu"
          ]
 
  for num in to_sort:
    position = num % Mod // Division

    if digits == 1:
      bucket[position].append(num)
    elif digits == 2:
      bucket[position].append("{:02d}".format(num))
    elif digits == 3:
      bucket[position].append("{:03d}".format(num))
    elif digits == 4:
      bucket[position].append("{:04d}".format(num))
    elif digits == 5:
      bucket[position].append("{:05d}".format(num))
    elif digits == 6:
      bucket[position].append("{:06d}".format(num))
    elif digits == 7:
      bucket[position].append("{:07d}".format(num))
      
    
  
  print("Iterasi",iterasi)
  print(post[iterasi])
  for i in range(len(bucket)):
    print(i, bucket[i])

  
  print(bucket)
  iterasi += 1
  to_sort = []
  for bucknum in bucket:
    for bucknestednum in bucknum:
      to_sort.append(int(bucknestednum))
  Mod = Mod * 10
  Division = Division * 10

print("Sebelum di sort",awal)  
print("Sesudah di sort",to_sort)
