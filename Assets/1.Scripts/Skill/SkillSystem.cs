using UnityEngine;

public class SkillSystem
{
    public SkillData skillData;  // SkillManager에서 설정된 스킬 데이터
    private float lastUsedTime = 0f;  // 마지막으로 사용된 시간
    private bool isSkillActive = false; // 스킬이 활성화 상태인지 체크

    // 매 프레임마다 호출되는 업데이트 메서드
    public void Update()
    {
        if (skillData.isAcquired)  // 스킬이 획득되었을 때만 사용 가능
        {
            if (skillData.attackType == AttackType.Stay)
            {
                HandleStaySkill();  // 지속적인 딜 처리
            }
            else if (skillData.attackType == AttackType.Move)
            {
                HandleMoveSkill();  // 쿨타임마다 발사 처리
            }
        }
    }

    // Stay 타입: 0.1초마다 지속적으로 데미지 주기
    void HandleStaySkill()
    {
        if (isSkillActive)
        {
            if (Time.time - lastUsedTime >= 0.1f)  // 0.1초마다 데미지
            {
                ApplyDamage(skillData.damage);  // 데미지 적용
                lastUsedTime = Time.time;  // 시간 갱신
            }
        }
    }

    // Move 타입: 스킬이 쿨타임에 맞춰 발사
    void HandleMoveSkill()
    {
        if (Time.time - lastUsedTime >= skillData.cooldown)  // 쿨타임마다 발사
        {
            lastUsedTime = Time.time;  // 시간 갱신
            FireSkill();  // 스킬 발사
        }
    }

    // 데미지 적용 (예시: 적에게 데미지 주는 함수)
    void ApplyDamage(float damage)
    {
        Debug.Log("Damage applied: " + damage);
    }

    // 스킬 발사 (예시: 투사체 발사)
    void FireSkill()
    {
        if (skillData.isProjectile)
        {
            Debug.Log("Fire projectile skill!");  // 투사체 스킬 발사
        }
        else
        {
            Debug.Log("Fire non-projectile skill!");  // 비투사체 스킬 발사
        }

        ApplyDamage(skillData.damage);  // 데미지 적용
    }

    // 스킬 활성화
    public void ActivateSkill()
    {
        isSkillActive = true;
        lastUsedTime = Time.time;  // 활성화 시 시간 초기화
    }

    // 스킬 비활성화
    public void DeactivateSkill()
    {
        isSkillActive = false;
    }
}
