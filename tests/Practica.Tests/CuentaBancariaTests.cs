using Practica.Core;

namespace Practica.Tests;

[Trait("Categoria", "Cuenta")]
public class CuentaBancariaTests
{
    [Fact]
    public void Constructor_DatosValidos_AsignaTitularYSaldo()
    {
        var cuenta = new CuentaBancaria("Ana", 100m);

        Assert.Equal("Ana", cuenta.Titular);
        Assert.Equal(100m, cuenta.Saldo);
    }

    [Fact]
    public void Constructor_SinSaldoInicial_EmpiezaEnCero()
    {
        var cuenta = new CuentaBancaria("Ana");

        Assert.Equal(0m, cuenta.Saldo);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_TitularVacio_LanzaArgumentException(string titular)
    {
        Assert.Throws<ArgumentException>(() => new CuentaBancaria(titular));
    }

    [Fact]
    public void Constructor_SaldoNegativo_LanzaArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new CuentaBancaria("Ana", -1m));
    }

    [Fact]
    public void Depositar_MontoValido_AumentaElSaldo()
    {
        var cuenta = new CuentaBancaria("Ana", 100m);

        cuenta.Depositar(50m);

        Assert.Equal(150m, cuenta.Saldo);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-10)]
    public void Depositar_MontoInvalido_LanzaArgumentOutOfRangeException(decimal monto)
    {
        var cuenta = new CuentaBancaria("Ana", 100m);

        Assert.Throws<ArgumentOutOfRangeException>(() => cuenta.Depositar(monto));
    }

    [Fact]
    public void Retirar_MontoValido_DisminuyeElSaldo()
    {
        var cuenta = new CuentaBancaria("Ana", 100m);

        cuenta.Retirar(40m);

        Assert.Equal(60m, cuenta.Saldo);
    }

    [Fact]
    public void Retirar_MasQueElSaldo_LanzaInvalidOperationException()
    {
        var cuenta = new CuentaBancaria("Ana", 100m);

        var ex = Assert.Throws<InvalidOperationException>(() => cuenta.Retirar(500m));

        Assert.Equal("Fondos insuficientes.", ex.Message);
        Assert.Equal(100m, cuenta.Saldo); // el saldo no debe cambiar
    }

    [Fact]
    public void Retirar_TodoElSaldo_DejaSaldoEnCero()
    {
        var cuenta = new CuentaBancaria("Ana", 100m);

        cuenta.Retirar(100m);

        Assert.Equal(0m, cuenta.Saldo);
    }
}
