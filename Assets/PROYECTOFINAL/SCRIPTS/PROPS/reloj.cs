using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class reloj : MonoBehaviour
{
    int tiempo = 0;
    [SerializeField]
    GameObject texto;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("AumentaTiempo", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AumentaTiempo()
    {

        tiempo++;
        texto.GetComponent<TextMeshProUGUI>().text = tiempo / 60 + ":" + (tiempo % 60);
    }

}
