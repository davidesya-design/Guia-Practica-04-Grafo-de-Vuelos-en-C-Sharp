# Guía Práctica 04: Buscador de vuelos baratos en C#

**Autor:** Andrew Valenzuela  
**Proyecto:** Guía Práctica 04 - Buscador de vuelos baratos en C#  
**Asignatura:** Estructura de Datos  
**Carrera:** Tecnologías de la Información  
**Universidad:** Universidad Estatal Amazónica (UEA)

## Estructura del proyecto

```text
Entrega_GuiaPractica4/
├── codigo/                  # Código fuente C#
│   ├── Program.cs
│   ├── Vuelo.cs
│   ├── ResultadoRuta.cs
│   ├── GrafoVuelos.cs
│   ├── CargadorVuelos.cs
│   └── MenuVuelos.cs
├── base/                    # Proyecto, datos y documentación
│   ├── GuiaPractica4.csproj
│   ├── README.md
│   ├── ANALISIS.md
│   └── Datos/
│       └── vuelos.txt
├── compilado/               # Aplicación compilada para Windows x64
│   ├── GuiaPractica4.exe
│   └── Datos/
│       └── vuelos.txt
└── .gitignore
```

## Compilar y ejecutar

Se requiere el SDK de .NET 10. Ejecuta estos comandos desde la carpeta `Entrega_GuiaPractica4`:

```powershell
dotnet build .\base\GuiaPractica4.csproj
dotnet run --project .\base\GuiaPractica4.csproj
```

También puedes abrir `compilado/GuiaPractica4.exe`. Conserva `compilado/Datos` junto al ejecutable para que cargue el archivo de vuelos.

## Funcionalidades

1. Mostrar las ciudades (vértices) y vuelos (aristas) mediante una lista de adyacencia.
2. Consultar la ruta de menor costo entre dos ciudades.
3. Mostrar el costo total y el tiempo medido de búsqueda.
4. Informar si el origen o el destino no existen o si no hay una ruta disponible.

## Datos

Los vuelos y precios en dólares son ficticios y se almacenan en `base/Datos/vuelos.txt`. Cada línea usa el formato `Origen;Destino;Precio`. Las conexiones son dirigidas; para habilitar el viaje de regreso se debe registrar otra arista.

## Agente de IA utilizado

- **Agente:** GitHub Copilot.
- **Porcentaje aproximado de código desarrollado con ayuda de IA:** 90 % (generación inicial, organización, modificaciones y validaciones). Ajusta este porcentaje según el código que revises, comprendas y modifiques antes de entregar.

## Repositorio

Pendiente de publicar. Añade aquí el enlace cuando el repositorio esté disponible.

Para el análisis del grafo, el algoritmo, la complejidad y los resultados de prueba, consulta `ANALISIS.md`.