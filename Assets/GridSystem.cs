using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem
{
    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;

    public GridSystem(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;

        gridArray = new int[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                CreateWorldText(null, gridArray[x,y].ToString(), GetWorldPosition(x, y), TextAnchor.MiddleCenter, 100);
            }
        }
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }

    public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, TextAnchor textAnchor, int sortingOrder)
    {
        GameObject gameObject = new GameObject("World Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.font = (Font)Resources.GetBuiltinResource(typeof (Font), "Arial.ttf");
        textMesh.anchor = textAnchor;
        textMesh.alignment = TextAlignment.Center;
        textMesh.fontSize = 80;
        textMesh.color = Color.black;
        //textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;
    }
}