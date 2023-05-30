//Ficero elaborado para la asignatura Inteligencia Artificial en Videojuegos 
//por Rocio S�nchez
using SGoap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beber : BasicAction
{
    /// <summary>
    /// El agente ha llegado a una fuente de agua.
    /// La utiliza y actualiza sus constantes vitales.
    /// </summary>
    public DinosaurRunrimeInfo runtimedinfo;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override bool PrePerform()
    {
        // By default if the action is cooling down, this returns false.
        return base.PrePerform();
    }

    public override EActionStatus Perform()
    {
        //llegados a este punto el target solo puede ser comida 

        runtimedinfo.GetTargetAgua().GetComponent<Agua>().Beber();
        runtimedinfo.SetTargetAgua(null);
        runtimedinfo.sed/=3;
        runtimedinfo.hambre++;
        return EActionStatus.Success;
    }

    public override bool PostPerform()
    {
        // By default, when post perform happens, the Agent is staggered and has a cool down. You can override.
        return base.PostPerform();
    }

    // Decide what your Agent will do when the action fails, i.e cancel an animation or play an Angry animation!
    public override void OnFailed()
    {
        base.OnFailed();
    }
}
