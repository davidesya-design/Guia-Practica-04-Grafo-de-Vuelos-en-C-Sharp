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
├── base/                    # Proyecto, datos
│   ├── GuiaPractica4.csproj
│   └── Datos/
│       └── vuelos.txt
├── compilado/               # Aplicación compilada para Windows x64
│   ├── GuiaPractica4.exe
│   ├── GuiaPractica4.dll
│   ├── GuiaPractica4.deps.json
│   ├── GuiaPractica4.runtimeconfig.json
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

Para volver a generar la versión ligera, ejecuta desde esta misma carpeta:

```powershell
dotnet publish .\base\GuiaPractica4.csproj -c Release -r win-x64 -p:SelfContained=false -p:PublishSingleFile=false -o .\compilado
```

La aplicación compilada ocupa menos espacio porque no incluye el runtime. Para abrir `compilado/GuiaPractica4.exe` se requiere tener instalado el **.NET 10 Runtime para Windows x64**. Mantén juntos el `.exe`, la `.dll`, los archivos `.json` y la carpeta `Datos`; no se puede ejecutar el `.exe` aislado.

## Funcionalidades

1. Mostrar las ciudades (vértices) y vuelos (aristas) mediante una lista de adyacencia.
2. Consultar la ruta de menor costo entre dos ciudades.
3. Mostrar el costo total y el tiempo medido de búsqueda.
4. Informar si el origen o el destino no existen o si no hay una ruta disponible.

## Datos

Los vuelos y precios en dólares son ficticios y se almacenan en `base/Datos/vuelos.txt`. Cada línea usa el formato `Origen;Destino;Precio`. Las conexiones son dirigidas; para habilitar el viaje de regreso se debe registrar otra arista.

## Agente de IA utilizado

-**Agente**: GitHub Copilot
- **Porcentaje de código**: 20% (revisión y ayuda en compilación del proyecto)
