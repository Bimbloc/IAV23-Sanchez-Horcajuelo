//Ficero elaborado para la asignatura Inteligencia Artificial en Videojuegos 
//por Rocio Sánchez
using SGoap;
using SGOAP.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerseguiPresa : MoveToAction
{
    //El agente se aproxima a la posicion de la presa y 
    // una vez llega  a ella  la devora.
    public DinosaurRunrimeInfo runtimedinfo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //si nuestra presa sigue ahi obtenemos su posicion para perseguirla.
    public override Transform GetDestination()
    {
        if (runtimedinfo.GetTargetPresa() != null) //puede que otro carnivoro la haya devorado antes asi que hay que realizar esta comporbacion
            return runtimedinfo.GetTargetPresa().transform;
        else return null;
    }
    public override IEnumerator PerformRoutine()
    {
        MoveSystem.SetMoveData(MoveData);
        if (Destination != null) //si tenemos pobjetivo nos movemos hacia el 
        {
            MoveSystem.SetDestination(Destination.position);
            Log($"Set Destination: {Destination.position}");

            while (!MoveSystem.ReachedDestination())
            {
                if (Destination == null)
                    break;

                MoveSystem.SetDestination(Destination.position);
                yield return null;
            }
            //una vez hemos llegado nos detemos y procesamos la presa.
            MoveSystem.Stop();
            runtimedinfo.GetTargetPresa().GetComponent<Hervibore>().SerComido();
            runtimedinfo.hambre /= 4;
        }
        //Log("Executing");
        yield return Execute();
        // Log("Executed");
        // Debug.Log("PERSIGO");
        yield break;
    }
}
