using UnityEngine;

public class DamageSkill : Skill
{
    public int damageAmount;            // 데미지 양
    public GameObject damageEffect;     // 데미지 이펙트 프리팹

    void OnTriggerEnter2D(Collider2D collider)
    {
       
        // 충돌한 오브젝트가 적인지 확인
        if (collider.CompareTag("Enemy"))
        {
            // 적에게 데미지 적용
            IDamageable damageable = collider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                Activate(damageable);
            }
        }
        else
        {
            // 그 외의 오브젝트와 충돌했을 때도 스킬 발동을 원한다면 여기에 처리 로직을 추가하세요.
            // 현재는 적과 충돌했을 때만 스킬이 발동됩니다.
        }
    }

    public void Activate(IDamageable target)
    {
        // 데미지 이펙트 재생
        if (damageEffect != null)
        {
            Instantiate(damageEffect, transform.position, Quaternion.identity);
        }

        // 대상에게 데미지 적용
        target.TakeDamage(damageAmount);

        // 스킬 오브젝트 파괴 (필요하다면)
        //Destroy(gameObject);
    }
}
