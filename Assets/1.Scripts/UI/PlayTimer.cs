using TMPro;
using UnityEngine;

namespace IdleGame.UI
{
    public class PlayTimer : MonoBehaviour
    {
        public float totalTime = 900f;
        private float remainingTime;
        public TextMeshProUGUI timerText;
        private GameController gameController;

        void Start()
        {
            remainingTime = totalTime;
            gameController = FindAnyObjectByType<GameController>();
            if (gameController == null)
            {
                Debug.LogError("GameController not found in the scene!");
            }
        }

        void Update()
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;

                int minutes = Mathf.FloorToInt(remainingTime / 60f);
                int seconds = Mathf.FloorToInt(remainingTime % 60f);
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            else
            {
                remainingTime = 0;
                timerText.text = "00:00";
                Debug.Log("ÆÐ¹è!");
                gameController.LoseGame();
            }
        }
    }
}
