namespace Practica.Core;

public class CuentaBancaria
{
    public string Titular { get; }
    public decimal Saldo { get; private set; }

    public CuentaBancaria(string titular, decimal saldoInicial = 0)
    {
        if (string.IsNullOrWhiteSpace(titular))
            throw new ArgumentException("El titular es obligatorio.", nameof(titular));

        if (saldoInicial < 0)
            throw new ArgumentOutOfRangeException(nameof(saldoInicial), "El saldo inicial no puede ser negativo.");

        Titular = titular;
        Saldo = saldoInicial;
    }

    public void Depositar(decimal monto)
    {
        if (monto <= 0)
            throw new ArgumentOutOfRangeException(nameof(monto), "El monto debe ser mayor que cero.");

        Saldo += monto;
    }

    public void Retirar(decimal monto)
    {
        if (monto <= 0)
            throw new ArgumentOutOfRangeException(nameof(monto), "El monto debe ser mayor que cero.");

        if (monto > Saldo)
            throw new InvalidOperationException("Fondos insuficientes.");

        Saldo -= monto;
    }
}
