using SGoap;
using SGOAP.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Descansar :BasicAction
{
    public DinosaurRunrimeInfo runtimedinfo;
    public MoveSystem movsys;
    //descansar va  a tener mazo cooldown por que si no está to el rato a base de micro siestas
    public float cooldown = 6f;
   public  int potencia = 1;
    public int duracion = 3;
    int count;
    public override float StaggerTime => cooldown;
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
        count = 0;
        return base.PrePerform();
    }

    public override EActionStatus Perform()
    {
        //llegados a este punto el target solo puede ser comida 
        potencia = runtimedinfo.sueño / duracion;
        runtimedinfo.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        movsys.Stop();
        transform.parent.parent.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        //Debug.Log("zzz");
        runtimedinfo.sueño-=potencia;
        runtimedinfo.sed ++;
        count++;
        if (count == duracion)
        {
            runtimedinfo.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            return EActionStatus.Success;
        }
        else
            return EActionStatus.Running;
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
