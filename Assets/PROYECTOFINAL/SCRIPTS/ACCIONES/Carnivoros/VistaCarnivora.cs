//Ficero elaborado para la asignatura Inteligencia Artificial en Videojuegos 
//por Rocio Sánchez
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VistaCarnivora : MonoBehaviour
{
    /// <summary>
    /// Un area en frente del agnete detecta el agua la comida 
    /// y las presas que chocan con ella.
    /// </summary>
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
