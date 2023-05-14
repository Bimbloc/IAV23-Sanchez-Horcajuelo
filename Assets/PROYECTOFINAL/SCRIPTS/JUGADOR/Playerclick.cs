using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerclick : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 newPosition;
    public Plane groundplane;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // vamos a spawnear comida para los dinosaurios al clickar
        {
            Vector2 mousePos = Input.mousePosition;
         newPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));
            // newPosition.y = 0; origen del frustrum de la camara 
            // newPosition.x *= groundplane.transform.localScale.x;
            //newPosition.z *= groundplane.transform.localScale.z;
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
                newPosition = ray.GetPoint(newPosition.y);
                Debug.Log(newPosition);

            
        }
     
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(newPosition, 1);
    }

}
