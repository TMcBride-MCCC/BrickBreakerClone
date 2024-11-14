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
    private float launchForce = 20f;
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

    }
}
