using SGoap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuscaComida : CoroutineAction
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override IEnumerator PerformRoutine()
    {
        Debug.Log("estoybuscandocomida");
        yield return null;
    }
    }
