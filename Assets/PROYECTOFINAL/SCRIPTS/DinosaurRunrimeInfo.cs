using SGOAP.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosaurRunrimeInfo : AgentRuntimeActionData
{      // basicamente una blackboard
    // Start is called before the first frame update
    //Toda la informacion del estado del dinosaurio si tiene hambe sed si está cazando , huyendo...
    GameObject objetivo = null; //El sensor de vista aportará valor a esta variable
   public  int hambre = 0;
   public  int sueño = 0;
    int habrecooldown=4;// cuanto timepo aumenta el hambre
    int sueñocooldown=8; // cada cuanto tiempo aumenta el sueño

    Vector3 prevposs;// el sueño depende de cuanto nos movamos , cuanto mas nos movemos mas nos cansamos
    void Start()
    {
        prevposs = transform.position;
        InvokeRepeating("GanarHambre", habrecooldown, habrecooldown);
        InvokeRepeating("GanarSueño", sueñocooldown, sueñocooldown);
    }
    public void SetTarget(GameObject o)
    {
        objetivo = o;
    
    }
    public GameObject GetTarget()
    {
        return objetivo;
    
    }
    // Update is called once per frame
    void GanarHambre()
    {
        hambre++;
    }
    void GanarSueño()
    {

        Vector3 desp =new Vector3( Mathf.Abs( transform.position.x - prevposs.x), Mathf.Abs(transform.position.y - prevposs.y), Mathf.Abs(transform.position.z - prevposs.z));
        sueño+=( int ) desp.magnitude;
        prevposs = transform.position;
    }
}
