namespace GuiaPractica4.Modelos;

internal sealed record ResultadoRuta(
    IReadOnlyList<string> Ciudades,
    decimal PrecioTotal,
    double TiempoMilisegundos);