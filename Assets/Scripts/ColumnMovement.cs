using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnMovement : MonoBehaviour
{
    public float ColSpeed;
    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * ColSpeed);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "GameBoundary")
        {
            Destroy(gameObject);
        }
    }
}
