using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace IdleGame.UI
{
    /// <summary>
    /// 남은 게임시간 표시
    /// </summary>
public class PlayTimer : MonoBehaviour
{
    public float totalTime = 900f; 
    private float remainingTime;
    public TextMeshProUGUI timerText; 

    void Start()
    {
        remainingTime = totalTime;
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
            Debug.Log("패배!");
       
        }
    }
}

}