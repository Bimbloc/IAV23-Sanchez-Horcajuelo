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
 
 No morir de hambre
 
 No morir devorado
 
 No morir de cansancio 
 
 Y los intentarán cumplir a través de las siguientes acciones : 
 
 Dormir : el dinosaurio se detiene y recupera energía . Precondicion : no tiene , Post Condicion : No morir de cansancio
 Buscar comida: el dinosaurio se mueve en direccines aleatorias hasta que encuentra comida. Precondicion : no tiene , Post condicion : tengo comida
 Comer: el dinosaurio usa la comid para saciar su hambre . Precondición : tengo comida , Post Condición : No morir de hambre 
 buscar presa : el dinosaurio se mueve en direcciones aleatorias hasta qeu divisa una presa . Precondicion : no tiene , Post condicion : tengo presa
 Cazar : el dinosaurio ha encontrado una presa asi que la persigue.Preccondicion : tengo presa , Post condicion : tengo comida.
 Huir : el dinosaurio divisa una amenaza asi que huye . Precondicion : no tiene , Post condicion : No morir devorado.
 
 La prioridad de estos objetivos depende de diversas metricas , cuanto cansancion hayan acumulado cuanta hambre tengan o como de cerca se encuentra la amenaza.
 
 # Pruebas y Métricas
 
 
 
 
 

