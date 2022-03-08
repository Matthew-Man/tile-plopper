using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CursorTile : MonoBehaviour
{
    public GameObject selectedTile;
    public GameObject[] tiles;
    public Material initialPreviewMaterial;

    public struct PlacedTile
    {
        public Vector3 gameWorldPosition;
        public GameObject tileType;
        public Quaternion rotation;
    }

    List<PlacedTile> gameWorldPlacedTiles = new List<PlacedTile>();

    public int tileSnapScale = 4;
    GameObject clonedTile;
    GameObject gridPreview;
    GameObject cursorSelection;
    Vector3 worldPosition;
    int selectedTileIndex = 0;
    //public TilePlacement tilePlacement;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        clonedTile = Instantiate(selectedTile, worldPosition, Quaternion.identity);

        gridPreview = GameObject.CreatePrimitive(PrimitiveType.Cube);
        gridPreview.transform.localScale = new Vector3(4f, 6f, 4f); 
        //Material initialMaterial = (Material)Resources.Load("Resources/Materials/Placeable_Tile.mat");
        gridPreview.GetComponent<MeshRenderer>().material = initialPreviewMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        Plane plane = new Plane(Vector3.up, 0);
        float distance;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
        }

        if (Input.GetKeyDown("r"))
        {
            RotateTile();
        }

        if (Input.GetKeyDown("q"))
        {
            selectedTile = NextTile();
            Destroy(clonedTile);
            clonedTile = Instantiate(selectedTile, worldPosition, Quaternion.identity);
        }

        Vector3 newPosition = GetGridTilePosition();
        clonedTile.transform.position = newPosition;
        gridPreview.transform.position = newPosition;

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            PlaceTile(GetGridTilePosition(), clonedTile.transform.rotation);
        }
    }

    void RotateTile()
    {
        Quaternion rotation = clonedTile.transform.rotation;
        rotation *= Quaternion.Euler(0, 90f, 0);
        clonedTile.transform.rotation = rotation;
    }

    GameObject NextTile()
    {
        if (selectedTileIndex == (tiles.Length - 1))
        {
            selectedTileIndex = 0;
        } else
        {
            selectedTileIndex += 1;
        }
        return tiles[selectedTileIndex];
    }

    private Vector3 GetGridTilePosition()
    {
        float xPosition = Mathf.Floor(worldPosition.x / tileSnapScale) * tileSnapScale;
        float zPosition = Mathf.Floor(worldPosition.z / tileSnapScale) * tileSnapScale;
        return new Vector3(xPosition, 0, zPosition);
    }

    public void PlaceTile(Vector3 gameWorldPosition, Quaternion rotation)
    {
        PlacedTile t = new PlacedTile
        {
            gameWorldPosition = gameWorldPosition,
            tileType = selectedTile,
            rotation = rotation
        };

        bool isPositionOccupied = gameWorldPlacedTiles.Any(tile => tile.gameWorldPosition == gameWorldPosition);

        if (!isPositionOccupied)
        {
            gameWorldPlacedTiles.Add(t);
            GameObject clone = Instantiate(selectedTile, gameWorldPosition, rotation);  
        }
    }

    public void AdjustPreviewMaterial(bool isColliding)
    {
       

        if (isColliding)
        {
            
        } else
        {

        }
    }
}

// Add transparent material