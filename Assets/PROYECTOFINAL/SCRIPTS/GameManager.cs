using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    int numherviboros = 7;
    private static GameManager instance;
    public static GameManager GetInstance()
    {
        return instance;
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        { Destroy(this.gameObject); }
    }
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void QuitarHerviboro()
    {

        numherviboros--;
        if (numherviboros <= 0)
        {

            Debug.Log("sE ACABO EL JUEGO");
        
        }

    

    }
}
