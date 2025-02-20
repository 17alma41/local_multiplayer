using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector2 movement = Vector2.right;
    public Vector2 bounds = Vector2.one;

    void Update()
    {
        transform.position += new Vector3(movement.x, movement.y) * Time.deltaTime;

        if (Mathf.Abs(transform.position.x) > bounds.x)
            transform.position = new Vector3(-bounds.x * Mathf.Sign(transform.position.x), transform.position.y, 0);

        if (Mathf.Abs(transform.position.y) > bounds.y)
            transform.position = new Vector3(transform.position.x, -bounds.y * Mathf.Sign(transform.position.y), 0);
    }
}
