using SGoap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuscaComida : CoroutineAction
{
    // Start is called before the first frame update
    float cooldown = 0.3f;
   public  DinosaurRunrimeInfo runrimeInfo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override IEnumerator PerformRoutine()
    {
        
        //mientras no la encuntre sigo 
        while (runrimeInfo.GetTarget()==null)
        {
            Debug.Log("estoybuscandocomida" + runrimeInfo.GetTarget());
            yield return null;
        }
        Debug.Log("encontrada");
        yield  break;
    }
    }
