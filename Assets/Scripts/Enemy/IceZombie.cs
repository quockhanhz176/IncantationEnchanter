using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceZombie : MonoBehaviour
{
    public float FreezeTime;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var target = collision.gameObject;
        var player = target.GetComponent<Player>();
        if(player != null)
        {
            player.Freeze(FreezeTime);
        }
    }
}
