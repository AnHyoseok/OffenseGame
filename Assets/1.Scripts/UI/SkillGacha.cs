using IdleGame.Hero;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace IdleGame.UI
{
    public class SkillGacha : MonoBehaviour
    {
        public GameObject heroSkillUI;
        public GameObject[] skilluiList; // 스킬 UI 리스트
        public GameObject[] skillList;   // 스킬 목록 5개
        public Button[] skillButtons;    // 스킬 선택 버튼 (UI 상의 버튼들)
        public Color hoverColor;         // 호버 상태 색상

        private HeroLevel heroLevel;     // HeroLevel 변수 선언

        private void Start()
        {
            heroLevel = FindObjectOfType<HeroLevel>(); // HeroLevel 초기화

            // 각 버튼에 대한 클릭 이벤트를 설정
            for (int i = 0; i < skillButtons.Length; i++)
            {
                int index = i; // 버튼 클릭 시 사용할 인덱스 값을 저장 (클로저 문제 해결)
                skillButtons[i].onClick.AddListener(() => OnSkillSelected(index));
            }
        }

        private void Update()
        {
            if (heroLevel != null && heroLevel.isLevelUp)
            {
                showSkillGacha();
            }
        }

        void showSkillGacha()
        {
            // 스킬 UI를 활성화하고 게임을 일시정지
            heroSkillUI.SetActive(true);
            Time.timeScale = 0;

            // 스킬 목록 5개에서 랜덤하게 3개를 선택하여 UI 리스트에 추가
            SelectRandomSkills();

            // 레벨업 플래그를 초기화
            heroLevel.isLevelUp = false;
        }

        // 스킬 목록에서 랜덤으로 3개의 스킬을 선택하여 skilluiList에 넣음
        void SelectRandomSkills()
        {
            // 랜덤으로 3개의 스킬을 선택하여 skilluiList에 넣음
            bool[] selected = new bool[skillList.Length];
            int selectedCount = 0;

            // 스킬 UI를 비활성화
            foreach (var ui in skilluiList)
            {
                ui.SetActive(false);
            }

            StartCoroutine(DisplayHoverEffectsRandomly());
        }

        // 호버 효과를 랜덤 순서로 표시하는 코루틴
        IEnumerator DisplayHoverEffectsRandomly()
        {
            bool[] selected = new bool[skillList.Length];
            int selectedCount = 0;

            // 랜덤 순서로 3개의 UI 항목을 활성화
            while (selectedCount < 3)
            {
                int randomIndex = Random.Range(0, skilluiList.Length);
                if (!selected[randomIndex])
                {
                    selected[randomIndex] = true;
                    skilluiList[selectedCount].SetActive(true); // 해당 UI 활성화

                    // 랜덤한 시간 동안 호버 효과를 주기 위해 약간 지연
                    skilluiList[selectedCount].GetComponentInChildren<Text>().text = skillList[randomIndex].name; // 스킬 이름 설정
                    skilluiList[selectedCount].GetComponent<Image>().color = hoverColor; // 호버 색상 적용
                    selectedCount++;

                    // 잠시 기다린 후 색상 원상복구
                    yield return new WaitForSeconds(0.5f);
                    skilluiList[selectedCount - 1].GetComponent<Image>().color = Color.white; // 호버 색상 복구
                }
            }

            // 3개의 UI 항목이 모두 표시된 후, 랜덤으로 스킬을 선택
            int randomSkillIndex = Random.Range(0, 3);
            OnSkillSelected(randomSkillIndex);
        }

        // 스킬을 선택했을 때 호출되는 함수
        void OnSkillSelected(int index)
        {
            // 선택된 스킬에 대한 처리
            Debug.Log($"Selected Skill: {skilluiList[index].GetComponentInChildren<Text>().text}");

            // UI 창 닫기
            heroSkillUI.SetActive(false);
            Time.timeScale = 1; // 게임 속도 복구
        }
    }
}
