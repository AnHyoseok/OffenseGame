using UnityEngine;

public enum AttackType
{
    Stay,   // 지속 딜
    Move    // 쿨타임마다 투사체 발사
}

[CreateAssetMenu(fileName = "NewSkill", menuName = "Skill/SkillData")]
public class SkillData : ScriptableObject
{
    public Sprite icon;
    public AttackType attackType; // 스킬 공격 방식
    public bool isAcquired;    // 스킬 획득 여부
    public bool isProjectile;  // 투사체 여부
    public int skillCount;     // 투사체일 경우 스킬 갯수
    public float cooldown;     // 스킬 쿨타임
    public int level;          // 스킬 레벨
    public float size;         // 스킬 크기
    public float damage;       // 스킬 데미지
    public float attackRange; //투사체 사거리



}
