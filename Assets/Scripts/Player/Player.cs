using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameManager _gameManager;

    public bool IsFrozen = false;

    private float _frozenUntil = 0;

    private SpriteRenderer _spriteRenderer;

    private GameObject _wand;

    private Animator _animator;

    private SpriteRenderer _wandSpriteRenderer;

    private Color _frozenColor = new Color(0.2470588f, 0.7333333f, 0.92549019f);

    private Color _notFrozenColor = Color.white;

    void Start()
    {
        _gameManager = GameManager.Instance;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _wand = _gameManager.Wand;
        _wandSpriteRenderer = _wand.GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (IsFrozen && _frozenUntil < Time.time)
        {
            UnFreeze();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            _gameManager.AddItem(GameManager.Item.KEY);
            Destroy(collision.gameObject);
        }
    }

    //freeze player for an x number of second;
    public void Freeze(float seconds)
    {
        Debug.Log($"Frozen, time: {seconds}");
        IsFrozen = true;
        _frozenUntil = Time.time + seconds;
        if (_spriteRenderer != null)
        {
            _spriteRenderer.color = _frozenColor;
        }
        if(_wandSpriteRenderer != null)
        {
            _wandSpriteRenderer.color = _frozenColor;
        }
        if(_animator != null)
        {
            _animator.enabled = false;
        }
    }

    private void UnFreeze()
    {
        IsFrozen = false;
        if (_spriteRenderer != null)
        {
            _spriteRenderer.color = _notFrozenColor;
        }
        if (_wandSpriteRenderer != null)
        {
            _wandSpriteRenderer.color = _notFrozenColor;
        }
        if (_animator != null)
        {
            _animator.enabled = true;
        }
    }
}