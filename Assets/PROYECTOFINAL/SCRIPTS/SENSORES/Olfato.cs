using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Olfato : MonoBehaviour
{
    public DinosaurRunrimeInfo runtimedinfo;
    [Header("Ajustes")]
    public LayerMask Layer;
    public int memory= 10;

    [Range(0, 360)]
    public float Radio = 20;
    public float Rango = 15;
    public float Altura = 100;

    [Header("Info")]
    public Collider[] Objetosencirculo;
    public Transform  AguaCercana;// objetos que no ven pero si huelen, su posicion influencia la direccion en la que merodea el dinosaurio
    public Transform ComidaCercana;
    public Transform DepredadorCercano;

   int  count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void FixedUpdate()
    {
        
        int closestcomidadistancia = int.MaxValue;
        int closestaguadistancia = int.MaxValue ;
        int closestpredatordistancia = int.MaxValue;
        AguaCercana = null;
        ComidaCercana = null;
        DepredadorCercano = null;
        Objetosencirculo = Physics.OverlapSphere(transform.position, Radio, Layer);
       
        foreach (Collider c in Objetosencirculo)
        {
            if (c.gameObject.GetComponent<Comida>() && c.gameObject.GetComponent<Comida>().type == runtimedinfo.AgentCharacter.foodtype)
            {
                int distanciaactual = (int)Mathf.Abs(Vector3.Magnitude(transform.position - c.transform.position));//la distancia a la comida 
                if (closestcomidadistancia > distanciaactual)
                {

                    closestcomidadistancia = distanciaactual;
                    ComidaCercana = c.transform;
                }
            }
            else if (c.gameObject.GetComponent<Agua>())
            {
                int distanciaactual = (int)Mathf.Abs(Vector3.Magnitude(transform.position - c.transform.position));//la distancia a la comida 
                if (closestaguadistancia > distanciaactual)
                {

                    closestaguadistancia = distanciaactual;
                    AguaCercana = c.transform;
                }
            }
            else if (c.gameObject.GetComponent<Carnivore>())
            {
               
                int distanciaactual = (int)Mathf.Abs(Vector3.Magnitude(transform.position - c.transform.position));//la distancia a la comida 
                if (closestpredatordistancia > distanciaactual)
                {

                    closestpredatordistancia = distanciaactual;
                    DepredadorCercano = c.transform;
                }

            }
        }
        count++;
        runtimedinfo.SetClosestAgua(AguaCercana);
        runtimedinfo.SetClosestComida(ComidaCercana);
        if (DepredadorCercano == null) // se va  a olvidar pero solo si han pasado los x ciclos de memoria qeu tiene 
        {
            if(count >= memory)
            runtimedinfo.ClosestPredator = DepredadorCercano;

        }
        else // lo va  a cambiar por otro qeu es el qeu est amas cerca hora 
        {
            runtimedinfo.ClosestPredator = DepredadorCercano;
            count = 0;
        }

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Radio);

    }
}
