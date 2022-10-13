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
  public float _firePointOffset = 0.5f;
  private Animator _animator;
  private Rigidbody2D _rigidbody2D;

  void Start()
  {
    _animator = GetComponent<Animator>();
    _rigidbody2D = GetComponent<Rigidbody2D>();
  }

  public void castSkill(Transform firePoint)
  {
    var skillRotation = firePoint.rotation * Quaternion.Euler(0, 0, 90);

    var skillDirectionVector = (skillRotation * Vector3.forward).normalized;
    var skillOffset = (new Vector3(skillDirectionVector.x, skillDirectionVector.y, 0) * _firePointOffset);

    GameObject skill = Instantiate(projectilePrefab, firePoint.position + skillOffset, skillRotation);

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

      _rigidbody2D.velocity = Vector2.zero;
      _rigidbody2D.angularVelocity = 0f;
    }
  }
}