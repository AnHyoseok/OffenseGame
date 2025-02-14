using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;   // 아이템 이름
    public GameObject itemPrefab; // 아이템의 프리팹
    public float dropChance;  // 아이템의 드랍 확률 (0 ~ 100)
}
