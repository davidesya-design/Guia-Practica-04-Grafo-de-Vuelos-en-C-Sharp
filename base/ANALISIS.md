# Análisis de la solución

## Estructura utilizada

Se implementó un grafo dirigido y ponderado mediante listas de adyacencia. Cada ciudad representa un vértice. Cada vuelo representa una arista dirigida desde el origen hasta el destino, y su peso es el precio en dólares. Por ejemplo, registrar `Quito;Lima;150` crea el vuelo de Quito a Lima por $150; no crea automáticamente el vuelo de regreso.

El conjunto de prueba contiene 13 ciudades (vértices) y 26 vuelos (aristas). `GrafoVuelos` mantiene las conexiones, `CargadorVuelos` lee y valida el archivo de texto y `MenuVuelos` presenta el reporte y recibe las consultas.

## Búsqueda de la ruta más barata

La aplicación utiliza el algoritmo de Dijkstra. Inicializa el costo del origen en cero y el de las demás ciudades como infinito. Luego procesa la ciudad pendiente con menor costo, examina sus vuelos salientes y actualiza los costos cuando encuentra una ruta más económica. Al llegar al destino reconstruye la secuencia de ciudades usando los predecesores.

Los precios deben ser no negativos para que Dijkstra garantice el resultado correcto; el cargador rechaza precios negativos.

## Complejidad

Con una cola de prioridad y listas de adyacencia, la búsqueda tiene un costo aproximado de `O((V + E) log E)` para esta implementación, donde `V` es el número de ciudades y `E` el número de vuelos. Para grafos simples suele expresarse como `O((V + E) log V)`. La memoria utilizada por el grafo y las estructuras auxiliares es `O(V + E)`.

## Tiempo observado

En una ejecución de prueba con 13 vértices y 26 aristas, el programa encontró la ruta Quito → Lima → Santiago → Buenos Aires por $380. La medición mostrada por el programa fue de aproximadamente 0,86 ms. El cronómetro mide el ciclo de procesamiento de Dijkstra; no incluye la carga del archivo, la inicialización de las distancias ni la reconstrucción de la ruta. El resultado puede variar según el equipo y la ejecución, por lo que corresponde a una observación del conjunto pequeño de prueba, no a un benchmark general.

## Ventajas

- Las listas de adyacencia almacenan directamente las conexiones existentes y evitan reservar espacio para todas las combinaciones posibles de ciudades.
- El grafo representa conexiones dirigidas, escalas y rutas alternativas de forma natural.
- Los pesos permiten comparar el costo acumulado de rutas con varios vuelos.
- El reporte de adyacencia permite inspeccionar las ciudades, los vuelos y sus precios.

## Desventajas y limitaciones

- Dijkstra no admite pesos negativos; los precios deben validarse al cargar los datos.
- Si cambia el archivo, el programa no detecta precios reales ni actualizaciones externas: la información es ficticia y debe mantenerse manualmente.
- La dirección de cada vuelo importa. El regreso solo está disponible si se registra como otra arista.
- La medición con una base pequeña tiene poca precisión práctica y no representa el rendimiento con un volumen real de vuelos.

## Conclusión

El grafo ponderado permite modelar las ciudades y vuelos del problema, y Dijkstra encuentra una ruta de costo mínimo dentro de las conexiones registradas. La prueba confirma el funcionamiento con el conjunto ficticio, pero los resultados dependen de la cobertura y calidad de los datos proporcionados.
