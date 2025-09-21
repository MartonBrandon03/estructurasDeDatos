#include <iostream>
#include <vector>
using namespace std;

void sort(vector<int>& arr) {
    for (int i = 0; i < arr.size(); i++) {
        int temp = arr[i];
        int j = i - 1;
        while (j >= 0 && temp < arr[j]) {
            arr[j + 1] = arr[j];
            j--;
        }
        arr[j + 1] = temp;
    }
}

int main() {
    vector<int> arreglo = {20, 50, 60, 30, 40, 10};
    sort(arreglo);
    for (int i = 0; i < arreglo.size(); i++)
        cout << arreglo[i] << " ";
    cout << endl;
    return 0;
}
