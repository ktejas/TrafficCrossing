using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //randomize sprites and speed here it self
    //change spawn timings in PeopleSpawner
    private float speed = 0.0f;
    private Vector2 initPosition = Vector2.zero;
    public Sprite[] sprites = new Sprite[4];

    Rigidbody2D thisRigidBody;
    SpriteRenderer spriteRenderer;
    BoxCollider2D startCollider;
    Vector2 currentVelocity;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        startCollider = GameObject.FindGameObjectWithTag("Start").GetComponent<BoxCollider2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        

        speed = Random.Range(0.6f, 5.0f);
        spriteRenderer.sprite = sprites[Random.Range(0,3)];
        thisRigidBody = GetComponent<Rigidbody2D>();
        currentVelocity = new Vector2(0, speed);
        thisRigidBody.velocity = currentVelocity;
        
        initPosition.y = Random.Range(-4.534f, -20.0f);
        transform.position = initPosition;
    }

    // Update is called once per frame
    public void Move()
    {
        startCollider.enabled = false;
        thisRigidBody.velocity = currentVelocity;
    }

    void OnMouseDown()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Destroy(this.gameObject);
        }
    }

}
