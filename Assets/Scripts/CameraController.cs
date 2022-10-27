using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float FreedomParameter = 1;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            Vector2 difference = (Vector2)player.transform.position - (Vector2)transform.position;
            if (difference.magnitude > FreedomParameter)
            {
                //var z = transform.position.z;
                //transform.position = (Vector2)player.transform.position - difference.normalized * FreedomParameter;
                ShiftXY(player.transform.position, -difference.normalized * FreedomParameter);
            }
        }
    }

    void ShiftXY(Vector3 position, Vector2 transformation)
    {
        transform.position = new Vector3(position.x + transformation.x, position.y + transformation.y, transform.position.z);
    }
}
