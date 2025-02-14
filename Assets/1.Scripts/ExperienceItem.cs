using IdleGame.Hero;
using UnityEngine;

namespace IdleGame.Item
{
    public class ExperienceItem : MonoBehaviour
    {
        public int experienceAmount = 20; // ������ ����ġ ��

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Hero"))
            {
                HeroLevel heroExp = other.GetComponent<HeroLevel>();
                if (heroExp != null)
                {
                    heroExp.GainExperience(experienceAmount);
                    Destroy(gameObject); // ����ġ ������Ʈ ����
                }
            }
        }
    }
}
