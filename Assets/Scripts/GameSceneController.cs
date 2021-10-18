using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    [SerializeField] bool isPaused;
    [SerializeField] bool gameStarted;
    [SerializeField] GameObject PauseCanvas;
    [SerializeField] GameObject StartCanvas;
    [SerializeField] Paddle paddle;
    [SerializeField] Ball ball;
    [SerializeField] int layersBroken;
    // Start is called before the first frame update
    void Start()
    {
        FindComponents();
        layersBroken = 0;
        Cursor.visible = false;
        gameStarted = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForPause();
        CheckForStart();
    }

   void FindComponents()
   {
       paddle = FindObjectOfType<Paddle>();
       ball = FindObjectOfType<Ball>();
   }


   void CheckForStart()
   {
       if(!gameStarted)
       {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            gameStarted = true;
            StartCanvas.transform.GetChild(0).gameObject.SetActive(false);
            ball.StartGame();
        }
       }
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
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Time.timeScale = 1;
                PauseCanvas.transform.GetChild(0).gameObject.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public void IncrementLayersBroken()
    {
        layersBroken += 1;
    }
}
