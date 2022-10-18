using UnityEngine;

public class SkillController : MonoBehaviour
{
  public Skill skill1;
  public Skill skill2;
  public Skill skill3;
  public Skill skill4;
  public Transform firePoint;
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Q))
    {
      skill1.castSkill(firePoint);
      return;
    }

    if (Input.GetKeyDown(KeyCode.W))
    {
      skill2.castSkill(firePoint);
      return;
    }

    if (Input.GetKeyDown(KeyCode.E))
    {
      skill3.castSkill(firePoint);
      return;
    }

    if (Input.GetKeyDown(KeyCode.R))
    {
      skill4.castSkill(firePoint);
      return;
    }
  }
}