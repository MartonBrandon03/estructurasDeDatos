import java.util.Arrays;
public class verArreglo {
    public static void main(String[] args) {
        int[] arreglo = {20,30,40,50,60,70};
        if(args.length == 0) {
            System.out.println(Arrays.toString(arreglo));
            return;
        }
        switch (args[0]) {
            case "recorrido": 
            {
                int suma = 0;
                for(int i = 0; i < arreglo.length; i++) {
                    System.out.println("En la posicion " + (i + 1) + " del arreglo se encuentra el valor: " + arreglo[i] + ".");
                    suma += arreglo[i];
                }
                System.out.println("La sumatoria es: " + suma + ".");
            break;
            }
            case "reversa": {
                int suma = 0;
                for(int i = arreglo.length - 1; i >= 0; i--) {
                    System.out.println("En la posicion " + (i + 1) + " del arreglo se encuentra el valor: " + arreglo[i] + ".");
                    suma += arreglo[i];
                }
                System.out.println("La sumatoria es: " + suma + ".");
            break;
            }
            case ("indice"):
                if(args.length == 1){
                    System.out.println("Por favor introduzca un indice.");
                } else if (Integer.parseInt(args[1]) > 0 && Integer.parseInt(args[1]) <= arreglo.length) {
                    System.out.println("En la posicion " + args[1] + " del arreglo se encuentra el valor: " + arreglo[Integer.parseInt(args[1]) - 1] + ".");
                } else {
                    System.out.println("Indice invalido.");
                    System.out.println("Prueba con un valor del 1 al " + arreglo.length + ".");
                }
            break;
            case "buscar":
                if (args.length == 1) {
                    System.out.println("Por favor introduzca un valor a buscar.");
                } else {
                int indice = -1;
                for (int i = 0; i < arreglo.length; i++) {
                    if (arreglo[i] == Integer.parseInt(args[1])){
                        indice = i + 1;
                    }
                }
                if (indice == -1 && args.length == 2){
                        System.out.println("El valor no se encontro en el arreglo.");
                    } else {
                        System.out.println("El valor se encontro en el indice " + indice + ".");
                    }
                }
            break;
        }
    }
}