#include <stdio.h>
#include <stdlib.h>
#include <cstring>

int arreglo[] = {20, 30, 40, 50, 60, 70};

int main(int argc, char* argv[])
{
    if (argc == 1)
    {
        int n = sizeof(arreglo) / sizeof(arreglo[0]);
        printf("[");
        for (int i = 0; i < n; i++)
        {
            if (i == n - 1)
                printf("%d]", arreglo[i]);
            else
                printf("%d, ", arreglo[i]);
        }
        printf("\n");
    }
    else if(strcmp(argv[1], "recorrido") == 0)
    {
        int suma = 0;
        int n = sizeof(arreglo) / sizeof(arreglo[0]);
        for (int i = 0; i < n; i++)
        {
            printf("En la posicion %d del arreglo se encuentra el valor %d\n", i + 1, arreglo[i]);
            suma += arreglo[i];
        }
        printf("La sumatoria es: %d\n", suma);
    }
    else if (strcmp(argv[1], "reversa") == 0)
    {
        int suma = 0;
        int n = sizeof(arreglo) / sizeof(arreglo[0]);
        for (int i = n - 1; i >= 0; i--)
        {
            printf("En la posicion %d del arreglo se encuentra el valor %d\n", i + 1, arreglo[i]);
            suma += arreglo[i];
        }
        printf("La sumatoria es: %d\n", suma);
    }
    else if (strcmp(argv[1], "indice") == 0)
    {
        if (argc == 2)
        {
            printf("Por favor introduzca un indice.\n");
        } 
        else if (atoi(argv[2]) < 1 || atoi(argv[2]) > sizeof(arreglo) / sizeof(arreglo[0]))
        {
            printf("Indice invalido.\n");
            printf("Prueba con un valor del 1 al %ld.\n", sizeof(arreglo) / sizeof(arreglo[0]));
        } 
        else 
        {
            printf("En el indice %s del arreglo se encuentra el valor %d.\n", argv[2], arreglo[atoi(argv[2]) - 1]);
        }
    }
    else if (strcmp(argv[1], "buscar") == 0)
    {
        if (argc == 2)
        {
            printf("Por favor introduzca un valor a buscar.\n");
        }
        else
        {
            int n = sizeof(arreglo) / sizeof(arreglo[0]);
            for (int i = 0; i < n; i++)
            {
                if (atoi(argv[2]) == arreglo[i])
                {
                    printf("El valor se encontro en el indice %d.\n", i + 1);
                    break;
                }
                else if (i == n - 1)
                {
                 printf("El valor no se encontro en el elemento.\n");   
                }
            }                
        }
    }
    return 0;
}