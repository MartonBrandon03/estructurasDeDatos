#!/usr/bin/env python3
import typer

arreglo: list[int] = [0, 1, 2, 3, 4, 5]

app = typer.Typer(invoke_without_command= True)

@app.callback()
def main(ctx: typer.Context):
    if ctx.invoked_subcommand is None:
        print(arreglo)

@app.command()
def insertar(valor: int, indice: int):
    arreglo.insert(indice, valor)
    print(f"El nuevo arreglo es {arreglo}")


@app.command()
def extraer(indice: int):
    arreglo.pop(indice)
    print(f"El nuevo arreglo es {arreglo}")


if __name__ == "__main__":
    app()