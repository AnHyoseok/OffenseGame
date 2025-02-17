using UnityEngine;
public interface ISkill
{
    string SkillName { get; }
    float Cooldown { get; }
    int Level { get; }
    void Activate(Vector2 position);
    void Upgrade();
}
