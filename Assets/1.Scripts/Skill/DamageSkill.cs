using UnityEngine;

public class DamageSkill : Skill
{
    public int damageAmount;            // ������ ��
    public GameObject damageEffect;     // ������ ����Ʈ ������

    void OnTriggerEnter2D(Collider2D collider)
    {
       
        // �浹�� ������Ʈ�� ������ Ȯ��
        if (collider.CompareTag("Enemy"))
        {
            // ������ ������ ����
            IDamageable damageable = collider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                Activate(damageable);
            }
        }
        else
        {
            // �� ���� ������Ʈ�� �浹���� ���� ��ų �ߵ��� ���Ѵٸ� ���⿡ ó�� ������ �߰��ϼ���.
            // ����� ���� �浹���� ���� ��ų�� �ߵ��˴ϴ�.
        }
    }

    public void Activate(IDamageable target)
    {
        // ������ ����Ʈ ���
        if (damageEffect != null)
        {
            Instantiate(damageEffect, transform.position, Quaternion.identity);
        }

        // ��󿡰� ������ ����
        target.TakeDamage(damageAmount);

        // ��ų ������Ʈ �ı� (�ʿ��ϴٸ�)
        //Destroy(gameObject);
    }
}
