using System.Globalization;
using GuiaPractica4.Modelos;
using GuiaPractica4.Servicios;

namespace GuiaPractica4.Interfaz;

internal sealed class MenuVuelos
{
    private static readonly CultureInfo CulturaMoneda = CultureInfo.GetCultureInfo("en-US");
    private readonly GrafoVuelos grafo;

    public MenuVuelos(GrafoVuelos grafo)
    {
        this.grafo = grafo;
    }

    public void Ejecutar()
    {
        while (true)
        {
            Console.WriteLine("\n=== Buscador de vuelos baratos ===");
            Console.WriteLine("1. Mostrar el grafo de vuelos");
            Console.WriteLine("2. Buscar ruta más barata");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            switch (Console.ReadLine()?.Trim())
            {
                case "1":
                    MostrarVuelos();
                    break;
                case "2":
                    BuscarRuta();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    private void MostrarVuelos()
    {
        List<string> ciudades = grafo.ObtenerCiudades().ToList();
        Console.WriteLine($"\nGrafo dirigido ponderado: {ciudades.Count} vértices y {grafo.CantidadVuelos} aristas.");
        Console.WriteLine("Lista de adyacencia (ciudad -> destino: precio):");

        foreach (string ciudad in ciudades)
        {
            IReadOnlyList<Vuelo> vuelos = grafo.ObtenerVuelosDesde(ciudad);
            if (vuelos.Count == 0)
            {
                Console.WriteLine($"{ciudad} -> (sin vuelos salientes)");
                continue;
            }

            string destinos = string.Join(", ", vuelos.Select(vuelo =>
                $"{vuelo.Destino}: {vuelo.Precio.ToString("C", CulturaMoneda)}"));
            Console.WriteLine($"{ciudad} -> {destinos}");
        }
    }

    private void BuscarRuta()
    {
        Console.Write("Ciudad de origen: ");
        string origen = Console.ReadLine()?.Trim() ?? "";
        Console.Write("Ciudad de destino: ");
        string destino = Console.ReadLine()?.Trim() ?? "";

        if (!grafo.ContieneCiudad(origen) || !grafo.ContieneCiudad(destino))
        {
            Console.WriteLine("No se encontró el origen o el destino en los datos.");
            return;
        }

        ResultadoRuta? resultado = grafo.BuscarRutaMasBarata(origen, destino);
        if (resultado is null)
        {
            Console.WriteLine($"No hay una ruta disponible desde {origen} hasta {destino}.");
            return;
        }

        Console.WriteLine($"Ruta más barata: {string.Join(" -> ", resultado.Ciudades)}");
        Console.WriteLine($"Costo total: {resultado.PrecioTotal.ToString("C", CulturaMoneda)}");
        Console.WriteLine($"Tiempo de búsqueda: {resultado.TiempoMilisegundos:F4} ms");
    }
}