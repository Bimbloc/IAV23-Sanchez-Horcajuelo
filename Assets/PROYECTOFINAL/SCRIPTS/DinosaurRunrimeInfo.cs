using SGOAP.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosaurRunrimeInfo : AgentRuntimeActionData
{      // basicamente una blackboard
    // Start is called before the first frame update
    //Toda la informacion del estado del dinosaurio si tiene hambe sed si está cazando , huyendo...
    GameObject objetivo = null; //El sensor de vista aportará valor a esta variable
    void Start()
    {
        
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
    
}
