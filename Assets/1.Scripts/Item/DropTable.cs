using System.Collections.Generic;

[System.Serializable]
public class DropTable
{
    public string tableName;      // ��� ���̺� �̸�
    public List<Item> items;      // ������ ����Ʈ
    public float dropRate;        // �� ���̺��� �������� ���õ� Ȯ�� (0 ~ 100)
}
