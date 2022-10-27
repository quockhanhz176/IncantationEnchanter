using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedObjectDestroyer : MonoBehaviour
{
    public float DestroyDelay;
    void Start()
    {
        Destroy(gameObject, DestroyDelay);
    }
}
