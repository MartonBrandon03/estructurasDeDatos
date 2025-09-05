import typer

app = typer.Typer(invoke_without_command = True)

arreglo : list[int] = [20,30,40,50,60,70]

@app.callback()
def main(ctx: typer.Context):
    if ctx.invoked_subcommand is None:
        print(arreglo)

@app.command()
def indice(index : int):
    if index <= len(arreglo) and index > 0:
        print("En la posicion "+str(index)+" del arreglo se encuentra el valor: "+str(arreglo[index - 1])+".")
    else:
        print("Indice invalido.")
        print("Prueba usar numeros del 1 al "+str(len(arreglo))+".")

@app.command()
def recorrido():
    suma = 0
    for i in range(0,len(arreglo)):
        print("En la posicion "+ str(i + 1) + " del arreglo se encuentra el valor: " + str(arreglo[i]) + ".")
        suma += arreglo[i]
    print("Sumatoria: " + str(suma) + ".")

@app.command()
def reversa():
    suma = 0
    for i in range(len(arreglo) - 1, -1, -1):
        print("En la posicion "+ str(i + 1) + " del arreglo se encuentra el valor: " + str(arreglo[i]) + ".")
        suma += arreglo[i]
    print("Sumatoria: " + str(suma) + ".")

@app.command()
def buscar(valor: int):
    booleano: bool = False
    for i in range(0,len(arreglo)):
        if arreglo[i] == valor:
            print("El valor " + str(valor) + " estaba en la posicion " + str(i + 1) + " del arreglo.")
            booleano = True
    if booleano == False:
        print("No se encontro un elemento con el valor requerido.")

if __name__ == "__main__":
    app()
