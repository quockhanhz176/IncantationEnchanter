using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIOrientation : MonoBehaviour
{
    public bool UsingDirectionalSetting = false;
    public bool IsLookingRight = true;

    AIPath _aiPath;
    private Vector2 _left;
    private Vector2 _right;

    // Start is called before the first frame update
    void Start()
    {
        var currentScale = transform.localScale;
        var flipScale = new Vector2(-currentScale.x, currentScale.y);
        _aiPath = GetComponent<AIPath>();
        if (!UsingDirectionalSetting)
        {
            if (currentScale.x > 0)
            {
                _right = currentScale;
                _left = flipScale;
            }
            else
            {
                _left = currentScale;
                _right = flipScale;
            }
        }
        else
        {
            if (IsLookingRight)
            {
                _right = currentScale;
                _left = flipScale;
            }
            else
            {
                _left = currentScale;
                _right = flipScale;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_aiPath != null)
        {
            if (_aiPath.desiredVelocity.x > 0)
            {
                transform.localScale = _right;
            }
            else if (_aiPath.desiredVelocity.x < 0)
            {
                transform.localScale = _left;
            }
        }
    }
}
