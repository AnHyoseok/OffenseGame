using IdleGame.Enemy;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace IdleGame.Hero
{
    /// <summary>
    /// 영웅의 체력 관리
    /// </summary>
    public class HeroHealth : MonoBehaviour, IDamageable
    {
        #region Variables
        [Header("Hero Stats")]
        public int maxHealth = 100;      // 최대 체력
        private int currentHealth;       // 현재 체력

        [Header("UI Elements")]
        public Image imageBackground;    // 체력바 배경 이미지
        public Image imageFill;          // 체력바 채우기 이미지
        public TextMeshProUGUI hpText;              // 체력 표시 텍스트
        #endregion

        void Start()
        {
            currentHealth = maxHealth;  // 시작 시 체력을 최대 체력으로 설정
            UpdateHealthUI();           // 초기 체력 UI 업데이트
        }


        //void OnTriggerEnter2D(Collider2D collider)
        //{
        //    //'Enemy' 태그를 가진 트리거에 닿았을 때 체력 감소
        //    if (collider.CompareTag("Enemy"))
        //    {

        //        EnemyStatus enemy = collider.GetComponent<EnemyStatus>();
        //        if (enemy != null)
        //        {
        //            TakeDamage(enemy.damage);
        //        }
        //    }
        //}

        // 데미지를 받았을 때 호출
        public void TakeDamage(int amount)
        {
            currentHealth -= amount;

            // 체력 최소값 보정
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

            Debug.Log($"Hero  {amount} damage. Current Health: {currentHealth}");

            UpdateHealthUI(); // 체력 UI 업데이트

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        // 영웅 사망 처리
        void Die()
        {
            Debug.Log("Hero Died");


            Destroy(gameObject); // 영웅 오브젝트 파괴 
        }

        // 체력 UI 업데이트
        void UpdateHealthUI()
        {
            if (imageFill != null)
            {
                // 체력 비율 계산
                float healthRatio = (float)currentHealth / maxHealth;
                imageFill.fillAmount = healthRatio;
            }

            if (hpText != null)
            {
                // 체력 텍스트 업데이트
                hpText.text = $"hp : {currentHealth} ";
            }
        }
    }
}
