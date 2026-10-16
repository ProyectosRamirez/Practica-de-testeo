using Practica.Core;

namespace Practica.Tests;

[Trait("Categoria", "Calculadora")]
public class CalculadoraTests
{
    private readonly Calculadora _calc;

    // xUnit crea una instancia NUEVA de la clase por cada prueba:
    // el constructor sirve como "Arrange" compartido.
    public CalculadoraTests()
    {
        _calc = new Calculadora();
    }

    [Fact]
    public void Sumar_DosNumeros_RetornaLaSuma()
    {
        // Arrange
        int a = 2, b = 3;

        // Act
        int resultado = _calc.Sumar(a, b);

        // Assert
        Assert.Equal(5, resultado);
    }

    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(-1, 1, 0)]
    [InlineData(0, 0, 0)]
    [InlineData(-5, -5, -10)]
    public void Sumar_VariosCasos_RetornaLoEsperado(int a, int b, int esperado)
    {
        Assert.Equal(esperado, _calc.Sumar(a, b));
    }

    [Theory]
    [InlineData(5, 3, 2)]
    [InlineData(0, 5, -5)]
    public void Restar_VariosCasos_RetornaLoEsperado(int a, int b, int esperado)
    {
        Assert.Equal(esperado, _calc.Restar(a, b));
    }

    [Theory]
    [InlineData(4, 3, 12)]
    [InlineData(7, 0, 0)]
    [InlineData(-2, 3, -6)]
    public void Multiplicar_VariosCasos_RetornaLoEsperado(int a, int b, int esperado)
    {
        Assert.Equal(esperado, _calc.Multiplicar(a, b));
    }

    [Fact]
    public void Dividir_NumerosValidos_RetornaCociente()
    {
        double resultado = _calc.Dividir(5.0, 2.0);

        Assert.Equal(2.5, resultado, precision: 5);
    }

    [Fact]
    public void Dividir_EntreCero_LanzaDivideByZeroException()
    {
        var ex = Assert.Throws<DivideByZeroException>(() => _calc.Dividir(10, 0));

        Assert.Equal("No se puede dividir entre cero.", ex.Message);
    }

    [Theory]
    [InlineData(2, true)]
    [InlineData(0, true)]
    [InlineData(7, false)]
    [InlineData(-3, false)]
    public void EsPar_VariosCasos_RetornaLoEsperado(int numero, bool esperado)
    {
        Assert.Equal(esperado, _calc.EsPar(numero));
    }
}
