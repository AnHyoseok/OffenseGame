using IdleGame.enemy;
using UnityEngine;
using UnityEngine.UI;

public class SummonUIManager : MonoBehaviour
{
    public Button[] buttons;
    public int[] enemyCounts;
    public EnemySpawn enemySpawn; // EnemySpawn 스크립트에 대한 참조

    void Start()
    {
        // 각 버튼에 클릭 리스너를 추가
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; 
            buttons[i].onClick.AddListener(() => SpawnEnemies(index, enemyCounts[index]));
        }
    }

    void SpawnEnemies(int enemyIndex, int count)
    {
        enemySpawn.SpawnEnemies(enemyIndex, count);
    }
}
