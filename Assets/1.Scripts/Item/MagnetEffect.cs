using IdleGame.Hero;
using UnityEngine;

namespace IdleGame.Item
{
    // 자석 효과를 처리하는 클래스
    public class MagnetEffect : MonoBehaviour
    {
        public float magnetRange = 5f;  // 자석의 범위
        public float magnetSpeed = 2f;  // 자석이 끌어당기는 속도
        private Transform hero;

        void Start()
        {

            GameObject heroObject = GameObject.FindGameObjectWithTag("Hero");
            if (heroObject != null)
            {
                hero = heroObject.transform;
            }
        }

        protected virtual void Update()
        {
            if (hero != null)
            {
                AttractExperienceItems();
            }
        }

        //나중에 플레이어쪽에서 range 값 가져오기
        protected void AttractExperienceItems()
        {
            GameObject[] experienceItems = GameObject.FindGameObjectsWithTag("Item");

            foreach (GameObject item in experienceItems)
            {
                float distance = Vector2.Distance(hero.position, item.transform.position);

                if (distance <= magnetRange)
                {
                    // Hero 위치로 아이템을 끌어당기기
                    Vector2 direction = (hero.position - item.transform.position).normalized;
                    item.transform.position = Vector2.MoveTowards(item.transform.position, hero.position, magnetSpeed * Time.deltaTime);
                }
            }
        }
    }
}