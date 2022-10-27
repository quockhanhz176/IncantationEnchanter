using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class ActiveDisplay : MonoBehaviour
{
    public GameObject OpenDoorSymbol;

    public GameObject OpenDoorButtonSymbol;

    private GameManager _gameManager;

    private bool _canOpenDoor = false;

    void Start()
    {
        _gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        var currentCanOpenDoor = _gameManager.CanOpenDoor();
        if(currentCanOpenDoor != _canOpenDoor)
        {
            Debug.Log("Can open door: " + currentCanOpenDoor);
            if (currentCanOpenDoor)
            {
                Instantiate(OpenDoorSymbol, transform);
                Instantiate(OpenDoorButtonSymbol, transform);
            }
            else
            {
                Destroy(transform.GetChild(0).gameObject);
                Destroy(transform.GetChild(1).gameObject);
            }
            _canOpenDoor = currentCanOpenDoor;
        }
    }

}
