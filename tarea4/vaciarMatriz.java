import java.util.*;

public class vaciarMatriz {
    public static void main(String[] args) {
        int[][] matriz = {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };

        ArrayList<Integer> arreglo = new ArrayList<>();

        if (args.length == 0) {
            System.out.println(Arrays.deepToString(matriz));
        } else {
            switch (args[0]) {
                case "filas": {
                    for (int[] fila : matriz) {
                        for (int elemento : fila) {
                            arreglo.add(elemento);
                        }
                    }
                    System.out.println(arreglo);
                    break;
                }
                case "columnas": {
                    for (int i = 0; i < matriz[0].length; i++) {
                        for (int j = 0; j < matriz.length; j++) {
                            arreglo.add(matriz[j][i]);
                        }
                    }
                    System.out.println(arreglo);
                    break;
                }
                default:
                    System.out.println("Comando no reconocido");
            }
        }
    }
}