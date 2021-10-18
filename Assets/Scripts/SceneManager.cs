using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchToStartMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void SwitchToGameScreen()
    {
         UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void SwitchToGameOverScreen()
    {
         UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    public void SwitchToWinStateScreen()
    {
         UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }

    public void QuitGame()
    {
         Application.Quit();
    }
}