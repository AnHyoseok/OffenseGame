using UnityEngine;

public class SpiralBladeSkill : BaseSkill
{
    public GameObject SpiralBladeSkillPrefab;
    public float size;
    public float speed;
    public int quantity;
    public int damageAmount;          
    public GameObject damageEffect;     

    public override void Activate(Vector2 position)
    {
        if (CanActivate())
        {
            lastUsedTime = Time.time;
            Debug.Log($"{skillName} activated at position {position}");

            for (int i = 0; i < quantity; i++)
            {
                GameObject spiralBlade = Instantiate(SpiralBladeSkillPrefab, position, Quaternion.identity);
                spiralBlade.transform.localScale = new Vector3(size, size, 1);

                Rigidbody2D rb = spiralBlade.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.linearVelocity = new Vector2(speed, 0);
                }
                else
                {
                    Debug.LogWarning("No Rigidbody2D found on the instantiated spiral blade.");
                }
            }
        }
    }

    public override void Upgrade()
    {
        base.Upgrade();
        size += 0.1f;
        speed += 0.1f;
        quantity++;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            IDamageable damageable = collider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                Activate(damageable);
            }
        }
    }

    public void Activate(IDamageable target)
    {
        if (damageEffect != null)
        {
            Instantiate(damageEffect, transform.position, Quaternion.identity);
        }

        target.TakeDamage(damageAmount);

        // ��ų ������Ʈ �ı� (�ʿ��ϴٸ�)
        //Destroy(gameObject);
    }
}
