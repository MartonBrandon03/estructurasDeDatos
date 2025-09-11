#!/usr/bin/env node

let arreglo = [0, 1, 2, 3, 4, 5];

const args = process.argv.slice(2);

if (args.length === 0) {
  console.log(arreglo);
} else {
  const comando = args[0];

  if (comando === "insertar") {
    arreglo.splice(+args[2], 0, +args[1]);
    console.log(`El nuevo arreglo es [${arreglo.join(", ")}]`);
  }

  else if (comando === "extraer") {
    arreglo.splice(+args[1], 1);
    console.log(`El nuevo arreglo es [${arreglo.join(", ")}]`);
  }
}
