using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapController : MonoBehaviour
{
    #region PRIVATE VAR
    [Header("Main Plowable Tilemap")]
    [SerializeField] Tilemap plowableTilemap;

    [Header("Player Position")]
    [SerializeField] Transform currentPlayerDirection;

    [Header("Tile Data")]
    [SerializeField] TileData plowableTilesDataHolder;

    Dictionary<TileBase, TileData> dataFromTiles;
    #endregion

    #region UNITY CALLBACKS
    private void Start()
    {
        dataFromTiles = new Dictionary<TileBase, TileData>();

        foreach (TileBase tile in plowableTilesDataHolder.tiles)
        {
            dataFromTiles.Add(tile, plowableTilesDataHolder); //Add all Plowable Tiles
        }
    }
    #endregion

    #region METHODS
    public Vector3Int GetGridPosition()
    {
        Vector3 worldPosition = currentPlayerDirection.position;
        Vector3Int gridPosition = plowableTilemap.WorldToCell(worldPosition);

        return gridPosition;
    }

    public TileBase GetTileBase(Vector3Int gridPosition)
    {
        Vector3 worldPosition = currentPlayerDirection.position;
        TileBase tile = plowableTilemap.GetTile(gridPosition);

        return tile;
    }

    public TileData GetTileData(TileBase tilebase)
    {
        return dataFromTiles[tilebase];
    }
    #endregion
}
