using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBlockController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

}
