#include <iostream>
#include <string>
using namespace std;

class Clase {
public:
    string materia;
    string maestro;

    Clase(string materia, string maestro) {
        this->materia = materia;
        this->maestro = maestro;
    }
};

int main() {
    Clase clases[] = {
        Clase("Ingenieria de software", "Diana"),
        Clase("Fisica", "Angel"),
        Clase("Lucha libre", "Shrek")
    };

    for (Clase c : clases) {
        cout << "Clase(" << c.materia << ", " << c.maestro << ")" << endl;
    }

    cout << endl;
    return 0;
}