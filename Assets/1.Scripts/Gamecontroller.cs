using UnityEngine;
using UnityEngine.SceneManagement;


    public class GameController : MonoBehaviour
    {
        public void WinGame()
        {
            // 승리 처리
            Debug.Log("You win!");
            // 필요한 경우 여기서 다른 승리 처리 로직을 추가합니다.
        }

        public void LoseGame()
        {
            // 패배 처리
            Debug.Log("You lose!");
            // 필요한 경우 여기서 다른 패배 처리 로직을 추가합니다.
        }
    }

