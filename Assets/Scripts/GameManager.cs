using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject Player;

    public GameObject Wand;

    public Tilemap WallTileMap;

    public Tile ClosedDoorTile;

    public Tile OpenedDoorTile;

    private List<Vector2Int> _searchArea = new List<Vector2Int>
    {
        new Vector2Int(-1, -1),
        new Vector2Int(-1, 0),
        new Vector2Int(-1, 1),
        new Vector2Int(0, -1),
        new Vector2Int(0, 0),
        new Vector2Int(0, 1),
    };

    private Dictionary<Item, int> _itemDictionary = new Dictionary<Item, int>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (var item in (Item[])Enum.GetValues(typeof(Item)))
        {
            _itemDictionary.Add(item, 0);
        }
    }
    public void AddItem(Item item, int amount = 1)
    {
        lock (_itemDictionary)
        {
            _itemDictionary[item] += amount;
            var itemCount = _itemDictionary[item];
        }
    }

    public bool UseItem(Item item, int amount = 1)
    {
        if (_itemDictionary[item] < amount)
        {
            return false;
        }
        _itemDictionary[item] -= amount;
        return true;
    }

    public int GetItemCount(Item item)
    {
        return _itemDictionary[item];
    }

    public bool IsClosedDoorNearby()
    {
        return FindDoor() != null;
    }

    public bool CanOpenDoor()
    {
        return (IsClosedDoorNearby() && GetItemCount(Item.KEY) > 0);
    }

    public bool TryOpenDoor()
    {
        var doorPosition = FindDoor();
        if (doorPosition == null)
        {
            return false;
        }
        else
        {
            UseItem(Item.KEY);
            WallTileMap.SetTile((Vector3Int)doorPosition, OpenedDoorTile);
            return false;
        }
    }
    private Vector3Int? FindDoor()
    {
        if (Player == null)
            return null;

        var location = WallTileMap.WorldToCell(Player.transform.position);
        foreach (var shift in _searchArea)
        {
            if (WallTileMap.GetTile(location + ((Vector3Int)shift)) == ClosedDoorTile)
            {
                return location + ((Vector3Int)shift);
            }
        }
        return null;
    }

    public enum Item
    {
        KEY
    }
}
