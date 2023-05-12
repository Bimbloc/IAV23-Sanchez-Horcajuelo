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
    int habrecooldown=4;
    int sueñocooldown=4; 
    void Start()
    {
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

        sueño++;
    }
}
