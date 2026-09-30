using System.Diagnostics;
using GuiaPractica4.Modelos;

namespace GuiaPractica4.Servicios;

internal sealed class GrafoVuelos
{
    private readonly Dictionary<string, List<Vuelo>> adyacencia = new(StringComparer.OrdinalIgnoreCase);

    public void AgregarVuelo(string origen, string destino, decimal precio)
    {
        if (!adyacencia.ContainsKey(origen))
        {
            adyacencia[origen] = [];
        }

        if (!adyacencia.ContainsKey(destino))
        {
            adyacencia[destino] = [];
        }

        adyacencia[origen].Add(new Vuelo(origen, destino, precio));
    }

    public bool ContieneCiudad(string ciudad) => adyacencia.ContainsKey(ciudad);

    public IEnumerable<string> ObtenerCiudades() => adyacencia.Keys;

    public int CantidadVuelos => adyacencia.Values.Sum(vuelos => vuelos.Count);

    public IReadOnlyList<Vuelo> ObtenerVuelosDesde(string origen) =>
        adyacencia.TryGetValue(origen, out List<Vuelo>? vuelos) ? vuelos : [];

    public ResultadoRuta? BuscarRutaMasBarata(string origen, string destino)
    {
        var distancias = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase);
        var anteriores = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        var pendientes = new PriorityQueue<string, decimal>();

        foreach (string ciudad in adyacencia.Keys)
        {
            distancias[ciudad] = decimal.MaxValue;
        }

        distancias[origen] = 0;
        pendientes.Enqueue(origen, 0);

        Stopwatch cronometro = Stopwatch.StartNew();
        while (pendientes.TryDequeue(out string? ciudadActual, out decimal costoActual))
        {
            if (costoActual > distancias[ciudadActual])
            {
                continue;
            }

            if (ciudadActual.Equals(destino, StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            foreach (Vuelo vuelo in adyacencia[ciudadActual])
            {
                decimal nuevoCosto = costoActual + vuelo.Precio;
                if (nuevoCosto < distancias[vuelo.Destino])
                {
                    distancias[vuelo.Destino] = nuevoCosto;
                    anteriores[vuelo.Destino] = ciudadActual;
                    pendientes.Enqueue(vuelo.Destino, nuevoCosto);
                }
            }
        }
        cronometro.Stop();

        if (distancias[destino] == decimal.MaxValue)
        {
            return null;
        }

        var ruta = new List<string> { destino };
        string ciudadRuta = destino;
        while (!ciudadRuta.Equals(origen, StringComparison.OrdinalIgnoreCase))
        {
            ciudadRuta = anteriores[ciudadRuta];
            ruta.Add(ciudadRuta);
        }

        ruta.Reverse();
        return new ResultadoRuta(ruta, distancias[destino], cronometro.Elapsed.TotalMilliseconds);
    }
}