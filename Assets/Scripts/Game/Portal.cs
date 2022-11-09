using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Portal : MonoBehaviour
{
    public UnityEvent actions;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"collision: {collision.gameObject}");
        if(collision.gameObject == GameManager.Instance?.Player)
        {
            Debug.Log($"player yes");
            actions.Invoke();
        }
    }
}
