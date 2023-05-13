using SGOAP.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosaurRunrimeInfo : AgentRuntimeActionData
{      // basicamente una blackboard
    // Start is called before the first frame update
    //Toda la informacion del estado del dinosaurio si tiene hambe sed si est� cazando , huyendo...
    GameObject comida = null; //El sensor de vista aportar� valor a esta variable
    GameObject agua = null; 
   public  int hambre = 0;
   public  int sue�o = 0;
    public int sed = 0;
    int habrecooldown=4;// cuanto timepo aumenta el hambre
    int sue�ocooldown=8; // cada cuanto tiempo aumenta el sue�o
    int sedcooldown = 4; // cuanto timepo aumenta la sed 

    Vector3 prevposs;// el sue�o depende de cuanto nos movamos , cuanto mas nos movemos mas nos cansamos
    void Start()
    {
        prevposs = transform.position;
        InvokeRepeating("GanarHambre", habrecooldown, habrecooldown);
        InvokeRepeating("GanarSue�o", sue�ocooldown, sue�ocooldown);
        InvokeRepeating("GanarSed", sedcooldown, sedcooldown);
    }
    public void SetTargetComida(GameObject o)
    {
      comida = o;
    
    }
    public GameObject GetTargetComida()
    {
        return comida;
    
    }
    public void SetTargetAgua(GameObject o)
    {

        agua = o;
    }

    public GameObject GetTargetAgua()
    {
        return agua;
    }
    // Update is called once per frame
    void GanarHambre()
    {
        hambre++;
    }
    void GanarSue�o()
    {

        Vector3 desp =new Vector3( Mathf.Abs( transform.position.x - prevposs.x), Mathf.Abs(transform.position.y - prevposs.y), Mathf.Abs(transform.position.z - prevposs.z));
        sue�o+=( int ) desp.magnitude;
        prevposs = transform.position;
    }
    void GanarSed()
    {

        sed++;

    }
}
