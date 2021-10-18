using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Block : MonoBehaviour
{
    [SerializeField] List<Sprite> damageSprites = new List<Sprite>();
    [SerializeField] SpriteRenderer blockSprite;
    [SerializeField] int health;
    [SerializeField] GameSceneController controller;
    [SerializeField] Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        FindComponents();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.GetComponent<Ball>() != null)
        {
            health -= 1;
            controller.IncrementLayersBroken();
            if(health > 0)
            {
                blockSprite.sprite = damageSprites[health-1];
            }
            else
            {
                Destroy(this.gameObject);
            }
            
        }
    }

    void FindComponents()
    {
        rb = FindObjectOfType<Rigidbody2D>();
        controller = FindObjectOfType<GameSceneController>();
        blockSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }
}
