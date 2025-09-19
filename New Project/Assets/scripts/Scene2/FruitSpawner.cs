using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class FruitSpawner : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bananaPrefab;

    public int maxApples = 5;
    public int maxBananas = 7;

    public Tilemap groundTilemap; // referencia al Tilemap del suelo

    private List<Vector3> groundPositions = new List<Vector3>();

    void Start()
    {
        GetGroundPositions();
        SpawnFruits();
    }

    void GetGroundPositions()
    {
        groundPositions.Clear();

        // Recorremos las celdas del Tilemap
        foreach (var pos in groundTilemap.cellBounds.allPositionsWithin)
        {
            if (groundTilemap.HasTile(pos)) // hay un tile en esta celda
            {
                // convertir coordenada de celda a mundo
                Vector3 worldPos = groundTilemap.GetCellCenterWorld(pos);
                groundPositions.Add(worldPos);
            }
        }
    }

    void SpawnFruits()
    {
        List<Vector3> availablePositions = new List<Vector3>(groundPositions);

        int applesToSpawn = Random.Range(1, maxApples + 1);
        int bananasToSpawn = Random.Range(1, maxBananas + 1);

        // Spawnear manzanas
        for (int i = 0; i < applesToSpawn && availablePositions.Count > 0; i++)
        {
            int index = Random.Range(0, availablePositions.Count);
            Vector3 pos = availablePositions[index] + Vector3.up * 0.5f; // un poquito arriba del piso
            Instantiate(applePrefab, pos, Quaternion.identity);
            availablePositions.RemoveAt(index);
        }

        // Spawnear bananas
        for (int i = 0; i < bananasToSpawn && availablePositions.Count > 0; i++)
        {
            int index = Random.Range(0, availablePositions.Count);
            Vector3 pos = availablePositions[index] + Vector3.up * 0.5f;
            Instantiate(bananaPrefab, pos, Quaternion.identity);
            availablePositions.RemoveAt(index);
        }
    }
}

