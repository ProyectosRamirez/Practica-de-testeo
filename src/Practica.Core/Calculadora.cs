namespace Practica.Core;

public class Calculadora
{
    public int Sumar(int a, int b) => a + b;

    public int Restar(int a, int b) => a - b;

    public int Multiplicar(int a, int b) => a * b;

    public double Dividir(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException("No se puede dividir entre cero.");

        return a / b;
    }

    public bool EsPar(int numero) => numero % 2 == 0;
}
