using SGOAP.Examples;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DinosaurGoalSystem : AgentGoalSystem
{
    public DinosaurRunrimeInfo runtimedinfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame en el padre y llama a  updatear  prioridades
    public override void  UpdateGoalPriorities()
    {
        //  Debug.Log("rawr");
        var hambreGoal = AgentRuntimeData.Agent.Goals.FirstOrDefault(x => x.Key == "Nomorirdehambre");
        var sue�oGoal = AgentRuntimeData.Agent.Goals.FirstOrDefault(x => x.Key == "Nomorirdeagotamiento");
        var sedGoal = AgentRuntimeData.Agent.Goals.FirstOrDefault(x => x.Key == "Nomorirdesed");
        var huirGoal = AgentRuntimeData.Agent.Goals.FirstOrDefault(x => x.Key == "Nomorirdevorado");
        hambreGoal.Priority = runtimedinfo.hambre;
        sue�oGoal.Priority = runtimedinfo.sue�o;
        sedGoal.Priority = runtimedinfo.sed;
        if (huirGoal != null)
        {
          
            if (runtimedinfo.ClosestPredator == null)
            {
                huirGoal.Priority = 0;
            }
            else
                huirGoal.Priority = (int)(1000 / Vector3.Magnitude(transform.position - runtimedinfo.ClosestPredator.position)) ;
          //  Debug.Log(huirGoal.Priority);
        }
        AgentRuntimeData.Agent.UpdateGoalOrderCache();

    }
}
