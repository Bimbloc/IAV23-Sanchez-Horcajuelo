using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muro : MonoBehaviour
{
    int life = 5; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Carnivore>())
        {
            Debug.Log("muro");
            life--;
        }
        if(life<=0)
        {


            Destroy(this.gameObject);

        }
    }
}
