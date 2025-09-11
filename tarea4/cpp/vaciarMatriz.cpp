#include <iostream>
#include <vector>

using namespace std;

int main(int argc, char* argv[]) {
    vector<vector<int>> matriz = {
        {1, 2, 3},
        {4, 5, 6},
        {7, 8, 9}
    };
    vector<int> arreglo;

    if (argc == 1) {
        for (auto &fila : matriz) {
            cout << "[";
            for (size_t i = 0; i < fila.size(); i++) {
                cout << fila[i] << (i < fila.size() - 1 ? ", " : "");
            }
            cout << "] ";
        }
        cout << endl;
    } else {
        string comando = argv[1];
        if (comando == "filas") {
            for (auto &fila : matriz) {
                for (int elemento : fila) {
                    arreglo.push_back(elemento);
                }
            }
        } else if (comando == "columnas") {
            for (size_t i = 0; i < matriz[0].size(); i++) {
                for (size_t j = 0; j < matriz.size(); j++) {
                    arreglo.push_back(matriz[j][i]);
                }
            }
        }

        for (size_t i = 0; i < arreglo.size(); i++) {
            cout << arreglo[i] << (i < arreglo.size() - 1 ? " " : "\n");
        }
    }
}
