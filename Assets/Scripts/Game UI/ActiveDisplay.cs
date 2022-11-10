using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class ActiveDisplay : MonoBehaviour
{
    public GameObject OpenDoorSymbol;

    public GameObject OpenDoorButtonSymbol;

    public GameObject UsingHealthPotSymbol;

    public GameObject UsingHealthPotButtonSymbol;

    private GameManager _gameManager;

    void Start()
    {
        _gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        for (var i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        if (_gameManager.CanOpenDoor())
        {
            Instantiate(OpenDoorButtonSymbol, transform);
            Instantiate(OpenDoorSymbol, transform);
        }

        if (_gameManager.CanHeal())
        {
            Instantiate(UsingHealthPotButtonSymbol, transform);
            Instantiate(UsingHealthPotSymbol, transform);
        }
    }

}
