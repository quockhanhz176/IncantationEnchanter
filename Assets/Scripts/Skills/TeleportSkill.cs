using UnityEngine;
using System.Collections;

public class TeleportSkill : Skill
{
  private Animator _animator;
  private Rigidbody2D _rigidbody2D;

  public void Start()
  {
    _animator = GetComponent<Animator>();
    _rigidbody2D = GetComponent<Rigidbody2D>();

    StartCoroutine(DestroyProjectile(range, gameObject));
  }
  public override IEnumerator DestroyProjectile(float range, GameObject gameObject)
  {
    yield return new WaitForSeconds(range);
    _rigidbody2D.velocity = Vector2.zero;
    _rigidbody2D.angularVelocity = 0f;
    _animator.SetBool("IsHit", true);
    Destroy(gameObject, 0.2f);

    // Teleport player to the position of the projectile
    var player = GameObject.Find("Player");

    // To stop player movement after teleporting
    player.GetComponent<PlayerMovement>().SetPlayerDestination(gameObject.transform.position);
    player.transform.position = gameObject.transform.position;
  }

}