#!/usr/bin/env python3
import sys

arreglo = [40,20,60,50,30,10]


def insertionSort(arr: list):
    narr = arr
    for i in range(len(arr)):
        temp = int(arr[i])
        j = i - 1
        while(j >= 0 and temp < narr[j]):
            narr[j + 1] = narr[j]
            j -= 1
        narr[j + 1] = temp
    print(arr,narr)

def main():
    if len(sys.argv[1:]) == 0:
        insertionSort(arreglo)
    else:
        insertionSort(sys.argv[1:])

if __name__ == "__main__":
    main()