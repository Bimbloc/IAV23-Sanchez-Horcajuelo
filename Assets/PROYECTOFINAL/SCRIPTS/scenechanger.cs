using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {

        SceneManager.LoadScene("escena");


    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("menu");

    }
    public void ExitGame()
    {

        Application.Quit();
    }
}
