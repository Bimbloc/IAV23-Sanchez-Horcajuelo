using SGOAP.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huir : MoveToAction
{
    public DinosaurRunrimeInfo runtimedinfo;
    GameObject g;
    private void Start()
    {
       g = new GameObject();
    }
    public override Transform GetDestination()
    {
        Debug.Log(runtimedinfo.ClosestPredator);
        if (runtimedinfo.ClosestPredator != null)
        {
            Vector3 pos = transform.position - runtimedinfo.ClosestPredator.position;
            g.transform.position = pos + runtimedinfo.ClosestPredator.forward;
            return g.transform;
        }
        else
            return transform;
    
    }

    public override IEnumerator PerformRoutine()
    {
        MoveSystem.SetMoveData(MoveData);
        MoveSystem.SetDestination(Destination.position);
        Log($"Set Destination: {Destination.position}");

        while (!MoveSystem.ReachedDestination())
        {
            if (Destination == null)
                break;

            MoveSystem.SetDestination(Destination.position);
            yield return null;
        }

        MoveSystem.Stop();
       
        //Log("Executing");
        yield return Execute();
        // Log("Executed");
        // Debug.Log("PERSIGO");
        yield break;
    }
    void OnDrawGizmos()
    { if (runtimedinfo.ClosestPredator != null)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawSphere(g.transform.position, 1);
        }
    }

}
