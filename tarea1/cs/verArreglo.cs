using System;

class verArreglo
{
    static void Main(string[] args)
    {
        int[] arreglo = { 20, 30, 40, 50, 60, 70 };
        if (args.Length == 0)
        {
            Console.Write("[");
            for (int i = 0; i < arreglo.Length; i++)
            {
                Console.Write(arreglo[i]);
                if (i < arreglo.Length - 1)
                    Console.Write(", ");
            }
            Console.WriteLine("]");
        }
        else
        {
            switch (args[0])
            {
                case "recorrido":
                    {
                        int suma = 0;
                        for (int i = 0; i < arreglo.Length; i++)
                        {
                            Console.WriteLine($"En la posicion {i + 1} del arreglo se encuentra el valor: {arreglo[i]}.");
                            suma += arreglo[i];
                        }
                        Console.WriteLine($"La sumatoria es: {suma}.");
                        break;
                    }
                case "reversa":
                    {
                        int suma = 0;
                        for (int i = arreglo.Length - 1; i >= 0; i--)

                        {
                            Console.WriteLine($"En la posicion {i + 1} del arreglo se encuentra el valor: {arreglo[i]}.");
                            suma += arreglo[i];
                        }
                        Console.WriteLine($"La sumatoria es: {suma}.");
                        break;
                    }
                case "indice":
                    if (args.Length == 1)
                    {
                        Console.WriteLine("Por favor introduzca un indice.");
                    }
                    else if (int.Parse(args[1]) < 1 || int.Parse(args[1]) > arreglo.Length)
                    {
                        Console.WriteLine("Indice invalido.");
                        Console.WriteLine($"Prueba con un valor del 1 al {arreglo.Length}.");
                    }
                    else
                    {
                        Console.WriteLine($"En la posicion {args[1]} del arreglo se encuentra el valor {arreglo[int.Parse(args[1]) - 1]}.");
                    }
                    break;
                case "buscar":
                    if (args.Length == 1)
                    {
                        Console.WriteLine("Por favor introduzca un elemento a buscar.");
                    }
                    else
                    {
                        for (int i = 0; i < arreglo.Length; i++)
                        {
                            if (arreglo[i] == int.Parse(args[1]))
                            {
                                Console.WriteLine($"El valor se encontro en el indice {i + 1}.");
                                break;
                            } else if (i == arreglo.Length - 1)
                            {
                                Console.WriteLine("El valor no se encontro en el arreglo.");
                            }
                        }
                    }
                    break;
            }
        }
    }
}