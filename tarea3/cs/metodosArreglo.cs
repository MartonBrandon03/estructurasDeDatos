using System;

class metodosArreglo {
    static void Main(string[] args) {
        int[] arreglo = {0,1,2,3,4,5};

        if(args.Length==0){
            Console.WriteLine(string.Join(" ", arreglo));
            return;
        }

        if(args[0]=="insertar" && args.Length>=3){
            int i = int.Parse(args[2]);
            if(i>=0 && i<=arreglo.Length){
                int[] nuevo = new int[arreglo.Length+1];
                for(int j=0,k=0;j<nuevo.Length;j++) nuevo[j] = (j==i)? int.Parse(args[1]) : arreglo[k++];
                arreglo = nuevo;
            }
        } else if(args[0]=="extraer" && args.Length>=2){
            int i = int.Parse(args[1]);
            if(i>=0 && i<arreglo.Length){
                int[] nuevo = new int[arreglo.Length-1];
                for(int j=0,k=0;j<arreglo.Length;j++) if(j!=i) nuevo[k++] = arreglo[j];
                arreglo = nuevo;
            }
        }

        Console.WriteLine(string.Join(" ", arreglo));
    }
}
