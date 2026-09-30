using System.Globalization;
using GuiaPractica4.Modelos;

namespace GuiaPractica4.Servicios;

internal static class CargadorVuelos
{
    public static GrafoVuelos CargarDesdeArchivo(string ruta)
    {
        string rutaCompleta = Path.Combine(AppContext.BaseDirectory, ruta);
        if (!File.Exists(rutaCompleta))
        {
            rutaCompleta = Path.Combine(Directory.GetCurrentDirectory(), ruta);
        }

        if (!File.Exists(rutaCompleta))
        {
            throw new FileNotFoundException($"No se encontró el archivo de datos '{ruta}'.");
        }

        var grafo = new GrafoVuelos();
        string[] lineas = File.ReadAllLines(rutaCompleta);

        for (int indice = 0; indice < lineas.Length; indice++)
        {
            string linea = lineas[indice].Trim();
            if (linea.Length == 0 || linea.StartsWith('#'))
            {
                continue;
            }

            string[] campos = linea.Split(';');
            if (campos.Length != 3 ||
                string.IsNullOrWhiteSpace(campos[0]) ||
                string.IsNullOrWhiteSpace(campos[1]) ||
                !decimal.TryParse(campos[2], NumberStyles.Number, CultureInfo.InvariantCulture, out decimal precio) ||
                precio < 0)
            {
                throw new InvalidDataException(
                    $"Formato inválido en la línea {indice + 1}. Use Origen;Destino;Precio con precio no negativo.");
            }

            grafo.AgregarVuelo(campos[0].Trim(), campos[1].Trim(), precio);
        }

        return grafo;
    }
}