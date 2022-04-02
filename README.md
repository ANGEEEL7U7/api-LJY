# Reporte de basura

### Equipo de desarrollo:
* Rocío Fuentes
* Adrián Méndez
* Ángel Cab

## Problemática
La asociación civil ProNatura en conjunto con la secretaría del medio ambiente del estado de Yucatán en la lucha para crear conciencia entre los ciudadanos acerca del calentamiento global desea contar con una herramienta que les permita identificar puntos de interés asociados a basureros clandestinos: esto debido a que al generarse la descomposición de la basura que es arrojada en el lugar se produce calor y gases que contaminan altamente el aire; además son fuente de posibles enfermedades por transmisión de algún vector. La asociación desea que la herramienta cuente con las siguientes características:  
* Para los ciudadanos se considera contar con:
  - Una opción para realizar una denuncia ciudadana la cual contendrá la siguiente información: fecha de la denuncia, Motivo de la denuncia, Descripción de la situación, Geoubicación del sitio, colonia donde se presenta el evento, fotografía del lugar.
  - También debe contar con una opción que le permita al ciudadano consultar los puntos de interés
(POI’s) cercanos a su ubicación actual (Colonia) y poder confirmar o rechazar la existencia del POI.
  - Una última opción que se desea para los ciudadanos es la consulta de eventos de limpieza organizados por ProNatura, estos eventos serán consultados teniendo siempre de manera obligatoria un filtro por distancia a la ubicación del ciudadano de aproximadamente 20 km (para ello podemos usar la fórmula de distancia euclidiana); y como filtros opcionales la colonia y motivo de denuncia. 
* Para el personal de la asociación se requiere:  
  - Una herramienta en la cual puedan realizar las consultas de los POI’s por los siguientes filtros, Colonia, Fecha de denuncia, Motivo de la denuncia, rango de confirmaciones (< 15, 15-30, > 30), aunque estos rangos pueden ser configurables, etc.
  - La organización también desea contar con un apartado en el cual pueda consultar de manera rápida algunos indicadores derivados de las denuncias como, cantidad de denuncias totales, cantidad de denuncias por motivo, cantidad de denuncias por colonia, denuncias con más confirmaciones, denuncias con más confirmaciones por tipo, denuncias con más confirmaciones por colonia.
  - Una vez que ProNatura analice la información ellos desean contar con un apartado donde se les permita la organización de eventos de limpieza en los puntos que ellos consideren pertinentes; para lo cual ellos esperan poder capturar la siguiente información: Nombre del evento, Fecha del evento, hora del evento, Ubicación del evento, Geoubicación del evento, Número de personas requeridas, características del evento, patrocinadores (si fuera el caso), consideraciones especiales.


# Requerimientos 
1.	El usuario (ciudadano) debe poder realizar una Denuncia ciudadana la cual pedirá la siguiente información: fecha de la denuncia, Motivo de la denuncia, descripción de la situación, Geoubicación del sitio, colonia donde se presenta el evento, fotografía del lugar.
2.	A partir de una dirección el sistema deberá encontrar la ubicación exacta del sitio en el mapa. 
3.	El usuario (ciudadano) podrá consultar puntos de interés cercanos a su ubicación actual (colonia)
4.	El usuario (ciudadano) podrá confirmar puntos de interés (Basurero).
5.	El usuario podrá rechazar puntos de interés (Basurero).
6.	El usuario (ciudadano) podrá consultar eventos de limpieza organizados por ProNatura Con un filtro de 20 km
7.	El sistema deberá contar con un filtro opcional para eventos por colonia
8.	El sistema deberá contar con un filtro opcional para eventos por motivo de denuncia
9.	El Usuario (ProNatura) podrá realizar consulta por el filtro colonia
10.	El Usuario (ProNatura) podrá realizar consulta por el filtro fecha de denuncia
11.	El Usuario (ProNatura) podrá realizar consulta por el filtro motivo de denuncia
12.	El Usuario (ProNatura) podrá realizar consulta por el filtro Rango de confirmaciones (<15…)
13.	El Usuario (ProNatura) podrá consultar indicadores de denuncias por cantidad de denuncias totales.
14.	El Usuario (ProNatura) podrá consultar indicadores de denuncias por cantidad de denuncias por motivo.
15.	El Usuario (ProNatura) podrá consultar indicadores de denuncias por cantidad de denuncias por colonia.
16.	El Usuario (ProNatura) podrá consultar indicadores de denuncias por cantidad de denuncias con más confirmaciones.
17.	El Usuario (ProNatura) podrá consultar indicadores de denuncias por cantidad de denuncias con más confirmaciones por tipo.
18.	El Usuario (ProNatura) podrá consultar indicadores de denuncias por cantidad de denuncias con más confirmaciones por colonia.
19.	El usuario (ProNatura) podrá crear eventos de limpieza donde se requerirá capturar la siguiente información: Nombre del evento, Fecha del evento, hora del evento, Ubicación del evento, Geoubicación del evento, Número de personas requeridas, características del evento, patrocinadores (si fuera el caso), consideraciones especiales

