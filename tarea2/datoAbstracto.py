#!/usr/bin/env python3
class Persona:
    def __init__(self, nombre, edad, altura):
        self.nombre = nombre
        self.edad = edad
        self.altura = altura

    def __repr__(self):
        return f"Persona({self.nombre}, {self.edad}, {self.altura})"

arreglo : list[Persona]= [
    Persona("Martin", 22, 1.69),
    Persona("Luis", 21, 1.72),
    Persona("Karla", 15, 1.70)
]

def main():
    for persona in arreglo:
        print(persona)
    print()

if __name__ == "__main__":
    main()