using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameManager _gameManager;

    void Start()
    {
        _gameManager = GameManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Key") {
            _gameManager.AddItem(GameManager.Item.KEY);
            Destroy(collision.gameObject);
        }
    }
}