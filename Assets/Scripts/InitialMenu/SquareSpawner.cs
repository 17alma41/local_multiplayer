using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareSpawner : MonoBehaviour
{
    public GameObject squarePrefab;
    public int numberOfSquares = 5; 
    public float minX, maxX, minY, maxY; // Área de spawn

    void Start()
    {
        for (int i = 0; i < numberOfSquares; i++)
        {
            SpawnSquare();
        }
    }

    void SpawnSquare()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        GameObject square = Instantiate(squarePrefab, spawnPosition, Quaternion.identity);

        // Límites de movimiento del cuadrado 
        SquareMovementInitialMenu movement = square.GetComponent<SquareMovementInitialMenu>();
        if (movement != null)
        {
            movement.minX = minX;
            movement.maxX = maxX;
        }
    }
}
