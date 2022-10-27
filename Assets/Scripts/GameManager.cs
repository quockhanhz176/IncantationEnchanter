using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject Player;

    public Tilemap WallTileMap;

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

    public int GetItem(Item item)
    {
        return _itemDictionary[item];
    }

    public enum Item
    {
        KEY
    }
}
