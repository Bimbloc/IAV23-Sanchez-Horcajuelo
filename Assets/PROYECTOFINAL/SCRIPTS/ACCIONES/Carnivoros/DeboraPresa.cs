//Ficero elaborado para la asignatura Inteligencia Artificial en Videojuegos 
//por Rocio S�nchez
using SGoap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeboraPresa : BasicAction
{
    //Este script se uso en un portotipo del poryecto pero su funcion se dlego a otro archivo
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

        if (runtimedinfo.GetTargetPresa() != null)// puede que se lo haya comido otro 
            runtimedinfo.GetTargetPresa().GetComponent<Hervibore>().SerComido();
        runtimedinfo.SetTargetComida(null);
        runtimedinfo.hambre /= 4;
        runtimedinfo.sed++;
        runtimedinfo.sue�o++;
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
