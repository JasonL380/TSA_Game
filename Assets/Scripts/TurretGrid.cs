// Name: Jason Leech
// Date: 12/16/2022
// Desc: 

using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class TurretGrid : MonoBehaviour
{
    public Vector2 gridSize;
    private Dictionary<Vector2, GameObject> _turretMap = new Dictionary<Vector2, GameObject>();
    [Tooltip("The layers that cannot be placed on, for example walls.")]
    public LayerMask obstacleLayerMask;

    //public Vector2 pos;
    //public GameObject turretPrefab;

    private void Start()
    {
        //print(PlaceObjectAtPosition(turretPrefab, pos, 0));
    }

    private void FixedUpdate()
    {
        DrawSquare(GetGridPosition(transform.position), Color.red, 120);
    }

    /// <summary>
    /// get the object at a position
    /// </summary>
    /// <param name="position">The position</param>
    /// <returns>The GameObject at the position or null if there is no object at that position</returns>
    public GameObject GetObjectAtPosition(Vector2 position)
    {
        return _turretMap[GetGridPosition(position)];
    }

    private Vector2 GetGridPosition(Vector2 position)
    {
        Vector2 gridPosition = new Vector2();
        //check if x is negative to determine how the position should be rounded
        if (position.x >= 0)
        {
            gridPosition.x = Mathf.Ceil(position.x / gridSize.x) * gridSize.x - (gridSize.x / 2);
        }
        else
        {
            gridPosition.x = Mathf.Floor(position.x / gridSize.x) * gridSize.x + (gridSize.x / 2);
        }

        //check if y is negative to determine how the position should be rounded
        if (position.y >= 0)
        {
            gridPosition.y = Mathf.Ceil(position.y / gridSize.y) * gridSize.y - (gridSize.y / 2);
        }
        else
        {
            gridPosition.y = Mathf.Floor(position.y / gridSize.y) * gridSize.y + (gridSize.y / 2);
        }
        
        return gridPosition;
    }

    /// <summary>
    /// Place a prefab at the specified position
    /// </summary>
    /// <param name="prefab">The prefab to place</param>
    /// <param name="position">The position, this will be adjusted to the grid</param>
    /// <param name="layer">The layer that the object should be placed on</param>
    /// <returns>True if placement was successful, false if placement was unsuccessful</returns>
    public bool PlaceObjectAtPosition(GameObject prefab, Vector2 position, int layer)
    {
        Vector2 gridPos = GetGridPosition(position);
        
        //check if there is already a turret at this position
        if (_turretMap.ContainsKey(gridPos))
        {
            return false;
        }
        
        //check if there are any obstacles in this area
        Collider2D obstacle = Physics2D.OverlapBox(position, gridSize, 0, obstacleLayerMask);
        if (obstacle != null)
        {
            return false;
        }

        GameObject turret = Instantiate(prefab, position, Quaternion.identity);
        turret.layer = layer;
        _turretMap[gridPos] = turret;
        
        return true;
    }

    /// <summary>
    /// Destroy the turret at the specified position
    /// </summary>
    /// <param name="position">The position where an object should be destroyed</param>
    /// <returns>True if object was successfully destroyed, false if no object found</returns>
    public bool DestroyObjectAtPosition(Vector2 position)
    {
        Vector2 gridPos = GetGridPosition(position);
        
        //check if a turret exists at this position
        if (_turretMap.ContainsKey(gridPos))
        {
            Destroy(_turretMap[gridPos]);
            _turretMap.Remove(gridPos);
            
            return true;
        }

        return false;
    }
    
    //draw the square, for debugging purposes
    private void DrawSquare(Vector2 position, Color color, float duration)
    {
        Debug.DrawLine(position - (gridSize / 2), position + new Vector2(gridSize.x, -gridSize.y) / 2, color);
        Debug.DrawLine(position + (gridSize / 2), position + new Vector2(gridSize.x, -gridSize.y) / 2, color);
        Debug.DrawLine(position + (gridSize / 2), position + new Vector2(-gridSize.x, gridSize.y) / 2, color);
        Debug.DrawLine(position - (gridSize / 2), position + new Vector2(-gridSize.x, gridSize.y) / 2, color);
    }
}