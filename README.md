# IAV23-Sanchez-Horcajuelo : G.O.A.P en Unity 
proyecto final Inteligencia Artificial 

# Propuesta
La idea principal del proyecto consiste en crear un pequeño simulador de  ecosistemas donde habiten dinosaurios herbivoros y carnivoros cuyo  comportamiento estará definido 
por un sistema GOAP.
En el entorno colocaremos plantas que serviran de alimento para los dinosaurios herbivoros y charcos de  agua que serviran para saciar la sed a todos los dinosaurios.
Los dinosaurios carnivoros se alimentarán de otros dinosaurios.
Todos los dinosaurios  se cansan y necesitan dormir para recuperar energia.
El comportamiendo que se espera obtener es aquel que asegure en la medida de lo posible la supervivencia de los dinosaurios , que eviten morir de agotamiento , de hambre o comidos por  otros.

# Punto de Partida 
 Se parte de un proyecto de Unity con un [plug in de SGOAP](https://assetstore.unity.com/packages/tools/ai/s-goap-ai-solution-167167) integrado que nos ofrecerá componentes básicos con los  que  trabajar : 
 
 **Basic Agent (Script):** un componente que gestiona los objetivos y sus respectivas prioridades trazando planes periodicamente para saciarlos empleando un algoritmo **A*** para encontrar la ruta optima que llega  al objetivo a través de las acciones de menor coste.
 
 **Agent Goal System(Script)**: un script que permite reasignar prioridades a cada objetivo del agente en cada ciclo de juego.
 
 **Agent Runtime Action Data** : Gestiona la informacion que pueden usar la acciones en ejecucion como establecer un objetivo  para una acción de persecución.
 
 **Action (Script)** : es la base de todas las acciones que se programaran para los agentes.Al heredar de esta clase obtenemos una lista de  atributos de precondicion y una lista de  atributos de post condicion que usará el agente para trazar su plan y podemos añadir el comportamiento que sea preciso.
 
 # Diseño de la Solucion
 
 Para realizar este proyecto se va a utilizar un sistem ade GOAP que se basa en acciones y objetivos.El concepto es similar a los arboles de comportamiento  , se pueden agrupar comportamientos en orden pero a  diferencia de un arbol comportamiento el orden y los comportamientos no están predefinidos.Definimos un grupo de acciones que conducen a un grupo de objetivos y dependiendo de la situacion del agente y del coste de las acciones se ordenaran de una manera u otra para formar un plan de accion que nos permita cumplir el objetivo.
 ![diagrama ejemplo ](https://github.com/Bimbloc/IAV23-Sanchez-Horcajuelo/blob/main/daigramagoap.png)
 
 Las acciones constan de 3 partes  una precondicion que es aquello qeu debe cumplirse para qeu realizarla sea posible , un comportamiento algo que el agente hace y una post condicion qeu es lo qeu se cumple despues de haber ejecutado la accion.Cada acción ademas supone un coste que irá variando en funcion de las condiciones del agente y lo que le rodea.Las acciones se irán encadenando en un plan hasta qeu la post condicion de la ultima de llas sea el objetivo prioritario en el momento.
 ![diagrama ejemplo](https://github.com/Bimbloc/IAV23-Sanchez-Horcajuelo/blob/main/Actiondiagram.png)
 
 En particular los dinosaurios en este proyecto contarán con los siguientes objetivos:
 
 - No morir de hambre
 
 - No morir de sed 
 
 - No morir devorado
 
 - No morir de cansancio 
 
 Y los intentarán cumplir a través de las siguientes acciones : 
 
 - Dormir : el dinosaurio se detiene y recupera energía . Precondicion : no tiene , Post Condicion : No morir de cansancio
 
 - Buscar comida: el dinosaurio se mueve en direccines aleatorias hasta que encuentra comida. Precondicion : no tiene , Post condicion : encontré comida
 
 - Perseguir Comida : el dinosaurio ha fijado la comida como objetivo y lo persigue. Precondicion : encontré comida , Post condicion : tengo comida 
 
 - Comer: el dinosaurio usa la comida para saciar su hambre . Precondición : tengo comida , Post Condición : No morir de hambre 
 
 - Buscar presa : el dinosaurio se mueve en direcciones aleatorias hasta qeu divisa una presa . Precondicion : no tiene , Post condicion : tengo presa
 
 - Cazar : el dinosaurio ha encontrado una presa asi que la persigue.Preccondicion : tengo presa , Post condicion : tengo comida.
 
 - Huir : el dinosaurio divisa una amenaza asi que huye . Precondicion : no tiene , Post condicion : No morir devorado.
 
 - Buscar Agua : identico a buscar comida pero su post condicion es  enconré  agua.
 
 - Perseguir Agua : identico a perseguir comida.Pre condicion: encontré agua , post condicion :  tengo agua 
 
 - Beber : consume el agua , pre condicion tengo agua , post condicon no morir de sed.
 
 La **prioridad** de estos objetivos depende de diversas metricas , cuanto cansancion hayan acumulado cuanta hambre tengan o como de cerca se encuentra la amenaza.
 
 Prioridad No morir de hambre : directamente proporcional a la cantidad de hambre que tenga acumulada el dinosaurio , si llega a un maximo perederteminado este se desvanece.El hambre aumenta poco a poco simplemente con el paso del tiempo.Beber agua aumenta su hambre.
 
 Prioridad  No morir de sed : directamente proporcional a la cantidad de sed que tenga acumulada el dinosaurio , si llega a un maximo perederteminado este se desvanece.La sed aumenta poco a poco simplemente con el paso del tiempo.Comer comida te aumenta la sed.
  
 Prioridad No morir devorado : si el dinosaurio no ha detectado niguna amenaza esta metrica se mantiene a 0 .En caso de que haya una amenaza conocida la prioridad es inversamente porporcional a la distancia que separa al dinosaurio de la  amenaza , aumentando cuando la amenaza se acerca.
 
 Prioridad No morir de cansancio : directamente proporcional al cansancion acumulado del dinosaurio . A medida que el dinosaurio se mueve se va cansando.
 Si llega a un maximo predeterminado el dinosaurio se desvanece.
 
 Los **costes** de las acciones tambien depende de variables qeu iran variando en ejecucion:
 
 - Descansar : es la unica excepción ya que parar y no hacer nada  siempre tendrá coste 0.
 
 - Huir , Perseguir : cuanto más lejos esté el objetivo más caro será llegar.
 
 - Buscar Comida o Agua  : Si el olfato nos ha dado una  posicion aproximada el coste será la distancia hasta ese punto, si no el coste es directamente el rango ya que es lo máximo que se puede mover el agente.
 
 - Cazar : Seria el equivalente a  buscar presa y a parte  de aumentar con la distancia a la posicion aproximada o el rango tambien lo hace con el sueño pero decrementa a medida que el hambre del agente aumenta.

Las acciones se pueden generalizar  en acciones de busqueda , persecucion y uso . La soluciones se basarán en una estructura similar al pseudocodigo  mostrado a continuación: 

Acciones de Búsqueda : 
```python
While target == null :
 if DestinationReached()
   searchposition = GetRandomPositionInCircle(Range)
   SetDestination(searchposition)
 return Running
return Success 

```
Acciones de persecucion : 

```python
if not DestinationReached():
 return Running
else
 Agent.Stop()
 return Success 
```

Acciones de uso : 
```python
if object != null 
  object.Use()
``` 
 
 Todas las acciones se aseguran de que son usables  antes de activarse en su metodo pre perform y todas las acciones  activan su cooldown tras usarse ne su metodo post perfom.Las acciones tienen un metodo Dynamically evaluate cost donde  se les  asignan los  costes antes de elaborar el plan.
 
 ## Implementación de los Agentes inteligentes 
 ![imagenagentes](https://github.com/Bimbloc/IAV23-Sanchez-Horcajuelo/blob/main/Basicagents.PNG)
 
 Los agentes utilizan sensores para percibir el entorno acciones para interactuar con el y en este caso un unico sistema que se encargará del movimiento.
 Para recaudar información sobre el espacio de juego contarán con 2 sensores.Primero el sensor de vista compuesto por un sencillo cono de visión colocado en frente del agente  , un trigger que detecta los objetos que resulten interesantes para el agente como pueden ser la comida y el agua.
 Cuando un objeto detectable entra en el cono de visión el agente este pasa a conocer su posición exacta ya que oficialmente "puede verlo".
 El segundo sensor es el olfato conformado por un area circular alrederdor del agente (las lineas amarillas que se aprecian en la imagen) en cada tick 
 de física (FixedUpdate ()) se ejecuta una función que decta los objetos que se solapan con este cícurlo . Al oler objetos perceptibles el agente no sabe su posicion exacta pero si puede intuir la dirección en la que se encuentra.En las acciones de busqeuda la direccion de movimiento original es puramente
 aleatoria pero si "huele" el objeto que está buscando podemos usar la dirección que nos proporcionas el sensor para interporlarla con la direccion aleatoria y asi merodear hacia ese area : 
 ![vectores interpolados](https://github.com/Bimbloc/IAV23-Sanchez-Horcajuelo/blob/main/vectoresdino.png)
 # Pruebas y Métricas
 
 Para demostrar el correcto funcionamiento de la inteligencia artificial de los agentes se llevarán a cabo las siguientes pruebas. 
 
 **Prueba A** : Al iniciar el juego los dinosaurios tienen todos los requisitos de supervivencia al máximo pero a medida que se mueven se cansan y a medida que pasa el tiempo tienen más hambre.Nos centraremos en los herbivoros y observaremos como merodean hasta encontrar una planta que poder comer.
 
 **Prueba B** : Después de dejar la simulación  trabajando un rato los dinosaurios carnivoros tendrán hambre asi que intentarán cazar a los herviboros.Nos centraremos en los carnivoros y en sus distintos mecanismos para obtener comida que es lo que les diferencia de los herviboros. 
 
 **Prueba C** : En esta simulación los agentes cuentan con 2 sensores para percivir el entorno que les rodea, se  ejecuta el juego en modo de  depuracion para observar el correcto funcionamiento de estos sensores. 
 
 **Prueba D** : La simulación avanza y agentes empiezan a estar cansados , los dinosaurios herbivoros que estén lejos de una amenaza podrán dormir pero 
 aquellos que estén derca de carnivoros hambrientos deberán huir hasta dejarlos atrás.Los herviboros cuentan con una  corta memoria de unas  decimas de  segundo parar recordar la amenaza qeu les persigue asi qeu aun qeu dejen de percivirlos  seguirán huyendo un ratito más.
 
 [Video Con La Bateria de Pruebas](https://youtu.be/UU_z0fX-LNw)
 
 # Producción 
 
 Las tareas se han realizado y el esfuerzo ha sido repartido entre los autores.

| Estado | Tarea                                        | Fecha | Persona Asignada |
| :----: | :------------------------------------------- | :---: | :--------------- |
|   ✔    |  Documentación y diagramas | 11-05 | Rocío            |
|   ✔    | Prototipar para elegir plug-ins  | 10-05 | Rocío            |
|   ✔    | Crear agente base con tareas comunes   | 13-05 | Rocío            |
|   ✔    | Implementar interacciones con el ratón   | 15-05 | Rocío            |
|   ✔    |  Terminar la documentación   | 17-05 | Rocío            |
|   ✔   | Completar la implementacion de herviboros  |22-05| Rocío            |
|   ✔   | Completar la implementacion de carnivoros  | 22-05| Rocío            |
|  ✔   | Mejorar la estetica de la práctica  | 25-05| Rocío            |
|   ✔   |Grabar y editar bateria de pruebas  | 25-05| Rocío            |


# Referencias 
- Plug In de GOAPS en unty : [plug in de SGOAP](https://assetstore.unity.com/packages/tools/ai/s-goap-ai-solution-167167)
- Los Assets empleados son de  elaboración propia.



 
 

