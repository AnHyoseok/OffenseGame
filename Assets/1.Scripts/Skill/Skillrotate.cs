using UnityEngine;

namespace IdleGame.Skil
{
    public class Skillrotate : MonoBehaviour
    {
        public float rotationSpeed = 50f; // 회전 속도
        private Transform heroTransform;

        void Start()
        {
            heroTransform = transform.parent; 
            if (heroTransform == null)
            {
                Debug.LogError("Skill이 Hero의 자식이 아닙니다!");
                return;
            }
        }

        void Update()
        {
            if (heroTransform != null)
            {
                //  Hero의 Scale.x 값에 따라 회전 방향 결정
                float direction = heroTransform.localScale.x > 0 ? -1f : 1f;
                transform.Rotate(0, 0, direction * rotationSpeed * Time.deltaTime);
            }
        }
    }
}
