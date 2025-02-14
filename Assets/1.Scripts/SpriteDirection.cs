using UnityEngine;

namespace IdleGame.Character
{
    public class SpriteDirection : MonoBehaviour
    {
        protected SpriteRenderer spriteRenderer;
        protected Vector3 lastPosition;
        private Vector3 originalScale; // 기본 크기 저장

        protected virtual void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            lastPosition = transform.position;
            originalScale = transform.localScale; // 초기 스케일 저장
        }

        protected virtual void UpdateSpriteDirection()
        {
            Vector3 movementDirection = transform.position - lastPosition;

            if (movementDirection.x > 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
            }
            else if (movementDirection.x < 0)
            {
                transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
            }

            lastPosition = transform.position;
        }
    }
}
