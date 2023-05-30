//Ficero elaborado para la asignatura Inteligencia Artificial en Videojuegos 
//por Rocio S�nchez
using SGOAP.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersigueAgua : MoveToAction
{
    public DinosaurRunrimeInfo runtimedinfo;

   /// <summary>
   /// El agente ha recibido  una posicion concreta de los sentidos
   /// Se aproxima a ella para poder consumir agua.
   /// </summary>
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public override Transform GetDestination()
    {
        return runtimedinfo.GetTargetAgua().transform;
    }
    public override IEnumerator PerformRoutine()
    {
        MoveSystem.SetMoveData(MoveData);
        MoveSystem.SetDestination(Destination.position);
        Log($"Set Destination: {Destination.position}");

        while (!MoveSystem.ReachedDestination())
        {
            if (Destination == null)
                break;

            MoveSystem.SetDestination(Destination.position);
            yield return null;
        }

        MoveSystem.Stop();

        //Log("Executing");
        yield return Execute();
        // Log("Executed");
        // Debug.Log("PERSIGO");
        yield break;
    }
}
