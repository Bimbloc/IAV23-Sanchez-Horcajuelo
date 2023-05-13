using SGOAP.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersigueAgua : MoveToAction
{
    public DinosaurRunrimeInfo runtimedinfo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public override Transform GetDestination()
    {
        return runtimedinfo.GetTargetAgua().transform;
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
}
