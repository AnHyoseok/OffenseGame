using UnityEngine;

namespace IdleGame.Character
{
    public class SpriteDirection : MonoBehaviour
    {
        protected SpriteRenderer spriteRenderer;
        protected Vector3 lastPosition;
        private Vector3 originalScale; // �⺻ ũ�� ����

        protected virtual void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            lastPosition = transform.position;
            originalScale = transform.localScale; // �ʱ� ������ ����
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
