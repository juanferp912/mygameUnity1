using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerJumpForce = 20f;
    public float playerSpeed = 5f;
    public Sprite[] mySprites;
    private int index = 0;

    private Rigidbody2D myrigidbody2D;
    private SpriteRenderer mySpriteRenderer;

    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkCoRoutine());
    }

    void Update()
    {
        // Salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myrigidbody2D.linearVelocity = new Vector2(myrigidbody2D.linearVelocity.x, playerJumpForce);
        }

        // Movimiento horizontal
        myrigidbody2D.linearVelocity = new Vector2(playerSpeed, myrigidbody2D.linearVelocity.y);
    }

    IEnumerator WalkCoRoutine()
    {
        yield return new WaitForSeconds(0.05f);

        if (mySprites != null && mySprites.Length > 0)
        {
            mySpriteRenderer.sprite = mySprites[index];
            index++;

            if (index >= mySprites.Length)
            {
                index = 0;
            }
        }

        StartCoroutine(WalkCoRoutine());
    }
}