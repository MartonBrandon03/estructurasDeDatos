import java.util.Arrays;

public class metodosArreglo {
    public static void main(String[] args) {
        int[] arreglo = {0, 1, 2, 3, 4, 5};

        if(args.length == 0) {
            System.out.println(Arrays.toString(arreglo));
            return;
        }
        switch (args[0]) {
            case "insertar": {
                if(args.length < 3){
                    System.out.println("Uso: insertar <valor> <indice>");
                    break;
                }
                int valor = Integer.parseInt(args[1]);
                int indice = Integer.parseInt(args[2]);
                if(indice < 0 || indice > arreglo.length){
                    System.out.println("Indice fuera de rango.");
                    break;
                }
                int[] nuevo = new int[arreglo.length + 1];
                for(int i = 0, j = 0; i < nuevo.length; i++){
                    if(i == indice){
                        nuevo[i] = valor;
                    } else {
                        nuevo[i] = arreglo[j++];
                    }
                }
                arreglo = nuevo;
                System.out.println("El nuevo arreglo es " + Arrays.toString(arreglo));
                break;
            }
            case "extraer": {
                if(args.length < 2){
                    System.out.println("Uso: extraer <indice>");
                    break;
                }
                int indice = Integer.parseInt(args[1]);
                if(indice < 0 || indice >= arreglo.length){
                    System.out.println("Indice fuera de rango.");
                    break;
                }
                int[] nuevo = new int[arreglo.length - 1];
                for(int i = 0, j = 0; i < arreglo.length; i++){
                    if(i != indice){
                        nuevo[j++] = arreglo[i];
                    }
                }
                arreglo = nuevo;
                System.out.println("El nuevo arreglo es " + Arrays.toString(arreglo));
                break;
            }
        }
    }
}
