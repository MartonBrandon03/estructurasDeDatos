#!/usr/bin/env node
const ARGS = process.argv.slice(2)

arreglo = [40,20,60,50,30,10]
let narr = []

let insertionSort = (bol, arr) => {
    for (let i = 0; i < arr.length; i++) {
        let j = i - 1
        let temp = +arr[i]
        while(j >= 0 && temp < narr[j]) 
            {
            narr[j+1] = narr[j]
            j--
            }
        narr[j + 1] = temp
        }
    console.log(arr,narr)
}

if (ARGS.length == 0)
{
    insertionSort(true,arreglo)
}
else
{
    insertionSort(true,ARGS)
}