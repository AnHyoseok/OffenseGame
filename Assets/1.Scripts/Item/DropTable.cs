using System.Collections.Generic;

[System.Serializable]
public class DropTable
{
    public string tableName;      // 드랍 테이블 이름
    public List<Item> items;      // 아이템 리스트
    public float dropRate;        // 이 테이블에서 아이템이 선택될 확률 (0 ~ 100)
}
