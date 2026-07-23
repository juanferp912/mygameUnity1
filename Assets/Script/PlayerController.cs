using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        myrigidbody2D.linearVelocity = new Vector2(moveX, moveY).normalized * playerSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            Debug.Log("¡Moneda recogida!");
        }

        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Debug.Log("¡Has muerto!");
        }
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