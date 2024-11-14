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

    // Start is called before the first frame update
    void Start()
    {
        //Reference to the player's rigidbody
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerDirection();
        movePlayer();
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

    private void movePlayer()
    {
        if (direction != Vector2.zero)
        {
            playerRB.velocity = (direction * movementSpeed);
        }
    }
}
