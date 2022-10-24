using UnityEngine;

public class WandController : MonoBehaviour
{
  public Camera mainCamera;
  public Player player;

  private float _currentAngle;
  private Vector2 mousePosition;
  void Update()
  {
    mousePosition = (Vector2)getMousePosition();
  }
  void FixedUpdate()
  {
    var lookDirection = mousePosition - (Vector2)transform.position;

    _currentAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
    transform.rotation = Quaternion.AngleAxis(_currentAngle, Vector3.forward);
  }

  private Vector3 getMousePosition()
  {
    if (!mainCamera)
    {
      return Vector3.zero;
    }

    return mainCamera.ScreenToWorldPoint(Input.mousePosition);
  }

  public float getCurrentAimAngle()
  {
    return _currentAngle;
  }
}
