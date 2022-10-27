using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class ItemDisplay : MonoBehaviour
{
    [Serializable]
    public struct Icon
    {
        public Item item;
        public GameObject icon;
    }
    public List<Icon> IconList;

    private GameManager _gameManager;

    private Dictionary<Item, int> _itemCount = new Dictionary<Item, int>();
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameManager.Instance;
        foreach (var item in (Item[])Enum.GetValues(typeof(Item)))
        {
            _itemCount.Add(item, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var totalItemCount = 0;
        if (_gameManager != null)
        {
            foreach (var item in (Item[])Enum.GetValues(typeof(Item)))
            {
                var previousItemCount = _itemCount[item];
                var currentItemCount = _gameManager.GetItemCount(item);
                var disparity = currentItemCount - previousItemCount;
                if (disparity != 0)
                {
                    if (disparity < 0)
                    {
                        for (var i = 0; i < -disparity; i++)
                        {
                            Destroy(transform.GetChild(totalItemCount + i).gameObject);
                        }
                    }
                    else
                    {
                        for (var i = 0; i < disparity; i++)
                        {
                            Instantiate(IconList.Find(icon => icon.item == item).icon, transform);
                        }
                    }
                    totalItemCount += currentItemCount;
                    _itemCount[item] = currentItemCount;
                }
            }
        }

    }

}
