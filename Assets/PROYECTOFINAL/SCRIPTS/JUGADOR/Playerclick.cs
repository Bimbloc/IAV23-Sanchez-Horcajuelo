using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerclick : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 newPosition;
    public Plane groundplane;

    public GameObject ground; 

    public GameObject ComidaPlanta;
    public GameObject ComidaCarne;
    int cooldown = 46;
    int lastclick = 0; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lastclick > cooldown)
        {
            if (Input.GetMouseButton(0)) // vamos a spawnear comida para los dinosaurios al clickar (click izquierdo vegetales)
            {
                Vector2 mousePos = Input.mousePosition;
                newPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));
                // newPosition.y = 0; origen del frustrum de la camara 
                // newPosition.x *= groundplane.transform.localScale.x;
                //newPosition.z *= groundplane.transform.localScale.z;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                newPosition = ray.GetPoint(newPosition.y);
                // vamos a crearlo ligeramente sobre el suelo :
                newPosition.y = ground.transform.position.y + ComidaCarne.transform.position.y;
                Instantiate(ComidaPlanta, newPosition, Quaternion.identity);
                lastclick = 0;
            }
            if (Input.GetMouseButton(1))
            {
                Vector2 mousePos = Input.mousePosition;
                newPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                newPosition = ray.GetPoint(newPosition.y);

                // vamos a crearlo ligeramente sobre el suelo :
                newPosition.y = ground.transform.position.y + ComidaCarne.transform.position.y;

                Instantiate(ComidaCarne, newPosition, Quaternion.identity);
                lastclick = 0;

                // Debug.Log(newPosition);

            }
        }

        lastclick++;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(newPosition, 1);
    }

}
