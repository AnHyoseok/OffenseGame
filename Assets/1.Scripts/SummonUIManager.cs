using IdleGame.enemy;
using UnityEngine;
using UnityEngine.UI;

public class SummonUIManager : MonoBehaviour
{
    public Button[] buttons;
    public int[] enemyCounts;
    public EnemySpawn enemySpawn; // EnemySpawn ��ũ��Ʈ�� ���� ����

    void Start()
    {
        // �� ��ư�� Ŭ�� �����ʸ� �߰�
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
