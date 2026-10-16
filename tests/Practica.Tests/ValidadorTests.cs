using Practica.Core;

namespace Practica.Tests;

[Trait("Categoria", "Validador")]
public class ValidadorTests
{
    private readonly Validador _validador = new();

    [Theory]
    [InlineData("anilina")]
    [InlineData("Reconocer")]
    [InlineData("Anita lava la tina")]
    [InlineData("12321")]
    public void EsPalindromo_TextosPalindromos_RetornaTrue(string texto)
    {
        Assert.True(_validador.EsPalindromo(texto));
    }

    [Theory]
    [InlineData("hola")]
    [InlineData("xUnit")]
    [InlineData("")]
    [InlineData("   ")]
    public void EsPalindromo_TextosNoPalindromos_RetornaFalse(string texto)
    {
        Assert.False(_validador.EsPalindromo(texto));
    }

    [Theory]
    [InlineData("hola", 2)]
    [InlineData("xyz", 0)]
    [InlineData("AEIOU", 5)]
    [InlineData("", 0)]
    public void ContarVocales_VariosCasos_RetornaLoEsperado(string texto, int esperado)
    {
        Assert.Equal(esperado, _validador.ContarVocales(texto));
    }

    [Fact]
    public void ContarVocales_TextoNulo_RetornaCero()
    {
        Assert.Equal(0, _validador.ContarVocales(null!));
    }
}
