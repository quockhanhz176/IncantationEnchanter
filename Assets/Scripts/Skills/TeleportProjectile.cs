using UnityEngine;
using System.Collections;

public class TeleportProjectile : MonoBehaviour
{
    public void OnDestroy()
    {
        var player = GameManager.Instance.Player;
        player.GetComponent<PlayerMovement>().SetPlayerDestination(gameObject.transform.position);
        player.transform.position = gameObject.transform.position;
    }
}