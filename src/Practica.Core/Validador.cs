namespace Practica.Core;

public class Validador
{
    public bool EsPalindromo(string texto)
    {
        if (string.IsNullOrWhiteSpace(texto))
            return false;

        var limpio = new string(texto.Where(char.IsLetterOrDigit).ToArray()).ToLowerInvariant();
        return limpio.SequenceEqual(limpio.Reverse());
    }

    public int ContarVocales(string texto)
    {
        if (string.IsNullOrEmpty(texto))
            return 0;

        return texto.ToLowerInvariant().Count(c => "aeiouáéíóú".Contains(c));
    }
}
