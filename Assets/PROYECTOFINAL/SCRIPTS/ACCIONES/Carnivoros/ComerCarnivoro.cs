//Ficero elaborado para la asignatura Inteligencia Artificial en Videojuegos 
//por Rocio Sánchez
using SGoap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComerCarnivoro : BasicAction
{
    /// <summary>
    /// El agente ha llegado a una fuente de comida 
    /// la procesa y actualiza las constantes vitales.
    /// </summary>
    public DinosaurRunrimeInfo runtimedinfo;
    // Start is called before the first frame update
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

        if (runtimedinfo.GetTargetComida() != null)// puede que se lo haya comido otro 
        {
            runtimedinfo.GetTargetComida().GetComponent<Comida>().Comer();
            runtimedinfo.SetTargetComida(null);
            runtimedinfo.hambre /= 3;
            runtimedinfo.sed++;
            runtimedinfo.sueño++;
        }
        else if (runtimedinfo.GetTargetPresa()!=null)
        {
            //destruir el otro dinosaurio 
            runtimedinfo.GetTargetPresa().GetComponent<Hervibore>().SerComido();
            runtimedinfo.hambre /= 4;
            runtimedinfo.sed++;
            runtimedinfo.sueño++;

        }
       
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
