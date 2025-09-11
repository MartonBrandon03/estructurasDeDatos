using System;
using System.Collections.Generic;

class CLI {
    static void Main(string[] args) {
        int[,] matriz = {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };

        List<int> arreglo = new List<int>();

        if (args.Length == 0) {
            for (int i = 0; i < matriz.GetLength(0); i++) {
                Console.Write("[");
                for (int j = 0; j < matriz.GetLength(1); j++) {
                    Console.Write(matriz[i, j] + (j < matriz.GetLength(1) - 1 ? ", " : ""));
                }
                Console.Write("] ");
            }
            Console.WriteLine();
        } else {
            switch (args[0]) {
                case "filas": {
                    for (int i = 0; i < matriz.GetLength(0); i++) {
                        for (int j = 0; j < matriz.GetLength(1); j++) {
                            arreglo.Add(matriz[i, j]);
                        }
                    }
                    Console.WriteLine(string.Join(" ", arreglo));
                    break;
                }
                case "columnas": {
                    for (int i = 0; i < matriz.GetLength(1); i++) {
                        for (int j = 0; j < matriz.GetLength(0); j++) {
                            arreglo.Add(matriz[j, i]);
                        }
                    }
                    Console.WriteLine(string.Join(" ", arreglo));
                    break;
                }
            }
        }
    }
}
