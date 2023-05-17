using SGOAP.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hervibore : Character
{
      // Que tipo de dinosaurio es . Los carnivoros atacan a los herbiboros pero no entre ellos
     // Como interactua con la comida
    // Como interactua con otros herviboros
   // Como interactua con carnivoros
  // Start is called before the first frame update
  // El plugin usa scriptable objects pero vamos a usar colisiones y ya
    
    void Start()
    {
        foodtype = 0;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public  void SerComido()
    {
        Destroy(this.gameObject);

    }
}
