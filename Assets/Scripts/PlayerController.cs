using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRB;
    //Movement variables
    //private float inputHorizontal;
    public Vector2 direction;
    public float movementSpeed;
    private bool frozen;
    private float frozenTimer;
    private float playerXScale;

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
        //inputHorizontal = Input.GetAxisRaw("Horizontal");
        //playerRB.velocity = new Vector2(movementSpeed * inputHorizontal, 0);

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
            playerXScale = transform.localScale.x;
            playerXScale += .5f;
            gameObject.transform.localScale = new Vector3(playerXScale, 1f, 1f);

            //Debugging
            //When the mushroom drops from a certain height Unity detects three triggers
            //But when falling from higher than that point Unity only detects one trigger
            //Odd....
            //Should not be a problem when dropping from my brick height
            //Debug.Log("PlayerXScale after incrementing: " + playerXScale);
        }
        else if (collision.gameObject.CompareTag("Mushroom2"))
        {
            //Snowflake code here
            //Number of balls are multiplied by 3
            Destroy(collision.gameObject);


        }
    }
}
