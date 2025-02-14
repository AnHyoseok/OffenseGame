using IdleGame.Hero;
using UnityEngine;

namespace IdleGame.Item
{
    public class ExperienceItem : MonoBehaviour
    {
        public int experienceAmount = 20; // 제공할 경험치 양

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Hero"))
            {
                HeroLevel heroExp = other.GetComponent<HeroLevel>();
                if (heroExp != null)
                {
                    heroExp.GainExperience(experienceAmount);
                    Destroy(gameObject); // 경험치 오브젝트 제거
                }
            }
        }
    }
}
