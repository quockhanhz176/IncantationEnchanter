using UnityEngine;
public class Skill : MonoBehaviour
{
  public string description;
  public int damage;
  public int manaCost;
  public float castTime;
  public float range;
  public float speed;
  public GameObject projectilePrefab;
  private Animator _animator;
  private Rigidbody2D _rigidbody2D;

  void Start()
  {
    _animator = GetComponent<Animator>();
  }

  public void castSkill(Transform firePoint)
  {
    var skillRotation = firePoint.rotation * Quaternion.Euler(0, 0, 90);
    GameObject skill = Instantiate(projectilePrefab, firePoint.position, skillRotation);

    var skillRigidbody = skill.GetComponent<Rigidbody2D>();
    skillRigidbody.AddForce(firePoint.up * speed, ForceMode2D.Impulse);
  }
  public void OnCollisionEnter2D(Collision2D collision)
  {
    // TODO: Add logic later
    if (collision.gameObject.tag == Tags.TAG_WALL)
    {
      // Run hit animation (if any)
      _animator.SetBool("IsHit", true);

      // Hit animation time
      Destroy(gameObject, 0.25f);
    }
  }
}