#!/usr/bin/env python3
import typer

app = typer.Typer(invoke_without_command= True)

matriz = [
    [1,2,3],
    [4,5,6],
    [7,8,9],
]

arreglo = []

@app.callback()
def main(ctx: typer.Context):
    if ctx.invoked_subcommand is None:
        print(matriz)

@app.command()
def filas():
    for fila in matriz:
        for elemento in fila:
            arreglo.append(elemento)
    print(arreglo)

@app.command()
def columnas():
    for i in range(len(matriz)):
        for j in range(len(matriz[i])):
            arreglo.append(matriz[j][i])
    print(arreglo)

if __name__ == "__main__":
    app()