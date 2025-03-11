# Juego multijugador

El juego consiste en un multijugador local en el que se tendrán que enfrentar entre ellos y conseguir la victoria.

## TO-DO

### Menú inicial

Un menú inicial para poder empezar el juego o salir del mismo.

### Menú de pausa

Un menú para poder pausar mientras el juego esta iniciado.
   - ESC para pausar

### Mecánicas

En el juego tendrás que enfrentarte 3 rondas contra tu enemigo para conseguir la victoria final y salir con vida del lugar.

1. Mecánicas básicas ✔
    - **Movimiento**: Correr, saltar. 
    - **Acciones**: Atacar, recoger objetos.
    - **Rondas**: 3 rondas.
    
2. Mecánicas cooperativas ✔
    - **PvP**: Combates entre jugadores. 
    - **Habilidades**: Un sistema de habilidades random al inicio de la partida y que va cambiando conforme se empieza una ronda o partida 

### Player

1. Movimiento para los jugadores 
   - Movimiento 2D (movimiento horizontal y salto) con **rigybody**. ✔
   - Mismo script para los jugadores pero distintas teclas para cada uno. ✔
   - Mejora de las stats de las habilidades.
  
2. Vida de los jugadores ✔
  
3. Ataque 
   - Ataque cuerpo a cuerpo contra el otro jugador. ✔
   - Saber cuándo ataca un jugador. ✔
   - Sensación de daño. ✔
   - Aspecto visual para ver el ataque:
        - Que ataque en un area en una distancia fija del personaje, esta distancia puede ser un atributo.
        - Cuando no esta atacando (punto de mira), y si si esta atacando (interpola escala y color del punto de mira y hace daño)

4. Aspecto visual
   - Saber que habilidad tiene cada player.
   - Arreglar "BloodParticles", cambiar a un shape en 2D y tocar la propiedad collider.

#### Animación

1. Animación de caminar ✔
2. Animación de salto ✔
3. Animación de caída ✔
4. Cinemática entre escena

### Mapa

Un mapa con delimitaciones para que los jugadores no puedan escapar, y obligue a los jugadores a enfrentarse entre sí.

El mapa tendrá obstáculos o barreras para que los jugadores puedan defenderse. 
