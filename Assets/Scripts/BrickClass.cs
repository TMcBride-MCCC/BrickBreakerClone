using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickClass : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite indestructableBrick;
    public Sprite greenBrick;
    public Sprite yellowBrick;
    public Sprite orangeBrick;
    public Sprite redBrick;

    private int health;
    public int points;
    private bool indestructable;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        int randomBrickSpawn = Random.Range(1, 6);

        if (randomBrickSpawn == 1)
        {
            //Spawn Red
            spriteRenderer.sprite = redBrick;
            //Health 1
            health = 1;
            points = 1;
        }
        else if (randomBrickSpawn == 2)
        {
            //Spawn Orange
            spriteRenderer .sprite = orangeBrick;
            //Health 2
            health = 2;
        }
        else if (randomBrickSpawn == 3)
        {
            //Spawn Yellow
            spriteRenderer.sprite = yellowBrick;
            //Health 3
            health = 3;
        }
        else if (randomBrickSpawn == 4)
        {
            //Spawn Green
            spriteRenderer.sprite = greenBrick;
            //Health 4
            health = 4;
        }
        else if (randomBrickSpawn == 5)
        {
            //Spawn indestructable
            spriteRenderer.sprite = indestructableBrick;
            //Health infinite
            indestructable = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball") && indestructable == false)
        {
            health--;

            if (health == 3)
            {
                //Change to yellowBrick
                spriteRenderer.sprite = yellowBrick;
            }
            else if (health == 2)
            {
                //Change to orangeBrick
                spriteRenderer.sprite = orangeBrick;
            }
            else if (health == 1)
            {
                //Change to redBrick
                spriteRenderer.sprite = redBrick;
            }
            else if (health <= 0)
            {
                //Destroy brick
                Destroy(this.gameObject);
                FindObjectOfType<GameManager>().addToScore(1);
            }
        }
    }
}
