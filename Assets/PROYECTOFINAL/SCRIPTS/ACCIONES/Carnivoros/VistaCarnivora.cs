using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VistaCarnivora : MonoBehaviour
{
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
        if (other.GetComponent<Comida>() && other.GetComponent<Comida>().type == runrimeInfo.AgentCharacter.foodtype)
            runrimeInfo.SetTargetComida(other.gameObject);
        if (other.GetComponent<Agua>())
        {
            runrimeInfo.SetTargetAgua(other.gameObject);
            // Debug.Log("Veo Agua");
        }
        if (other.GetComponent<Hervibore>())
        {
            runrimeInfo.SetTargetPresa(other.gameObject);
        }
    }
}
