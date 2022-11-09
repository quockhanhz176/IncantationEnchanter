using UnityEngine;
using System.Collections;
using System;

public class Skill : MonoBehaviour
{
    public string description;
    public int manaCost;
    public float castTime;
    public float coolDown;
    public float range;
    public float speed;
    public int projectTileCount = 1;
    public int spreadDegree;
    public GameObject projectilePrefab;
    public float _firePointOffset = 0.5f;

    private float _nextAvailableTime = -1;

    public void castSkill(Transform firePoint)
    {
        if (Time.time < _nextAvailableTime)
        {
            Debug.Log($"Time: {Time.time}, next: {_nextAvailableTime}");
            return;
        }

        if (spreadDegree == 0)
        {
            spreadDegree = 1;
        }

        _nextAvailableTime = Time.time + coolDown;
        float totalSpread = Math.Abs(spreadDegree) * (projectTileCount - 1);
        Debug.Log($"Total spread: {totalSpread}");
        for (var degree = -totalSpread / 2; degree <= totalSpread / 2; degree += spreadDegree)
        {
            Debug.Log($"Shooting, {degree}");
            var skillRotation = firePoint.rotation * Quaternion.Euler(0, 0, 90 + degree);

            var skillDirectionVector = (skillRotation * Vector3.forward).normalized;
            var skillOffset = (new Vector3(skillDirectionVector.x, skillDirectionVector.y, 0) * _firePointOffset);

            GameObject skill = Instantiate(projectilePrefab, firePoint.position + skillOffset, skillRotation);

            var projectileDamage = skill.GetComponent<Projectile>();
            projectileDamage?.SetDestroyAfter(range / speed);
            var skillRigidbody = skill.GetComponent<Rigidbody2D>();
            skillRigidbody?.AddForce(Quaternion.Euler(0, 0, degree) * firePoint.up * speed, ForceMode2D.Impulse);
        }
    }
}