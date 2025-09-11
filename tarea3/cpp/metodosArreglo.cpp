#include <iostream>
#include <algorithm>
using namespace std;

int main(int argc, char* argv[]) {
    int arreglo[] = {0,1,2,3,4,5};
    int n = sizeof(arreglo)/sizeof(arreglo[0]);

    if(argc == 1){
        for(int i=0;i<n;i++) cout << arreglo[i] << " ";
        cout << endl;
        return 0;
    }

    string comando = argv[1];
    if(comando=="insertar" && argc>=4){
        int valor = stoi(argv[2]), indice = stoi(argv[3]);
        if(indice>=0 && indice<=n){
            int nuevo[n+1];
            for(int i=0,j=0;i<=n;i++) nuevo[i] = (i==indice)? valor : arreglo[j++];
            copy(nuevo,nuevo+n+1,arreglo);
            n++;
        }
    } else if(comando=="extraer" && argc>=3){
        int indice = stoi(argv[2]);
        if(indice>=0 && indice<n){
            int nuevo[n-1];
            for(int i=0,j=0;i<n;i++) if(i!=indice) nuevo[j++] = arreglo[i];
            copy(nuevo,nuevo+n-1,arreglo);
            n--;
        }
    }

    for(int i=0;i<n;i++) cout << arreglo[i] << " ";
    cout << endl;
}
