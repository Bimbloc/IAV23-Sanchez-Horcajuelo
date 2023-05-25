using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class highscoreshow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = GameManager.GetInstance().GetBestTime() / 60 + ":" + GameManager.GetInstance().GetBestTime() % 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
