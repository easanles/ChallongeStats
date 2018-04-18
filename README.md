# ChallongeStats
An app to obtain player data from Challonge to use it on OBS Studio. / Una aplicación para obtener datos de jugadores en Challonge para su uso en OBS Studio.

## English

### Description
ChallongeStats is a small app which has two features:
- Connects to Challonge to, given an id for a tournament and two player names, export to text files statistics about played games, wins, loses, winrates and a text line to indicate the last victory inside Winnners Bracket or who drop down the player to Losers Bracket.
- Reads a text file where player names are associated with a series of images and text, and export them to individual files.

Exported files can be used in OBS Studio to show to the spectators information about performance of players inside a tournament and other relevant information like a flag, avatar or main characters.

### Tournament stats

1. Set "API Key" with the key at https://challonge.com/es/settings/developer. This key contains the Challonge user credentials, so it must not be shared or shown on the streaming.

2. Write in "Challonge ID" the ID of the tournament. It can be seen in the url of the tournament. If the url is like https://challonge.com/example01, the ID is `example01`. If the url is like https://organization.challonge.com/example01, the ID is `organization-example01` (organization name, hyphen, tournament ID).

3. Set in "Save at" the path to the output folder. "Select" to open a folder browser dialog.

4. Write the player names in "Player 1 Name" and "Player 2 Name". They are not case-sensitive. Press the middle button "<->" to swap names, a shortcut in case of players exchanging their seats.

5. Click "Generate" to export the following information ("\*" represents "1" o "2" depending of the player):
   - **p\*_name.txt**: Player name.
   - **p\*_games.txt**: Total number of games played.
   - **p\*_wins.txt**: Sum of won games.
   - **p\*_loses.txt**: Sum of lost games.
   - **p\*_winrate.txt**: Percentage of victories against total games, rounded without decimals. 
   - **p\*_losersby.txt**: A text line which can be one of the following, with examples:
     - If the player is in Winners Bracket, shows the last victory: *Last victory VS:  Player  ( 2-0 )*
     - If the player has lost once and is in Losers Bracket, shows who defeated him: *In Losers Bracket by:  Player  ( 0-2 )*
     - If the last match was a group stage match, shows the score regardless of whether he has won or lost: *Last match VS:  Player  ( 2-0 )*
     - If there aren't any previous match, shows *First match*

### Player data

1. If it wasn't previously created, when the app is opened it creates a text file named **playerdata.txt**. This file will contain information about every player. The format is as follows:
 - Start a line with `@`: specify player name, not case sensitive.
 - Start a line with `|`: specify image file inside path **./img/**  First image will be saved as **p\*_img1.png**, the second one as **p\*_img2.png**, ...
   - If it is left blank, it will generate an empty image. Write just `|`.
   - Images must be saved inside a folder named `img` in the same folder as the executable. Images must have `.png` extension.
   - Write only the file name without the `.png`. Example: `|char` for `./img/char.png`.
   - You can create subfolders inside `img`, for example write: `|game/char` to get `./img/game/char.png`.
 - Start a line with `;`: specify a comment, line is ignored
 - Any other line below a player name: the text asociated to the player. It will be saved at **p\*_text.txt**.
 
2. Set in "Save at" the path to the output folder. "Select" to open a folder browser dialog.

3. Write the player names in "Player 1 Name" and "Player 2 Name". They are not case-sensitive. Press the middle button "<->" to swap names, a shortcut in case of players exchanging their seats.

4. Click "Generate". If any of the two player names are found inside playerdata.txt, the following files will be generated  ("\*" represents "1" o "2" depending of the player):
  - **p\*_img1.png**, **p\*_img2.png**, ...: Images associated to the player. Can be used to show a flag, an avatar or the player's main characters.
  - **p\*_text.txt**: Text specified below a player name inside playerdata.txt. It is free text, can be used for example to show the ranking during a season, previous results or any other relevant information.
    
### Config.ini

The app creates a **config.ini** file which saves the following parameters:

- **LANGUAGE**: App language. `es` for Spanish. `en` for English. Can be choosen inside the app clicking the flag icons.
- **API_KEY**: Last Challonge API key used. API Key field is automatically set with this value at start.
- **LAST_CHALLONGE_ID**: Last Challonge tournament id used.
- **LAST_OUTPUT_DIR**: Last output folder path used.
- **GENERATED_IMGS_NUM**: Number of image files to support. Writing `|` in playerdata.txt empties the corresponding image, but to not having to write several empty lines, this parameter can be used to specify how many image files are we going to use.
  - Example: We are going to have three images in OBS Studio to show to the spectator the most used characters of a player, then we set this parameter as `3`. If a player only uses one character, it isn't necessary to write two empty lines with `|`, just write that character image and the app automatically empties the other two images.
- **READ_P1_NAME_FROM_DIR** and **READ_P2_NAME_FROM_DIR**: Alternate way to specify player names. This parameters can be used to indicate the path to a text file which contains the corresponding player name. These path are used when the player name field is empty.

### To consider

- Unchecking the checkboxes "Tournament stats" and "Player data" will disable said features in case of they are not being used.
- If a player leaves a tournament, it should be indicated at Challonge with a score of 0-0 and just checking the match winner. That way the app will not accumulate games that the winner has not really played.
- The app is not compatible with multiple set matches. (The Challonge feature to specify several scores inside the same match)


## Español

### Descripción
ChallongeStats es una pequeña aplicación que cumple dos funciones:
- Se conecta a Challonge para, dado un identificador de torneo y dos nombres de jugadores, exportar a archivos de texto las estadísticas de partidas jugadas, victorias, derrotas, porcentaje de victorias y una linea de texto para indicar cual ha sido la última victoria del jugador en Winners Bracket o que jugador lo ha echado a Losers Bracket.
- Lee un archivo de texto donde se asocian nombres de jugadores con una serie de imágenes y texto referido a cada jugador, y los exporta a archivos individuales.

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
   - Si se deja vacío limpiará la imagen (imagen vacía). Escribir solo `|`.
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
  - Ejemplo: Si tenemos un espacio en OBS Studio para indicar cuales son los tres personajes que más usa un jugador, introducimos `3` en este parámetro. Si un jugador solamente utiliza un personaje, no hace falta escribir dos lineas vacías `|`, escribimos solamente esa imagen de personaje y la app se encarga de vaciar las otras dos imágenes.
- **READ_P1_NAME_FROM_DIR** y **READ_P2_NAME_FROM_DIR**: Alternativa a escribir los nombres de jugadores en la app. Pueden usarse estos parametros para indicar la ruta de un archivo de texto desde la cual se leerá el nombre del jugador correspondiente. Se utilizan solamente si el campo de nombre se deja vacío.

### A tener en cuenta

- Desactivando las casillas "Estadísticas torneo" y "Datos torneo" se deshabilitan dichas funciones en caso de que no se vayan a usar.
- Si un jugador abandona en mitad del torneo, es recomendable indicarlo dentro de Challonge con un resultado de 0-0 y eligiendo al ganador sin más, para no acumular partidas que el ganador realmente no ha jugado.
- La app no es compatible con partidas con multiples sets. (La opción de Challonge para indicar varias puntuaciones dentro de un mismo enfrentamiento).

## LICENSE / LICENCIA

See LICENSE file / Ver archivo LICENSE
