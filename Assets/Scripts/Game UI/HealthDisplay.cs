using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    public GameObject HealthIcon;

    private Health _playerHealth;

    private int _previousHealth = 0;

    private void Start()
    {
        GameManager gameManager = GameManager.Instance;
        if (gameManager != null && gameManager.Player != null)
        {
            _playerHealth = gameManager.Player.GetComponent<Health>();
        }
    }

    void Update()
    {
        if (HealthIcon != null)
        {
            var currentHealth = _playerHealth != null ? _playerHealth.currentHealth : 0;
            if (_previousHealth != currentHealth)
            {
                if (_previousHealth > currentHealth)
                {
                    for (int i = 0; i < _previousHealth - currentHealth; i++)
                    {
                        Destroy(transform.GetChild(i).gameObject);
                    }
                }
                else
                {
                    for (int i = 0; i < currentHealth - _previousHealth; i++)
                    {
                        Debug.Log("Adding health");
                        Instantiate(HealthIcon, transform);
                    }
                }
                _previousHealth = currentHealth;
            }
        }
    }
}
