char[,,] tableros = new char[2, 5, 5];
char[,,] dianas = new char[2, 5, 5];
int victoria = 0;
void mostrarTablero(int nJugador,char[,,] tabla)
{
    Console.Write($" - - JUGADOR {nJugador} - -\n\n     ");
    int cuenta = 0;
    foreach (char c in tabla)
    {
        if (nJugador == 1)
        {
            cuenta++;
            if (cuenta <= 25)
            {
                Console.Write(c + " ");
                if (cuenta % 5 == 0 && cuenta != 0)
                {
                    Console.Write("\n     ");
                }
            }
            else
            {
                break;
            }
        }
        else if (nJugador == 2)
        {
            cuenta++;
            if (cuenta > 25)
            {
                Console.Write(c + " ");
                if (cuenta % 5 == 0 && cuenta != 0)
                {
                    Console.Write("\n     ");
                }
            }
        }
    }
    Console.Write("\n");
}
int obtenerPosicion(string or,int dim)
{
    int pos;
    Console.Write($"Indica la posicion {or}, entre 1 y {6 - dim}: ");
    pos = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
    while (pos < 1 || pos > 6 - dim)
    {
        Console.Write($"Posicion invalida, por favor colocalo entre el 1 y {6 - dim}: ");
        pos = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
    }
    return pos;
}
void ponerBarco(int largo, int ancho, int nJugador)
{
    int posX = 0, posY = 0;
    string or;
    Console.Write($"Este barco mide {largo} casillas de largo y {ancho} casillas de ancho.\n\nHorizontal o vertical?(v o h): ");
    while (true)
    {
        bool disponible = true;
        or = Console.ReadLine();
        Console.WriteLine();
        if (or[0] == 'h' || or[0] == 'H')
        {
            posX = obtenerPosicion("horizontal", largo);
            posY = obtenerPosicion("vertical", ancho);
            for (int j = 0; j < 5; j++)
            {
                for (int k = 0; k < 5; k++)
                {
                    if (j + 1 - posY >= 0 && j + 1 - posY <= ancho - 1)
                    {
                        if (k + 1 - posX >= 0 && k + 1 - posX <= largo - 1)
                        {
                            if (tableros[nJugador-1, j, k] == 'o')
                            {
                                disponible = false;
                            }
                        }
                    }
                }
            }
            if (!disponible)
            {
                mostrarTablero(nJugador,tableros);
                Console.Write("Entrada invalida, ya hay un barco ahi, por favor captura una orientacion valida (v o h): ");
                continue;
            }
            for (int j = 0; j < 5; j++)
            {
                for (int k = 0; k < 5; k++)
                {
                    if (j + 1 - posY >= 0 && j + 1 - posY <= ancho - 1)
                    {
                        if (k + 1 - posX >= 0 && k + 1 - posX <= largo - 1)
                        {
                            tableros[nJugador-1, j, k] = 'o';
                        }
                    }
                }
            }
            break;
        }
        else if (or[0] == 'v' || or[0] == 'V')
        {
            posX = obtenerPosicion("horizontal", ancho);
            posY = obtenerPosicion("vertical", largo);
            for (int j = 0; j < 5; j++)
            {
                for (int k = 0; k < 5; k++)
                {
                    if (j + 1 - posY >= 0 && j + 1 - posY <= largo - 1)
                    {
                        if (k + 1 - posX >= 0 && k + 1 - posX <= ancho - 1)
                        {
                            if (tableros[nJugador-1, j, k] == 'o')
                            {
                                disponible = false;
                            }
                        }
                    }
                }
            }
            if (!disponible)
            {
                mostrarTablero(nJugador,tableros);
                Console.Write("Entrada invalida, ya hay un barco ahi, por favor captura una orientacion valida (v o h): ");
                continue;
            }
            for (int j = 0; j < 5; j++)
            {
                for (int k = 0; k < 5; k++)
                {
                    if (j + 1 - posY >= 0 && j + 1 - posY <= largo - 1)
                    {
                        if (k + 1 - posX >= 0 && k + 1 - posX <= ancho - 1)
                        {
                            tableros[nJugador-1, j, k] = 'o';
                        }
                    }
                }
            }
            break;
        }
        Console.Write("Entrada invalida, por favor captura una orientacion valida (v o h): ");
    }
}
int checarDerrota(int nJugador)
{
    bool vivo = false;
    for (int j = 0; j < 5; j++)
    {
        for (int k = 0; k < 5; k++)
        {
            if (tableros[nJugador-1, j, k] == 'o')
            {
                vivo = true;
            }
        }
    }
    if (vivo == false)
    {
        return nJugador;
    }
    return 0;
}
for (int i = 0; i < 2; i++) //aqui se llenan los 4 tableros
{
    for (int j = 0; j < 5; j++)
    {
        for (int k = 0; k < 5; k++)
        {
            tableros[i, j, k] = '.';
            dianas[i, j, k] = '.';
        }
    }
}
Console.WriteLine("\n- - - -  BATALLA NAVAL  - - - -\n\nJugador 1, coloca tus barcos!\n");

mostrarTablero(1, tableros);
ponerBarco(2, 2, 1);
mostrarTablero(1,tableros);
for (int i = 3; i > 0; i--)
{
    ponerBarco(i, 1, 1);
    mostrarTablero(1,tableros);
}
Console.ReadKey();
Console.Clear();

Console.WriteLine("Ahora le toca al jugador 2, coloca tus barcos!");
ponerBarco(2, 2, 2);
mostrarTablero(2,tableros);
for (int i = 3; i > 0; i--)
{
    ponerBarco(i, 1, 2);
    mostrarTablero(2,tableros);
}
Console.ReadKey();
Console.Clear();
while (true)//loop del juego
{
    for (int i = 1; i < 3; i++)
    {
        if (checarDerrota(i) != 0)
        {
            victoria = 1;
            Console.WriteLine($"Jugador {i}, perdiste!");
            Console.ReadKey();
            Console.Clear();
            continue;
        }
        else if (victoria == 1)
        {
            Console.WriteLine($"Jugador {i}, ganaste!");
            Console.ReadKey();
            Console.Clear();
            break;
        }
        int x = 0;
        int y = 0;
        Console.WriteLine("     Tu tablero");
        mostrarTablero(i, tableros);
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("     Tu diana");
        mostrarTablero(i, dianas);
        while (true)
        {
            Console.Write("Posicion horizontal: ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Posicion vertical: ");
            y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            if (!(x < 1 || x > 5 || y < 1 || y > 5))
            {
                break;
            }
            Console.WriteLine("Coordenadas invalidas, ingresa numeros del 1 al 5 por favor.");
        }
        dianas[i - 1, y - 1, x - 1] = 'X';
        if (i == 1)
        {
            if (tableros[i, y - 1, x - 1] == 'o')
            {
                Console.WriteLine("Le diste!");
            }
            tableros[i, y - 1, x - 1] = 'X';
        }
        else
        {
            if (tableros[0, y - 1, x - 1] == 'o')
            {
                Console.WriteLine("Le diste!");
            }
            tableros[0, y - 1, x - 1] = 'X';
        }
        mostrarTablero(i, dianas);
        Console.ReadKey();
        Console.Clear();
    }
    if (victoria == 1)
    {
        break;
    }
}