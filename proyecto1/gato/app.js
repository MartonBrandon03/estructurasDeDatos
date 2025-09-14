const grid = document.getElementsByClassName("grid")[0]
const reiniciar = document.getElementsByClassName("reiniciar")[0]
const salida = document.getElementsByClassName("salida")[0]
let bool = true, empate = []
let celdas =  [
    [],
    [],
    []
]
let cuenta = 0, contador = 0
Array.from(document.getElementsByClassName("celda")).forEach(div => {
    if (cuenta == 3){
        cuenta = 0
        contador++
    } 
    celdas[contador].push(div)
    cuenta++
});
let checar = (fila,col) => {
    if (celdas[fila][0].innerText != "" && celdas[fila][0].innerText == celdas[fila][1].innerText && celdas[fila][0].innerText  == celdas[fila][2].innerText) return true
    if (celdas[0][col].innerText != "" && celdas[0][col].innerText == celdas[1][col].innerText && celdas[0][col].innerText == celdas[2][col].innerText) return true
    if (fila == col || fila == 2 && col == 0 || fila == 0 && col == 2) {
        if (celdas[0][0].innerText != "" && celdas[0][0].innerText == celdas[1][1].innerText && celdas[0][0].innerText == celdas[2][2].innerText) return true
        if (celdas[0][2].innerText != "" && celdas[0][2].innerText == celdas[1][1].innerText && celdas[0][2].innerText== celdas[2][0].innerText) return true
    }
    return false
}
reiniciar.addEventListener("click",e =>{
    celdas.forEach(array => {
        array.forEach(el => {
            if (el.classList.contains("terminado")) el.classList.toggle("terminado")
            el.innerText = ""
        })
    })
    salida.innerText = "🐈"
})
grid.addEventListener("click",(e) => {
    if (e.target.innerText == "" && e.target != grid && !e.target.classList.contains("terminado")) {
        if(bool) {
            e.target.innerText = "O"
            bool = !bool
        } else {
            e.target.innerText = "X"
            bool = !bool
        }
        let fila = celdas.indexOf(celdas.find(arr => arr.includes(e.target)))
        let columna = celdas[fila].indexOf(e.target)
        if (checar(fila,columna) == true) {
            if (bool) salida.innerText = "Gano X!"
            else salida.innerText = "Gano O"
            celdas.forEach(array => {
                array.forEach(el => {
                    if (el.innerText == "") el.classList.toggle("terminado")
                })
            });
        }
        celdas.forEach(array => {
            array.forEach(el => {
                if (el.innerText != "") empate.push("+")
                else empate.push("-")
            })
        });
        if (empate.indexOf("-") == -1) salida.innerText = "Empate!"
        empate = []
        }
})