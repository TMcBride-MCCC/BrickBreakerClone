using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRB;
    public Vector2 direction;
    public float movementSpeed;
    private bool frozen;
    private float frozenTimer;
    private float playerXScale;
    //Create a reference to the ball
    public GameObject ball;
    //Create a place to put the ball prefab for spawning multi
    public GameObject spawnedBall;

    // Start is called before the first frame update
    void Start()
    {
        //Reference to the player's rigidbody
        playerRB = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;

        //Debug.Log("Initial scale: " + transform.localScale);
    }

    // Update is called once per frame
    void Update()
    {
        frozenTimer += Time.deltaTime;
        playerDirection();
        movePlayer(checkIfFrozen(frozenTimer));
    }

    private void playerDirection()
    {
        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.zero;
        }
    }

    private void movePlayer(bool frozen)
    {
        if (direction != Vector2.zero && !frozen)
        {
            playerRB.velocity = (direction * movementSpeed);
        }
    }

    private bool checkIfFrozen(float frozenTimer)
    {
        //If frozenTimer is greater than 2 seconds...
        //Then you are no longer frozen
        if (frozenTimer >= 2)
        {
            frozen = false;
        }

        return frozen;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Snowflake"))
        {
            //Snowflake code here
            //Player movement frozen for 2 seconds
            Destroy(collision.gameObject);
            frozenTimer = 0;
            frozen = true;
        }
        else if (collision.gameObject.CompareTag("Mushroom1"))
        {
            //Mushroom1 code here
            //Player paddle size increase
            Destroy(collision.gameObject);
            if (transform.localScale.x < 2f)
            gameObject.transform.localScale = new Vector3(transform.localScale.x + 0.5f, 1f, 1f);

            //Debug.Log("PlayerXScale after increase: " + playerXScale);
        }
        else if (collision.gameObject.CompareTag("Mushroom2"))
        {
            //Mushroom2 code here
            //Player paddle size decrease
            Destroy(collision.gameObject);
            if (transform.localScale.x > 0.5f)
            {
                gameObject.transform.localScale = new Vector3(transform.localScale.x - 0.5f, 1f, 1f);
            }
            else
            {
                return;
            }
            //Debug.Log("Collided with: " + gameObject.name);
            //Debug.Log("PlayerXScale after decrease: " + playerXScale);
        }
    }
}
