using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public bool movingRight = false;
    public bool movingLeft = false;
    public int moveSpeed = 8;
    private bool allowJump = false;

    public LogicScript logicScript;

    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidBody;
    public Sprite playerLeft;
    public Sprite playerRight;

    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            movingRight = true;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            movingRight = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            movingLeft = true;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            movingLeft = false;
        }

        if (movingRight && !movingLeft)
        {
            spriteRenderer.sprite = playerRight;
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        else if (movingLeft && !movingRight)
        {
            spriteRenderer.sprite = playerLeft;
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.W) && allowJump)
        {
            rigidBody.velocity = Vector2.up * 30;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            allowJump = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            allowJump = false;
        }
    }
}
