using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawnerScript : MonoBehaviour
{
    public GameObject[] tiles;

    // Start is called before the first frame update
    void Start()
    {
        for (int xCoor = -30; xCoor < 30; xCoor++)
        {
            for (int zCoor = -30; zCoor < 30; zCoor++)
            {
                GameObject tile = tiles[Random.Range(0, tiles.Length)];
                Instantiate(tile, new Vector3(xCoor * 4f, 0, zCoor * 4f), Quaternion.Euler(0, Random.Range(0, 4) * 90, 0));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
