using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GridCellTypes
{
    Null,
    Plantable
}
public class GridManager : MonoBehaviour
{
    [SerializeField] private GameObject testPrefab;
    private Grid grid;
    void Start()
    {
        grid = new Grid(10, 10, 160f, transform.position);
    }

    private void DebugGridCell(Vector2 pos)
    {
        Debug.Log(grid.GetXY(pos));
    }

    private void OnEnable()
    {
        EventHub.OnClickDown += DebugGridCell;
    }
    private void OnDisable()
    {
        EventHub.OnClickDown -= DebugGridCell;
    }
}
