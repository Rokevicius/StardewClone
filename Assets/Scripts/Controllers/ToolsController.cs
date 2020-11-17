using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ToolsController : MonoBehaviour
{
    BodyMovement player;
    Rigidbody2D rb;

    [Header("Tool Use Range")]
    [SerializeField] float areaOfEffect = 0.5f;
    [SerializeField] float offset = 0.5f;


    [Header("Managers")]
    [SerializeField] MarkerManager markerManager;
    [SerializeField] TilemapController tilemapController;
    [SerializeField] CropsManager cropsManager;

    [Header("Plowable Tiles Data")]
    [SerializeField] TileData plowableTiles;

    Vector3Int selectedTilePosition;
    List<Collider2D> colliderHitted = new List<Collider2D>();
    #region UNITY CALLBACKS
    private void Start()
    {
        player = GetComponent<BodyMovement>();
        rb = GetComponent<Rigidbody2D>();
        GameEventSystem.current.OnButtonClick += UseButton;
        GameEventSystem.current.OnHarvestComplete += AfterHarvest;
    }

    private void OnDisable()
    {
        GameEventSystem.current.OnButtonClick -= UseButton;
        GameEventSystem.current.OnHarvestComplete -= AfterHarvest;
    }

    private void Update()
    {
        SelectTile();
        Marker();
    }
    #endregion

    void UseButton()
    {
        if (HittingCollider()) return;
        PlowSeed();
    }

    void SelectTile()
    {
        selectedTilePosition = tilemapController.GetGridPosition();
    }

    void Marker()
    {
        markerManager.markedCellPosition = selectedTilePosition;
    }

    public bool HittingCollider()
    {
        
        Vector2 toolUsePostion =  rb.position + player.viewDirection * offset;
        Collider2D[] collisions = Physics2D.OverlapCircleAll(toolUsePostion, areaOfEffect);
        foreach (Collider2D col in collisions)
        {
            HitObject hit = col.GetComponent<HitObject>();
            if (hit != null)
            {
                hit.OnHit();
                if (col.tag == "Plant") return false; // To avoid issues with collider we skip Plant Collider and return false (Nothing hit that would interupt plowing/seediing)
                return true;
            }
        }
        return false;
    }

    public void PlowSeed()
    {
        TileBase tileBase = tilemapController.GetTileBase(selectedTilePosition);
        TileData tileData = tilemapController.GetTileData(tileBase);
        if (CurrentTool.Instance.getTypeTool() == CurrentTool.TypeTool.Hoe)
        {
            if (tileData != plowableTiles) return;

            if (cropsManager.IsPlowedTile(selectedTilePosition))
            {
                if (!cropsManager.IsSeededTile(selectedTilePosition))
                {
                    if (InventoryHolder.Instance.inventory.CheckItem(Item.ItemType.Seeds))
                    {
                        cropsManager.CreateSeededTile(selectedTilePosition);
                        InventoryHolder.Instance.inventory.RemoveItem(Item.ItemType.Seeds);
                    }
                }
            }
            else cropsManager.Plow(selectedTilePosition);
        }
    }

    public void AfterHarvest()
    {
        cropsManager.TilemapForPlowingSeeding.SetTile(markerManager.markedCellPosition, null);
        cropsManager.plowedTiles.Remove((Vector2Int)markerManager.markedCellPosition);
    }
}
