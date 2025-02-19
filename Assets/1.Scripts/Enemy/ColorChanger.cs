using System.Collections;
using UnityEngine;

namespace IdleGame.Enemy
{
    public class ColorChanger : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        public Color hitColor = Color.red;
        private Color originalColor;
        private bool isDamaged = false;

        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            originalColor = spriteRenderer.color;
        }

        void Update()
        {
            if (isDamaged)
            {
                spriteRenderer.color = hitColor;
            }
            else
            {
                spriteRenderer.color = originalColor;
            }
        }

        public void SetDamageState(bool damaged)
        {
            isDamaged = damaged;

            if (isDamaged)
            {
                StopAllCoroutines();  
                StartCoroutine(ResetColorAfterDelay(0.1f));  
            }
        }

        private IEnumerator ResetColorAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            isDamaged = false;
        }
    }
}
