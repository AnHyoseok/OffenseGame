using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;   // ������ �̸�
    public GameObject itemPrefab; // �������� ������
    public float dropChance;  // �������� ��� Ȯ�� (0 ~ 100)
}
