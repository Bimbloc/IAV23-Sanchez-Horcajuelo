using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vista : MonoBehaviour
{
    // Start is called before the first frame update
    public DinosaurRunrimeInfo runrimeInfo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    { 

        //el raycast no me da el objeto con el qeu choco :/
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Comida>())
        runrimeInfo.SetTargetComida(other.gameObject);
        if(other.GetComponent<Agua>())
            runrimeInfo.SetTargetAgua(other.gameObject);
    }
}
