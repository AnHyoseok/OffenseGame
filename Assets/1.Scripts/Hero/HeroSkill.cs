using UnityEngine;

public class Hero : MonoBehaviour
{
    private SkillManager skillManager;

    void Start()
    {
        skillManager = GetComponent<SkillManager>();

       

        SpiralBladeSkill spiralBladeSkill = GetComponent<SpiralBladeSkill>();
        if (spiralBladeSkill != null)
        {
            skillManager.AcquireSkill(spiralBladeSkill);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            skillManager.ActivateSkills(transform.position);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            skillManager.UpgradeSkill("SpiralBladeSkill");
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            skillManager.UpgradeSkill("SpiralBlade");
        }
    }
}
