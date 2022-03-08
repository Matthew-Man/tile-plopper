using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePlacement : MonoBehaviour
{
    public GameObject testTile;

    public struct PlacedTile
    {
        public Vector3 gameWorldPosition;
        public GameObject tileType;
        public Quaternion rotation;
        //public bool isRendered;
    }

    public List<PlacedTile> gameWorldPlacedTiles;

    // Start is called before the first frame update
    void Start()
    {
        //gameWorldPlacedTiles.Add(new PlacedTile { gameWorldPosition = new Vector3(0, 0, 0), tileType = testTile, rotation = Quaternion.Euler(0, 0, 0) });
    }

    // Update is called once per frame
    void Update()
    {
        // Instead of checking every frame

        //for (int i = 0; i < gameWorldPlacedTiles.Count; i++)
        //{
        //    PlacedTile tile = gameWorldPlacedTiles[i];
        //    if (tile.isRendered == false)
        //    {
        //        print(tile);
        //        Instantiate(tile.tileType, tile.gameWorldPosition, tile.rotation);
        //        tile.isRendered = true;
        //    }
        //}
    }

    public static void PlaceTile(Vector3 gameWorldPosition, Quaternion rotation)
    {
        var tp = new TilePlacement();
        GameObject clone = Instantiate(tp.testTile, gameWorldPosition, rotation);
        tp.gameWorldPlacedTiles.Add(new PlacedTile { gameWorldPosition = clone.transform.position, tileType = tp.testTile, rotation = clone.transform.rotation });
        Debug.Log(tp.gameWorldPlacedTiles);
    }
}