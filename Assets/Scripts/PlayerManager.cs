using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //randomize sprites and speed here it self
    //change spawn timings in PeopleSpawner
    private float speed = 0.0f;
    private Vector2 initPosition = Vector2.zero;
    public Sprite[] sprites = new Sprite[4];

    Rigidbody2D thisRigidBody;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        speed = Random.Range(0.6f, 5.0f);
        spriteRenderer.sprite = sprites[Random.Range(0,3)];
        thisRigidBody = GetComponent<Rigidbody2D>();
        thisRigidBody.velocity = new Vector2(0,speed);
        initPosition.y = Random.Range(-4.534f, -10.0f);
        transform.position = initPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
