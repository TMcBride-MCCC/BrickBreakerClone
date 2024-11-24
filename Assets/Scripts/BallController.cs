using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    //Get the ball's rigidbody
    private Rigidbody2D ballRB;
    //Set moving to false to allow for start launch
    private bool ballMoving = false;
    //Set the starting launch force
    private float launchForce = 10f;
    //Find the paddle
    public Transform paddle;

    // Start is called before the first frame update
    void Start()
    {
        //Reference to the ball's rigidbody
        ballRB = GetComponent<Rigidbody2D>();
        //Set initial force
        Vector2 force = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ballMoving)
        {
            //Stick the ball to the paddle
            transform.position = new Vector2(paddle.position.x, paddle.position.y + .25f);
            //Listen for launch
            ballStart();
        }
    }

    private void ballStart()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Sets initial launch force for the ball
            ballRB.velocity = new Vector2(0, 1) * launchForce;
            ballMoving = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with: " +  collision.gameObject + ", Tag: " + collision.gameObject.tag);

        //If ball collides with the Player parent object
        if (collision.gameObject.CompareTag("Player"))
        {
            //Register the hit
            ContactPoint2D hitLocation = collision.GetContact(0);

            //Register the hitLocation's collider
            Collider2D hitLocationCollider = hitLocation.collider;

            //If there is a collider on this location
            if (hitLocationCollider != null)
            {
                //If the left side of the paddle is hit
                if (hitLocationCollider.CompareTag("PaddleLeft"))
                {
                    Debug.Log("Ball his PaddleLeft");
                    ballRB.velocity = new Vector2(-10, ballRB.velocity.y);
                }

                //If the middle of the paddle is hit
                if (hitLocationCollider.CompareTag("PaddleMiddle"))
                {
                    Debug.Log("Ball his PaddleMiddle");
                    ballRB.velocity = new Vector2(0, ballRB.velocity.y);
                }

                //If the right side of the paddle is hit
                if (hitLocationCollider.CompareTag("PaddleRight"))
                {
                    Debug.Log("Ball his PaddleRight");
                    ballRB.velocity = new Vector2(10, ballRB.velocity.y);
                }
            }
        }
        else if (collision.gameObject.CompareTag("Snowflake"))
        {
            //Ignore collision
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
        else if (collision.gameObject.CompareTag("Mushroom1"))
        {
            //Ignore collision
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
        else if (collision.gameObject.CompareTag("Mushroom2"))
        {
            //Ignore collision
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
    }
}
