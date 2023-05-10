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
 
 
 
 

