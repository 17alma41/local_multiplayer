using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmos : MonoBehaviour
{
    public Color gizmoColor = Color.green;
    public Vector3 size = new Vector3(1, 1, 0);

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;

        Gizmos.DrawWireCube(transform.position, size);
    }
}
