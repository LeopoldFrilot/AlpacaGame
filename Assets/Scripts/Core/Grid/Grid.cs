using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int width;
    private int height;
    private float cellSize;
    private Vector3 origin;
    private int[,] gridArray;
    public Grid(int width, int height, float cellSize, Vector3 origin)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.origin = origin;

        gridArray = new int[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                Debug.DrawLine(GetWorldPosition(x,y), GetWorldPosition(x,y, true), Color.cyan, 100f);
                Debug.DrawLine(GetWorldPosition(x,y), GetWorldPosition(x,y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x,y), GetWorldPosition(x+1,y), Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0,height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width,0), GetWorldPosition(width, height), Color.white, 100f);
    }

    public Vector3 GetWorldPosition(int x, int y, bool center = false)
    {
        float posX = (x * cellSize + y * cellSize + (center ? cellSize : 0f)) / 2f;
        float posY = (x * cellSize - y * cellSize) / 4f;
        return new Vector3(posX, posY) + origin;
    }
    
    public Vector2Int GetXY(Vector3 worldPos)
    {
        Vector3 pos = worldPos - origin;
        int x = Mathf.FloorToInt((pos.x + 2f * pos.y) / cellSize);
        int y = Mathf.FloorToInt((pos.x - 2f * pos.y) / cellSize);
        if (IsValid(x, y))
        {
            return new Vector2Int(x, y);
        }

        return new Vector2Int(-1, -1);
    }

    public void SetCellValue(int x, int y, int value)
    {
        if (IsValid(x, y) && value >= 0)
        {
            gridArray[x, y] = value;
        }
    }
    
    public void SetCellValue(Vector3 worldPos, int value)
    {
        var point = GetXY(worldPos);
        SetCellValue(point.x, point.y, value);
    }
    
    public int GetCellValue(int x, int y)
    {
        if (IsValid(x, y))
        {
            return gridArray[x, y];
        }

        return -1;
    }
    
    public int GetCellValue(Vector3 worldPos)
    {
        var point = GetXY(worldPos);
        return GetCellValue(point.x, point.y);
    }

    private bool IsValid(int x, int y)
    {
        return x >= 0 && x < width && y >= 0 && y < height;
    }
}
