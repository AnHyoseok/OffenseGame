using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace IdleGame.Hero
{
    public class HeroLevel : MonoBehaviour
    {
        public int level = 1;                  // 현재 레벨
        public int currentExp = 0;             // 현재 경험치
        public int expToNextLevel = 100;       // 다음 레벨까지 필요한 경험치

        [Header("UI Elements")]
        public TextMeshProUGUI levelText;      // 레벨을 표시할 UI 텍스트
        public TextMeshProUGUI expText;        // 남은 경험치를 표시할 UI 텍스트
        public Slider expSlider;               // 경험치 진행도를 표시할 UI 슬라이더

        void Start()
        {
            UpdateUI();
        }

        // 경험치 획득 메서드
        public void GainExperience(int amount)
        {
            currentExp += amount;

            // 레벨 업 확인
            while (currentExp >= expToNextLevel)
            {
                currentExp -= expToNextLevel;
                LevelUp();
            }

            UpdateUI();
        }

        // 레벨 업 처리
        void LevelUp()
        {
            level++;
            // 필요한 경험치 증가 (예: 20% 증가)
            expToNextLevel = Mathf.RoundToInt(expToNextLevel * 1.2f);
            Debug.Log($"레벨 업! 현재 레벨: {level}");

            // 레벨 업 시 추가 효과를 여기에 추가하세요 (예: 스탯 증가, 스킬 해제 등)
        }

        // UI 업데이트
        void UpdateUI()
        {
            if (levelText != null)
                levelText.text = $"Lvl: {level}";

            if (expText != null)
            {
                int expRemaining = expToNextLevel - currentExp;
                expText.text = $"Next Exp: {expRemaining}";
            }

            if (expSlider != null)
                expSlider.value = (float)currentExp / expToNextLevel;
        }
    }
}
