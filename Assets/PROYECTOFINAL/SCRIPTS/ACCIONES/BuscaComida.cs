using SGoap;
using SGOAP.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuscaComida : BasicAction
{
    // Start is called before the first frame update
    public float cooldown = 0.3f;
 
    public  DinosaurRunrimeInfo runrimeInfo;
    public AgentRuntimeActionData RuntimeData;
    public MoveData MoveData;
    public MoveSystem MoveSystem;
    public float Range = 5;
    Vector3 newPosition;
    public override float StaggerTime => cooldown;
    private Vector3 _startPosition;
    private Vector3 _destination;

    void Awake()
    {
       /* MoveSystem.ClearPath();
        _startPosition = runrimeInfo.Agent.transform.position;
        newPosition = (_startPosition + transform.forward) + Random.insideUnitSphere * Range;
        while (!Inplayablearea(newPosition))
        { newPosition = _startPosition + Random.insideUnitSphere * Range; }
        newPosition.y = transform.position.y;
        Debug.Log("c " + newPosition);
        MoveSystem.SetDestination(_destination);*/
    }
    void Start()
    {
        /*newPosition = (_startPosition + transform.forward) + Random.insideUnitSphere * Range;
        while (!Inplayablearea(newPosition))
        { newPosition = _startPosition + Random.insideUnitSphere * Range; }*/
        MoveSystem.ClearPath();
        _startPosition = runrimeInfo.Agent.transform.position;
        newPosition = (_startPosition + transform.forward) + Random.insideUnitSphere * Range;
        while (!Inplayablearea(newPosition))
        { newPosition = _startPosition + Random.insideUnitSphere * Range; }
        newPosition.y = transform.position.y;
        _destination = newPosition;
        MoveSystem.SetDestination(_destination);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override EActionStatus Perform()
    {
        _startPosition = runrimeInfo.Agent.transform.position;
       // _destination = GetSeekPosition();
        //Debug.Log("BuscaComida");
        if (runrimeInfo.GetTargetComida() == null)
        {
            //Debug.Log("estoybuscandocomida" + runrimeInfo.GetTarget());
            MoveSystem.SetMoveData(MoveData);
            MoveSystem.SetDestination(_destination);

            if (MoveSystem.ReachedDestination())
            {
                _destination = GetSeekPosition();
            }
            return EActionStatus.Running;
        }
      //  Debug.Log("encontrada");
        return EActionStatus.Success;
    }
    public override void DynamicallyEvaluateCost()
    {
        base.DynamicallyEvaluateCost();
        //el coste es la distancia hasta el punto al que vamos 
        if (runrimeInfo.ClosetsComida() != null)
        {
            Cost = Mathf.Abs(Vector3.Magnitude(runrimeInfo.ClosetsComida().position - transform.position));
               
        }
        else
            Cost = Range;
    }
    public override bool PrePerform()
    {
        // By default, when post perform happens, the Agent is staggered and has a cool down. You can override.
        if (MoveSystem.ReachedDestination())
        {
            _destination = GetSeekPosition();
        }
        return base.PrePerform();
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
     Vector3 GetSeekPosition()
    {
        _startPosition = runrimeInfo.Agent.transform.position;
        newPosition =( _startPosition  + transform.forward ) + Random.insideUnitSphere * Range;
        while(!Inplayablearea(newPosition + transform.forward))
        { newPosition = _startPosition + Random.insideUnitSphere * Range; }
       
        if(runrimeInfo.ClosetsComida()!= null)
        {
            //Debug.Log("Comida Cercana ");
            // newPosition +=   (runrimeInfo.ClosetsComida().position - newPosition)/2;     
            newPosition = Vector3.Slerp(runrimeInfo.ClosetsComida().position, newPosition, 0.5f);
        }
        newPosition.y = transform.position.y;
        return newPosition;
    }
    bool Inplayablearea(Vector3 p)
    {
        GameObject area = runrimeInfo.playablearea;
        //las esquinas
        int xmax = (int)area.transform.position.x + (int)(area.transform.localScale.x / 2);
        int xmin = (int)area.transform.position.x - (int)(area.transform.localScale.x / 2);
        int zmax = (int)area.transform.position.z + (int)(area.transform.localScale.z / 2);
        int zmin = (int)area.transform.position.z -(int)(area.transform.localScale.z/ 2);
        return (p.x < xmax && p.x > xmin && p.z < zmax && p.z > zmin);
        //return (p.x < (area.transform.position.x + area.transform.localScale.x / 2) && p.x > (area.transform.position.x - area.transform.localScale.x / 2) && p.z < (area.transform.position.z + area.transform.localScale.z / 2) && p.z > (area.transform.position.z + area.transform.localScale.z / 2));

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(newPosition, 1);
    }

    /*public override IEnumerator PerformRoutine()
    {
        while (runrimeInfo.GetTarget() == null)
        {
            Debug.Log("estoybuscandocomida" + runrimeInfo.GetTarget());
            // return EActionStatus.Running;
            yield return new WaitForSeconds(2);
        }
        Debug.Log("encontrada");
        yield return null; 



    }*/
    /* public override bool PrePerform() => !Cooldown.Active;

     public override bool PostPerform()
     {
         Cooldown.Run(CooldownTime);
         //AgentData.Cooldown.Run(StaggerTime);
         return true;
     }
     public override EActionStatus Perform()
     {

         //mientras no la encuntre sigo 
         if (runrimeInfo.GetTarget()==null)
         {
             Debug.Log("estoybuscandocomida" + runrimeInfo.GetTarget());
             return EActionStatus.Running;
         }
         Debug.Log("encontrada");
         return EActionStatus.Success; Action deuvlev esucccess per se sigue haciendo

     }*/
}
