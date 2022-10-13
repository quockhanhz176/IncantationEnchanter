using UnityEngine;

public class SkillController : MonoBehaviour
{
  public Skill skill1;
  public Transform firePoint;
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Q))
    {
      skill1.castSkill(firePoint);
    }
  }
}