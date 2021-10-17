using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    [SerializeField] bool isPaused;
    [SerializeField] GameObject PauseCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForPause();
    }


    void CheckForPause()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if(isPaused)
            {
                Time.timeScale = 0;
                PauseCanvas.transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                PauseCanvas.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}
