using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float speed = 10.0f;
  public Camera mainCamera;

  private SpriteRenderer _spriteRenderer;
  private Animator _animator;

  private Vector3 _destination;
  private Vector2 _moveVector;

  void Start()
  {
    _spriteRenderer = GetComponent<SpriteRenderer>();
    _animator = GetComponent<Animator>();
    _destination = this.transform.position;
  }

  void Update()
  {
    if (Input.GetMouseButtonDown(1))
    {
      _destination = getMousePosition();
      _moveVector = ((Vector2)(_destination - transform.position)).normalized;

      // Flip sprite based on destination
      if (_destination.x > transform.position.x)
      {
        _spriteRenderer.flipX = false;
      }
      else if (_destination.x < transform.position.x)
      {
        _spriteRenderer.flipX = true;
      }

      _animator.SetBool("IsRunning", true);
    }
  }

  void FixedUpdate()
  {
    if (Vector2.Distance((Vector2)_destination, (Vector2)transform.position) > 0.1f)
    {
      transform.position = (Vector2)transform.position + (_moveVector * speed);
    }
    else
    {
      transform.position = new Vector3(_destination.x, _destination.y, 0);
      _moveVector = Vector2.zero;
      _animator.SetBool("IsRunning", false);
    }
  }

  private Vector3 getMousePosition()
  {
    if (!mainCamera)
    {
      return Vector3.zero;
    }

    return mainCamera.ScreenToWorldPoint(Input.mousePosition);
  }
}
