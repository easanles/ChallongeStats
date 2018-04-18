# ChallongeStats
An app to obtain player data from Challonge to use it on OBS Studio.
Una aplicación para obtener datos de jugadores en Challonge para su uso en OBS Studio

## Español

### Descripción
ChallongeStats es una pequeña aplicación que cumple dos funciones:
- Se conecta a Challonge para, dado un identificador de torneo y dos nombres de jugadores, exportar a archivos de texto las estadísticas de partidas jugadas, victorias, derrotas, porcentaje de victorias y una linea de texto para indicar cual ha sido la última victoria del jugador en Winners Bracket o que jugador lo ha echado a Losers Bracket.
- Lee un archivo de texto donde se asocian nombres de jugadores con una serie de imágenes y texto referido a cada jugador, y los exporta a archivos de texto individuales.

Los archivos exportados se pueden usar en conjunto con OBS Studio para mostrar a los espectadores información sobre el rendimiento del jugador durante el torneo y otra información relevante como por ejemplo, bandera o avatar del jugador y personajes principales que utiliza.

### Estadísticas del torneo

1. Cubrir el campo "Clave API" con el código que puede encontrarse en https://challonge.com/es/settings/developer. Esta clave contiene las credenciales del usuario de Challonge, asi que no debe compartirse o mostrar por el streaming.

2. Escribir en "Identificador Challonge" el ID del torneo del cual se quiere extraer información. Este dato se puede obtener de la url del torneo. Si la url es del tipo https://challonge.com/es/ejemplo01 el ID es `ejemplo01`. Si la url es del tipo https://organizador.challonge.com/es/ejemplo01 el ID es `organizador-ejemplo01` (nombre de la organización, guión, id del torneo).

3. Indicar en "Guardar en" la carpeta destino de los ficheros de texto. "Seleccionar" para abrir un selector de carpeta.

4. Escribir los nombres de los jugadores en "Nombre Jugador 1" y "Nombre Jugador 2". No son sensibles a mayúsculas/minusculas. Pulsar el botón que hay en el medio "<->" intercambia los nombres de jugadores, un atajo por si los jugadores se cambian de sitio frente a la cámara.

5. Pulsar "Generar" para obtener la siguiente información ("\*" será "1" o "2" según el jugador al que se refiera):
   - **p\*_name.txt**: Nombre del jugador.
   - **p\*_games.txt**: Número total de partidas jugadas.
   - **p\*_wins.txt**: Suma de partidas ganadas.
   - **p\*_loses.txt**: Suma de partidas perdidas.
   - **p\*_winrate.txt**: Porcentaje de victorias frente a partidas totales, redondeado sin decimales.
   - **p\*_losersby.txt**: Una linea de texto que puede ser lo siguiente, con ejemplos:
     - Si el jugador está en Winners Bracket muestra su última victoria: *Última victoria VS:  Jugador  ( 2-0 )*
     - Si el jugador ha perdido una vez y está en Losers Bracket muestra quien lo derrotó: *En Losers Bracket por:  Jugador  ( 0-2 )*
     - Si la última partida fue de fase de grupos muestra cual fue haya ganado o perdido: *Último enfrentamiento VS:  Jugador  ( 2-0 )*
     - Si no tiene combates anteriores dentro del torneo muestra *Primera participación*

### Datos del jugador

1. Si no estaba creado anteriormente, al abrir la app se genera un archivo de texto llamado **playerdata.txt**. En este archivo irá la información de todos los jugadores. El formato es el siguiente:
 - Comenzar una linea con `@`: indicar nombre de jugador, no sensible a minusculas/mayusculas.
 - Comenzar una linea con `|`: indicar una imagen del jugador dentro de la ruta **./img/**.  La primera imagen se guarda en **p\*_img1.png**, la segunda en **p\*_img2.png**, ...
   - Si se deja vacío limpiará la imagen (sin imagen). Escribir solo `|`.
   - Las imágenes se deben guardar en una carpeta llamada `img` en la misma carpeta del programa. Tienen que tener la extensión `.png`.
   - Solo hay que escribir el nombre de la imagen sin el `.png`. Ejemplo: `|personaje` para `./img/personaje.png`.
   - Se pueden crear subcarpetas dentro de `img`, por ejemplo escribir: `|juego/personaje` para obtener el archivo `./img/juego/personaje.png`.
 - Comenzar una linea con `;`: indicar un comentario, se ignora la linea.
 - Cualquier otra linea debajo de un nombre de jugador: el texto asociado al jugador. Se guardará en **p\*_text.txt**.

2. Indicar en "Guardar en" la carpeta destino de los ficheros de texto. "Seleccionar" para abrir un selector de carpeta.

3. Escribir los nombres de los jugadores en "Nombre Jugador 1" y "Nombre Jugador 2". No son sensibles a mayúsculas/minusculas. Pulsar el botón que hay en el medio "<->" intercambia los nombres de jugadores, un atajo por si los jugadores se cambian de sitio frente a la cámara.

4. Pulsar "Generar". Si alguno de los dos nombres coinciden con el nombre de un jugador dentro de playerdata.txt se generan los siguientes archivos ("\*" será "1" o "2" según el jugador al que se refiera):
  - **p\*_img1.png**, **p\*_img2.png**, ...: Imágenes asociadas al jugador. Pueden usarse para mostrar una bandera, avatar, o los personajes principales del jugador.
  - **p\*_text.txt**: El texto indicado debajo del nombre del jugador en playerdata.txt. El texto es libre, puede usarse por ejemplo para mostrar la clasificación del jugador dentro de una temporada, resultados previos u otro tipo de información.
  
### Config.ini

La aplicación crea un archivo **config.ini** para guardar los siguientes parámetros:

- **LANGUAGE**: Idioma de la app. `es` para español. `en` para inglés. Puede cambiarse dentro de la app pulsando en los iconos de bandera.
- **API_KEY**: Última clave API de Challonge usada, para tener el campo ya cubierto al abrir la app.
- **LAST_CHALLONGE_ID**: Último ID de Challonge usado.
- **LAST_OUTPUT_DIR**: Última ruta de exportación de archivos usada.
- **GENERATED_IMGS_NUM**: Número de archivos de imagenes a mantener. Al escribir `|` en playerdata.txt se vacía la imagen correspondiente, pero para no tener que escribir varias lineas vacías se puede indicar en este parametro el número de imágenes que vamos a mantener en OBS Studio.
  - Ejemplo: Si tenemos un espacio en OBS Studio para indicar cuales son los tres personajes que más usa un jugador, introducimos `3` en este parámetro. Si un jugador solamente utiliza un personaje, no hace falta escribir dos lineas vacías `|`, escribimos solamente ese personaje y la app se encarga de vaciar las otras dos imágenes.
- **READ_P1_NAME_FROM_DIR** y **READ_P2_NAME_FROM_DIR**: Alternativa a escribir los nombres de jugadores en la app. Pueden usarse estos parametros para indicar la ruta de un archivo de texto desde la cual se leerá el nombre del jugador correspondiente. Se utilizan solamente si el campo de nombre se deja vacío.

### A tener en cuenta

- Desactivando las casillas "Estadísticas torneo" y "Datos torneo" se deshabilitan dichas funciones en caso de que no se vayan a usar.
- Si un jugador abandona en mitad del torneo, es recomendable indicarlo dentro de Challonge con un resultado de 0-0 y eligiendo al ganador sin más, para no acumular partidas que el ganador realmente no ha jugado.
- La app no es compatible con partidas con multiples sets. (La opción de Challonge para indicar varias puntuaciones dentro de un mismo enfrentamiento).
