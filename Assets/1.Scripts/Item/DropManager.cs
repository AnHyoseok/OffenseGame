using UnityEngine;
using System.Collections.Generic;

public class DropManager : MonoBehaviour
{
    // 싱글톤 인스턴스
    public static DropManager Instance { get; private set; }

    public List<DropTable> dropTables;

    private void Awake()
    {
        // 싱글톤 인스턴스 설정
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("DropManager 인스턴스가 이미 존재합니다. 새로운 인스턴스가 무시됩니다.");
            Destroy(gameObject);
        }
    }
    public void DropItem(Vector3 dropPosition)
    {
        // 1. 전체 드랍 테이블에서 하나의 테이블을 확률적으로 선택
        DropTable selectedTable = GetRandomDropTable();

        if (selectedTable != null)
        {
            // 2. 선택된 테이블에서 아이템을 확률적으로 선택
            Item droppedItem = GetRandomItemFromTable(selectedTable);

            if (droppedItem != null)
            {
                // 3. 아이템 드랍
                Instantiate(droppedItem.itemPrefab, dropPosition, Quaternion.identity);
                Debug.Log($"드랍된 아이템: {droppedItem.itemName}");
            }
        }
    }

    private DropTable GetRandomDropTable()
    {
        float totalRate = 0f;
        foreach (var table in dropTables)
        {
            totalRate += table.dropRate;
        }

        float randomValue = Random.Range(0f, totalRate);
        float cumulative = 0f;

        foreach (var table in dropTables)
        {
            cumulative += table.dropRate;
            if (randomValue <= cumulative)
            {
                return table;
            }
        }

        return null;
    }

    private Item GetRandomItemFromTable(DropTable table)
    {
        float totalChance = 0f;
        foreach (var item in table.items)
        {
            totalChance += item.dropChance;
        }

        float randomValue = Random.Range(0f, totalChance);
        float cumulative = 0f;

        foreach (var item in table.items)
        {
            cumulative += item.dropChance;
            if (randomValue <= cumulative)
            {
                return item;
            }
        }

        return null;
    }
}
