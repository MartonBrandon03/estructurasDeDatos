
class Perro {
    String raza;
    String nombre;

    public Perro(String raza, String nombre) {
        this.raza = raza;
        this.nombre = nombre;
    }

    @Override
    public String toString() {
        return "Perro(" + raza + ", " + nombre + ")";
    }

    public static void main(String[] args) {
        Perro[] arreglo = {
            new Perro("Labrador", "Vyka"),
            new Perro("Pastor Aleman", "Willy"),
            new Perro("Pitbull cruza Boxer", "Princesa")
        };

        for (Perro p : arreglo) {
            System.out.println(p);
        }
        System.out.println();
    }
}
