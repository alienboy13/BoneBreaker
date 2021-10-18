using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] Camera gameCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveToMatchMouseCursor();
    }

    void MoveToMatchMouseCursor()
    {
        Vector3 mousePos = gameCamera.ScreenToWorldPoint(Input.mousePosition);
            
                if(-5f <= mousePos.x && mousePos.x <= 5f)
                {
                    this.transform.position =  new Vector3(mousePos.x,transform.position.y, transform.position.z);
                }
            
    }
}
