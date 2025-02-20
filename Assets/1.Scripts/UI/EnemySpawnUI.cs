using UnityEngine;
using UnityEngine.UI;
using IdleGame.Enemy;

public class EnemySpawnUI2D : MonoBehaviour
{
    public EnemySpawnMouse spawnManager;
    public Button[] enemyButtons;

    void Start()
    {
        
   
        for (int i = 0; i < enemyButtons.Length; i++)
        {
            int index = i;
            enemyButtons[i].onClick.AddListener(() => spawnManager.SelectEnemy(index));
        }
    }
}
