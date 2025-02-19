using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

namespace IdleGame.Enemy
{
    public class EnemySpawnMouse : MonoBehaviour
    {
        public GameObject[] enemyPrefabs; // 소환할 적 
        public GameObject previewPrefab; // 프리뷰 오브젝트
        public float spawnDelay = 0.5f; // 적 소환 딜레이

        private int selectedEnemyIndex = -1; // 선택된 적 인덱스
        private GameObject previewInstance; // 현재 프리뷰
        private Camera mainCamera;
        private bool canSpawn = true; // 딜레이 적용용 플래그

        public List<GameObject> spawnedEnemies = new List<GameObject>(); // 생성된 적 오브젝트 목록

        void Start()
        {
            mainCamera = Camera.main;
        }

        void Update()
        {
            if (selectedEnemyIndex >= 0)
            {
                FollowMouse();
                if (Input.GetMouseButton(0) && canSpawn && !IsPointerOverUI()) // 계속 누르고 있어도 한 마리씩 소환
                {
                    StartCoroutine(SpawnEnemyWithDelay());
                }
            }
        }

        public void SelectEnemy(int index)
        {
            selectedEnemyIndex = index;
            if (previewInstance == null)
            {
                previewInstance = Instantiate(previewPrefab);
            }
            previewInstance.GetComponent<SpriteRenderer>().sprite = enemyPrefabs[index].GetComponent<SpriteRenderer>().sprite;
            previewInstance.SetActive(true);
        }

        void FollowMouse()
        {
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            if (previewInstance != null)
            {
                previewInstance.transform.position = mousePosition;
            }
        }

        IEnumerator SpawnEnemyWithDelay()
        {
            canSpawn = false; // 다음 소환을 막음
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay); // 딜레이 적용
            canSpawn = true; // 다시 소환 가능하게 변경
        }

        void SpawnEnemy()
        {
            Vector3 spawnPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            spawnPosition.z = 0f;
            GameObject spawnedEnemy = Instantiate(enemyPrefabs[selectedEnemyIndex], spawnPosition, Quaternion.identity);
            spawnedEnemies.Add(spawnedEnemy); // 생성된 적을 목록에 추가
        }

        public void SpawnEnemyAtIndex(int index)
        {
            Vector3 spawnPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            spawnPosition.z = 0f;
            GameObject spawnedEnemy = Instantiate(enemyPrefabs[index], spawnPosition, Quaternion.identity);
            spawnedEnemies.Add(spawnedEnemy); // 생성된 적을 목록에 추가
        }

        bool IsPointerOverUI()
        {
            return EventSystem.current.IsPointerOverGameObject();
        }
    }
}
