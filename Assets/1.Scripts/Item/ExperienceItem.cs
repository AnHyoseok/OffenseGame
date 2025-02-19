using IdleGame.Hero;
using IdleGame.Item;
using UnityEngine;

public class ExperienceItem : MagnetEffect
{
    public int experienceAmount = 20; // 경험치 양

    protected override void Update()
    {
        base.Update(); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hero"))
        {
            HeroLevel heroExp = other.GetComponent<HeroLevel>();
            if (heroExp != null)
            {
                heroExp.GainExperience(experienceAmount);  // 경험치 추가
                Destroy(gameObject);  // 경험치 오브젝트 제거
            }
        }
    }
}
