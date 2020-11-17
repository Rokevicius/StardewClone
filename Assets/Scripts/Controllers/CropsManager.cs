using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Crops
{

}

public class CropsManager : MonoBehaviour
{
    #region PUBLIC VAR
    [Header("Plowing and Seeding")]
    public TileBase PlowedTile;
    public TileBase SeededTile;
    public Tilemap TilemapForPlowingSeeding;

    [HideInInspector] public Dictionary<Vector2Int, Crops> plowedTiles;
    [HideInInspector] public Dictionary<Vector2Int, Crops> seededTiles;
    #endregion

    #region SERIALIZED PRIVATE VAR
    [Header("Harvesting")]
    [SerializeField] GameObject plantStarterPrefab;
    #endregion

    #region UNITY CALLBACKS
    private void Start()
    {
        plowedTiles = new Dictionary<Vector2Int, Crops> ();
        seededTiles = new Dictionary<Vector2Int, Crops> ();
    }
    #endregion
    #region PLOWING AND SEEDING
    public void Plow(Vector3Int position)
    {
        if(plowedTiles.ContainsKey((Vector2Int)position)) return;

        CreatePlowedTile(position);
    }

    public bool IsPlowedTile(Vector3Int position)
    {
        return plowedTiles.ContainsKey((Vector2Int)position);
    }

    public bool IsSeededTile(Vector3Int position)
    {
        return seededTiles.ContainsKey((Vector2Int)position);
    }

    public void CreateSeededTile(Vector3Int position)
    {
        Crops crop = new Crops();
        TilemapForPlowingSeeding.SetTile(position, SeededTile);
        seededTiles.Add((Vector2Int)position, crop);
        InitiateHarvest(position);
    }

    void CreatePlowedTile(Vector3Int position)
    {
        Crops crop = new Crops();
        plowedTiles.Add((Vector2Int)position, crop);
        TilemapForPlowingSeeding.SetTile(position, PlowedTile);
    }

    #endregion

    #region HARVERSTING
    public void InitiateHarvest(Vector3Int position)
    {
        Instantiate(plantStarterPrefab, position, Quaternion.identity);
    }
    #endregion
}
