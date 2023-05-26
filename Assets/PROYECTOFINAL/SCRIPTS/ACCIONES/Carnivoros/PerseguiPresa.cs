using SGoap;
using SGOAP.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerseguiPresa : MoveToAction
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
        if (runtimedinfo.GetTargetPresa() != null)
            return runtimedinfo.GetTargetPresa().transform;
        else return null;
    }
    public override IEnumerator PerformRoutine()
    {
        MoveSystem.SetMoveData(MoveData);
        if (Destination != null)
        {
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
            runtimedinfo.GetTargetPresa().GetComponent<Hervibore>().SerComido();
            runtimedinfo.hambre /= 4;
        }
        //Log("Executing");
        yield return Execute();
        // Log("Executed");
        // Debug.Log("PERSIGO");
        yield break;
    }
}
