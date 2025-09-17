#include <iostream>
#include <vector>
using namespace std;

const int FILAS = 6;
const int COLUMNAS = 7;

void imprimir(const vector<vector<char>>& tablero) {
    cout << "\n  1 2 3 4 5 6 7\n";
    for (int f = 0; f < FILAS; f++) {
        cout << f+1 << " ";
        for (int c = 0; c < COLUMNAS; c++) {
            cout << (tablero[f][c] == ' ' ? '.' : tablero[f][c]);
            if (c < COLUMNAS-1) cout << " ";
        }
        cout << "\n";
    }
    cout << "\n";
}

bool columnaLlena(const vector<vector<char>>& tablero, int col) {
    return tablero[0][col] != ' ';
}

bool ponerFicha(vector<vector<char>>& tablero, int col, char ficha) {
    if (col < 0 || col >= COLUMNAS || columnaLlena(tablero, col)) return false;
    for (int f = FILAS-1; f >= 0; f--) {
        if (tablero[f][col] == ' ') {
            tablero[f][col] = ficha;
            return true;
        }
    }
    return false;
}

bool cuatroEnLinea(const vector<vector<char>>& tablero, char ficha) {
    for (int f = 0; f < FILAS; f++) {
        for (int c = 0; c < COLUMNAS; c++) {
            if (tablero[f][c] != ficha) continue;
            if (c + 3 < COLUMNAS &&
                tablero[f][c+1] == ficha && tablero[f][c+2] == ficha && tablero[f][c+3] == ficha)
                return true;
            if (f + 3 < FILAS &&
                tablero[f+1][c] == ficha && tablero[f+2][c] == ficha && tablero[f+3][c] == ficha)
                return true;
            if (f + 3 < FILAS && c + 3 < COLUMNAS &&
                tablero[f+1][c+1] == ficha && tablero[f+2][c+2] == ficha && tablero[f+3][c+3] == ficha)
                return true;
            if (f + 3 < FILAS && c - 3 >= 0 &&
                tablero[f+1][c-1] == ficha && tablero[f+2][c-2] == ficha && tablero[f+3][c-3] == ficha)
                return true;
        }
    }
    return false;
}

bool tableroLleno(const vector<vector<char>>& tablero) {
    for (int c = 0; c < COLUMNAS; c++) {
        if (!columnaLlena(tablero, c)) return false;
    }
    return true;
}

int main() {
    vector<vector<char>> tablero(FILAS, vector<char>(COLUMNAS, ' '));
    char jugador = 'X';

    while (true) {
        imprimir(tablero);
        cout << "Turno del jugador " << jugador << ". Elige columna (1-7): ";
        int col;
        if (!(cin >> col)) {
            cin.clear();
            string basura;
            getline(cin, basura);
            cout << "Entrada invalida. Intenta de nuevo.\n";
            continue;
        }
        col--;

        if (!ponerFicha(tablero, col, jugador)) {
            cout << "Columna no valida o llena. Intenta otra.\n";
            continue;
        }

        if (cuatroEnLinea(tablero, jugador)) {
            imprimir(tablero);
            cout << "Jugador " << jugador << " gana!\n";
            break;
        }

        if (tableroLleno(tablero)) {
            imprimir(tablero);
            cout << "Empate. Tablero lleno.\n";
            break;
        }

        jugador = (jugador == 'X') ? 'O' : 'X';
    }

    cout << "Fin del juego.\n";
    return 0;
}
