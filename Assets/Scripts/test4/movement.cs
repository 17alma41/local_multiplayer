using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movement : MonoBehaviour
{

    [SerializeField] Vector2 playerMove = Vector2.right;
    [SerializeField] Vector2 bounds = Vector2.one;


    void Update()
    {
        transform.position += new Vector3(playerMove.x, playerMove.y) * Time.deltaTime;

        if (Mathf.Abs(transform.position.x) > bounds.x)
            transform.position = new Vector3( -bounds.x * Mathf.Sign(transform.position.x),transform.position.y,0);


        if (Mathf.Abs(transform.position.y) > bounds.y)
            transform.position = new Vector3(transform.position.x,-bounds.y * Mathf.Sign(transform.position.y),0);
    }
}
