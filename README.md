# Práctica de pruebas unitarias con xUnit (.NET 8)

Proyecto sencillo para practicar **ejecución de pruebas con xUnit**.

## Estructura

```
PracticaXUnit/
├── PracticaXUnit.sln
├── src/Practica.Core/          # Código a probar
│   ├── Calculadora.cs          # Operaciones básicas + excepción por división entre cero
│   ├── CuentaBancaria.cs       # Depositar / Retirar con validaciones
│   └── Validador.cs            # Palíndromos y conteo de vocales
└── tests/Practica.Tests/       # Pruebas xUnit
    ├── CalculadoraTests.cs
    ├── CuentaBancariaTests.cs
    └── ValidadorTests.cs
```

Qué se practica: `[Fact]`, `[Theory]` + `[InlineData]`, `Assert.Equal/True/False`,
`Assert.Throws<T>`, patrón Arrange-Act-Assert, constructor como setup y `[Trait]` para filtrar.

## Ejecutar en Codespaces

1. Sube el repo a GitHub.
2. Botón verde **Code → Codespaces → Create codespace on main**.
3. En la terminal:

```bash
dotnet restore                  # restaurar paquetes
dotnet build                    # compilar
dotnet test                     # ejecutar todas las pruebas
```

## Comandos útiles

```bash
dotnet test --verbosity normal                          # ver cada prueba
dotnet test --filter "Categoria=Calculadora"            # solo una categoría (Trait)
dotnet test --filter "FullyQualifiedName~Dividir"       # pruebas cuyo nombre contenga "Dividir"
dotnet test --filter "FullyQualifiedName~CuentaBancariaTests"   # una clase
dotnet test --list-tests                                # listar sin ejecutar
dotnet test --logger "trx;LogFileName=resultados.trx"   # reporte .trx
dotnet test --collect:"XPlat Code Coverage"             # cobertura de código
dotnet test --no-build                                  # sin recompilar
```

## Para seguir practicando

- Rompe una prueba a propósito (cambia un valor esperado) y mira cómo falla.
- Agrega métodos nuevos a `Calculadora` (potencia, raíz cuadrada) y escribe sus pruebas primero (TDD).
- Prueba `[Fact(Skip = "motivo")]` para omitir una prueba.
