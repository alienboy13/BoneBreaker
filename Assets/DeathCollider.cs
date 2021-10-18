using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour
{
    [SerializeField] GameSceneController controller;
    // Start is called before the first frame update
    void Start()
    {
        FindComponents();
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        controller.FailLevel();
    }

    void FindComponents()
    {
        controller = FindObjectOfType<GameSceneController>();
    }
}
