using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    int numherviboros = 7;
    int partidatime;
    [SerializeField]
    reloj clock;
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
            partidatime = clock.GetTime();
            Debug.Log("sE ACABO EL JUEGO");
            SceneManager.LoadScene("ending");


        }

    

    }
    public int GetBestTime()
    {

        return partidatime;
    }
}
