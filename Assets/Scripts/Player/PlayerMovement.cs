using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public Camera mainCamera;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private Vector3 _destination;
    private Vector2 _moveVector;

    private Vector3 _rightScale;
    private Vector3 _leftScale;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _destination = this.transform.position;
        _rightScale = transform.localScale;
        _leftScale = new Vector3(-_rightScale.x, _rightScale.y, _rightScale.z);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _destination = getMousePosition();

            // Flip sprite based on destination
            if (_destination.x > transform.position.x)
            {
                //_spriteRenderer.flipX = false;
                transform.localScale = _rightScale;
            }
            else if (_destination.x < transform.position.x)
            {
                //_spriteRenderer.flipX = true;
                transform.localScale = _leftScale;
            }

            _animator.SetBool("IsRunning", true);
        }
    }

    void FixedUpdate()
    {
        if (Vector2.Distance((Vector2)_destination, (Vector2)transform.position) > 0.1f)
        {
            _moveVector = ((Vector2)(_destination - transform.position)).normalized;
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
