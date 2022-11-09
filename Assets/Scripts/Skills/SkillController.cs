using UnityEngine;

public class SkillController : MonoBehaviour
{
    public Player Player;
    public Skill skill1;
    public Skill skill2;
    public Skill skill3;
    public Skill skill4;
    public Transform firePoint;
    void Start()
    {
        if (skill1 != null)
        {
            skill1 = Instantiate(skill1);
        }
        if (skill2 != null)
        {
            skill2 = Instantiate(skill2);
        }
        if (skill3 != null)
        {
            skill3 = Instantiate(skill3);
        }
        if (skill4 != null)
        {
            skill4 = Instantiate(skill4);
        }
    }
    void Update()
    {
        if (Player.IsFrozen)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (skill1 != null) skill1.castSkill(firePoint);
            return;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (skill2 != null) skill2.castSkill(firePoint);
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (skill3 != null) skill3.castSkill(firePoint);
            return;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (skill4 != null) skill4.castSkill(firePoint);
            return;
        }
    }
}