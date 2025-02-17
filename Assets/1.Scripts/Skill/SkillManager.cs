using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private Dictionary<string, ISkill> skills = new Dictionary<string, ISkill>();

    public void AcquireSkill(ISkill newSkill)
    {
        if (!skills.ContainsKey(newSkill.SkillName))
        {
            skills[newSkill.SkillName] = newSkill;
            Debug.Log($"{newSkill.SkillName} acquired!");
        }
    }

    public void ActivateSkills(Vector2 position)
    {
        foreach (var skill in skills.Values)
        {
            skill.Activate(position);
        }
    }

    public void UpgradeSkill(string skillName)
    {
        if (skills.TryGetValue(skillName, out ISkill skill))
        {
            skill.Upgrade();
        }
        else
        {
            Debug.LogWarning($"Skill {skillName} not found!");
        }
    }
}
