using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public int direction = 0;

    private float speed = 2.0f;
    Rigidbody2D thisRigidbody2D;
    bool bWalking = false;

    List<GameObject> blocksToAvoid;

    void Start()
    {
        thisRigidbody2D = GetComponent<Rigidbody2D>();
        blocksToAvoid = new List<GameObject>();
        if (direction == 0)
        {
            transform.Rotate(new Vector3(0.0f,0.0f,270.0f));
        }
        else if (direction == 1)
        {
            transform.Rotate(new Vector3(0.0f, 0.0f, 180.0f));
        }
        else if (direction == 2)
        {
            transform.Rotate(new Vector3(0.0f, 0.0f, 90.0f));
        }
        else
        {
            transform.Rotate(new Vector3(0.0f, 0.0f, 0.0f));
        }
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.tag == "HumanBlock" && !findIfAvoidBlock(otherCollider.gameObject))
        {
            Wait();
            blocksToAvoid.Add(otherCollider.gameObject);
        }
    }

    bool findIfAvoidBlock(GameObject humanBlock)
    {
        foreach (GameObject block in blocksToAvoid)
        {
            if (block == humanBlock)
                return true;
        }
        return false;
    }

    private void OnMouseDown()
    {
        if (!bWalking)
        {
            Walk();
        }
        else
        {
            Wait();
        }
    }

    void Walk()
    {
        if (direction == 0)
        {
            thisRigidbody2D.velocity = new Vector2(0.0f, speed);
        }
        else if (direction == 1)
        {
            thisRigidbody2D.velocity = new Vector2(speed, 0.0f);
        }
        else if (direction == 2)
        {
            thisRigidbody2D.velocity = new Vector2(0.0f, -speed);
        }
        else
        {
            thisRigidbody2D.velocity = new Vector2(-speed, 0.0f);
        }
        bWalking = true;
        StartCoroutine(Flip());
    }

    void Wait()
    {
        StopCoroutine(Flip());
        thisRigidbody2D.velocity = new Vector2(0.0f, 0.0f);
        bWalking = false;
    }

    IEnumerator Flip()
    {
        yield return new WaitForSeconds(0.2f);
        float scaleY = transform.localScale.y;
        scaleY = scaleY * -1;
        transform.localScale = new Vector3(1.0f, scaleY, 1.0f);

        if (bWalking)
            StartCoroutine(Flip());
    }
}
