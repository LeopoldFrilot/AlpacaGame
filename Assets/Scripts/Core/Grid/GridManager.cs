using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width = 3;
    [SerializeField] private int height = 4;
    [SerializeField] private float size = 160f;
    [SerializeField] private Color debugColor = Color.white;
    
    private Grid grid;
    void Start()
    {
        grid = new Grid(width, height, size, transform.position);
    }

    private void Update()
    {
        grid.DrawDebug(Color.white, Time.deltaTime);
    }

    public bool SnapToGrid(Transform transformToSnap)
    {
        if (ValidGridClick(transformToSnap.position))
        {
            var pos = grid.GetXY(transformToSnap.position);
            transformToSnap.position = grid.GetWorldPosition(pos.x, pos.y, true);
            return true;
        }

        return false;
    }

    public List<Vector2Int> GetAllCells()
    {
        return grid.GetAllCells();
    }

    public void UpdateGridValue(Vector3 worldPos, int val)
    {
        if (ValidGridClick(worldPos))
        {
            grid.SetCellValue(worldPos, val);
        }
    }

    public bool ValidGridClick(Vector3 worldPos)
    {
        return grid.GetXY(worldPos).x != -1;
    }

    public int GetValue(Vector2 worldPos)
    {
        return grid.GetCellValue(worldPos);
    }

    private void DebugGridCell(Vector2 pos)
    {
        var convertedPos = grid.GetXY(pos);
        if (convertedPos.x >= 0)
        {
            Debug.Log(convertedPos);
        }
    }

    private void OnEnable()
    {
        EventHub.OnClickDown += DebugGridCell;
    }
    
    private void OnDisable()
    {
        EventHub.OnClickDown -= DebugGridCell;
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            grid = new Grid(width, height, size, transform.position);
            grid.DrawDebug(debugColor, Time.deltaTime);
        }
    }

    public Vector2 GetWorldPosition(int cellX, int cellY, bool center)
    {
        return grid.GetWorldPosition(cellX, cellY, center);
    }
}
