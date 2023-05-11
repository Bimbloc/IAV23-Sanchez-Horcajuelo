using SGoap;
using SGOAP.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuscaComida : BasicAction
{
    // Start is called before the first frame update
    float cooldown = 0.3f;
   public  DinosaurRunrimeInfo runrimeInfo;
    public AgentRuntimeActionData RuntimeData;
    public MoveData MoveData;
    public MoveSystem MoveSystem;
    public float Range = 5;

    private Vector3 _startPosition;
    private Vector3 _destination;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override EActionStatus Perform()
    {
        _startPosition = runrimeInfo.Agent.transform.position;
        _destination = GetSeekPosition();
        if (runrimeInfo.GetTarget() == null)
        {
            Debug.Log("estoybuscandocomida" + runrimeInfo.GetTarget());
            MoveSystem.SetMoveData(MoveData);
            MoveSystem.SetDestination(_destination);

            if (MoveSystem.ReachedDestination())
            {
                _destination = GetSeekPosition();
            }
            return EActionStatus.Running;
        }
        Debug.Log("encontrada");
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
     Vector3 GetSeekPosition()
    {
        // Instead for production code, you'll want to sample a nav mesh position that matches.
        var newPosition = _startPosition + Random.insideUnitSphere * Range;
        newPosition.y = transform.position.y;
        return newPosition;
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
