using UnityEngine;

public abstract class BaseSkill : MonoBehaviour, ISkill
{
    public string skillName;
    public float cooldown;
    public int level;

    protected float lastUsedTime;

    public string SkillName => skillName;
    public float Cooldown => cooldown;
    public int Level => level;

    public abstract void Activate(Vector2 position);

    public virtual void Upgrade()
    {
        level++;
        Debug.Log($"{skillName} upgraded to level {level}");
    }

    protected bool CanActivate()
    {
        return Time.time - lastUsedTime >= cooldown;
    }
}
