#!/usr/bin/env node

let matriz = [
    [1, 2, 3],
    [4, 5, 6],
    [7, 8, 9]
];

let arreglo = [];
let args = process.argv.slice(2);

if (args.length === 0) {
    console.log(matriz);
} else {
    switch (args[0]) {
        case "filas": {
            matriz.forEach(fila => fila.forEach(e => arreglo.push(e)));
            console.log(arreglo);
            break;
        }
        case "columnas": {
            for (let i = 0; i < matriz[0].length; i++) {
                for (let j = 0; j < matriz.length; j++) {
                    arreglo.push(matriz[j][i]);
                }
            }
            console.log(arreglo);
            break;
        }
    }
}
