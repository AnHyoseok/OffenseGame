using UnityEngine;

namespace IdleGame.Character
{
    public class SpriteDirection : MonoBehaviour
    {
        protected SpriteRenderer spriteRenderer;
        protected Vector3 lastPosition;

        protected virtual void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            lastPosition = transform.position;
        }

        protected virtual void UpdateSpriteDirection()
        {
            Vector3 movementDirection = transform.position - lastPosition;

            // x축 이동 방향에 따라 flipX를 설정
            if (movementDirection.x > 0)
            {
                spriteRenderer.flipX = false; // 오른쪽으로 이동
            }
            else if (movementDirection.x < 0)
            {
                spriteRenderer.flipX = true; // 왼쪽으로 이동
            }

            lastPosition = transform.position;
        }
    }
}
