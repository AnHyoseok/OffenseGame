using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace IdleGame
{
    public class StageSelectController : MonoBehaviour
    {
        #region Variables
        public GameObject baseCanvas;
        public GameObject stageCanvas;
        public GameObject informationUI;
        public Image informationUIImage;
        public TextMeshProUGUI mapNameText;
        public TextMeshProUGUI bossNameText;
        public Button startButton;
        public Button backButton;

        public Button[] stageButtons;
        public Sprite[] stageImages;
        public string[] stageNames;
        public string[] bossNames;

        private string selectedMapName; 
        #endregion

        void Start()
        {
            for (int i = 0; i < stageButtons.Length; i++)
            {
                int index = i;
                stageButtons[i].onClick.AddListener(() => OnStageButtonClicked(index));
            }

            // Start 버튼에 클릭 이벤트 추가
            startButton.onClick.AddListener(OnStartButtonClicked);
            backButton.onClick.AddListener(OnBackButtonClicked);
            // 기본적으로 정보 UI 비활성화
            informationUI.SetActive(false);
        }

        void OnStageButtonClicked(int index)
        {
            // 정보 UI 활성화
            informationUI.SetActive(true);

            // 이미지 및 텍스트 및 스킬 정보 활성화
            if (index < stageImages.Length)
            {
                informationUIImage.sprite = stageImages[index];
            }

            if (index < stageNames.Length)
            {
                mapNameText.text = stageNames[index];
                selectedMapName = stageNames[index]; // 선택된 맵 이름 설정
            }

            if (index < bossNames.Length)
            {
                bossNameText.text = bossNames[index];
            }
        }

        void OnStartButtonClicked()
        {
            // 선택된 맵 이름으로 씬 전환
            if (!string.IsNullOrEmpty(selectedMapName))
            {
                SceneManager.LoadScene(selectedMapName);
            }
        }

        void OnBackButtonClicked()
        {
            informationUI.SetActive(false);
            baseCanvas.SetActive(true);
            //나중에 애니메이션으로 변경
            stageCanvas.SetActive(false);
           
        }
    }
}
