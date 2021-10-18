using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    [SerializeField] bool gameStarted;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Vector2 ballVelocity;
    [SerializeField] float ballSpeed;
    [SerializeField] float randomTolerance;
    [SerializeField] float maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        FindComponents();
        gameStarted = false;
        maxSpeed = 2.0f;
        ballVelocity = new Vector2(0.0f, maxSpeed);
        randomTolerance = .2f;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStarted)
        {
            JohnsFailsafe();
        }
        else
        {
            LockToPaddle();
        }
    }

    void FindComponents()
    {
        paddle = FindObjectOfType<Paddle>();
        rb = GetComponent<Rigidbody2D>();
    }

    void LockToPaddle()
    {
        transform.position = new Vector3(paddle.gameObject.transform.position.x, transform.position.y, transform.position.z);
    }

    void GameBehavior()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
        {
            float xspeed = 0;
            float yspeed = 0;
            if(collision.collider.ClosestPoint(transform.position).y != transform.position.y)
            {
                yspeed = -ballVelocity.y;
                int directionFactor = Random.Range(1,10);
                if(directionFactor > 5)
                {
                    xspeed = Random.Range(maxSpeed-randomTolerance, maxSpeed);
                }
                else
                {
                    xspeed = -Random.Range(maxSpeed-randomTolerance, maxSpeed);
                }
            }
            else if(collision.collider.ClosestPoint(transform.position).x != transform.position.x)
            {
                xspeed = -ballVelocity.x;
                int directionFactor = Random.Range(1,10);
                if(directionFactor > 5)
                {
                    yspeed = Random.Range(maxSpeed-randomTolerance, maxSpeed);
                }
                else
                {
                    yspeed = -Random.Range(maxSpeed-randomTolerance, maxSpeed);
                }
            }
            else
            {
                yspeed = -ballVelocity.y;
                xspeed = -ballVelocity.x;
            }
           
            ballVelocity = new Vector2(xspeed, yspeed);
            rb.velocity = ballVelocity;
        }

    public void JohnsFailsafe()
    {
        float yspeed;
        float xspeed;
        if(rb.velocity.x == 0f || rb.velocity.y == 0f)
        {
            int directionFactor = Random.Range(1,10);
            if(directionFactor > 5)
                {
                    yspeed = -Random.Range(maxSpeed-randomTolerance, maxSpeed);
                }
            else
                {
                    yspeed = Random.Range(maxSpeed-randomTolerance, maxSpeed);
                }
            directionFactor = Random.Range(1,10);
            if(directionFactor > 5)
                {
                    xspeed = -Random.Range(maxSpeed-randomTolerance, maxSpeed);
                }
            else
                {
                    xspeed = Random.Range(maxSpeed-randomTolerance, maxSpeed);
                }
            
            rb.velocity = new Vector3(xspeed, yspeed);
        }
    }
    public void StartGame()
    {
        rb.velocity = ballVelocity;
        gameStarted = true;
    }
}
