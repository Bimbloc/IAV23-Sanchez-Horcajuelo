using SGOAP.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosaurGoalSystem : AgentGoalSystem
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void  UpdateGoalPriorities()
    {
        Debug.Log("rawr");
    }
}