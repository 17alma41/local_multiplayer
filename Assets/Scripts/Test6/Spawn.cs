using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefab;
    public int amount = 5;
    public int maxX = 10;
    public int maxY = 10;
    public int minX = -10;
    public int minY = -10;

    void Start()
    {
        InstanciarPrefab(prefab, amount);
    }

    void InstanciarPrefab(GameObject prefab, int cantidad)
    {
        for (int i = 0; i < cantidad; i++)
        {
            Vector3 spawnPosition = transform.position + new Vector3(i * 2.0F, 0, 0);
            GameObject instance = Instantiate(prefab, spawnPosition, Quaternion.identity);

            Movement movementScript = instance.GetComponent<Movement>();
            if (movementScript != null)
            {
                movementScript.movement = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            }
        }
    }
}

