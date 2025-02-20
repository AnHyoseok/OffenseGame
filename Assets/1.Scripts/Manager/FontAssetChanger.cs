using UnityEngine;
using TMPro;

public class FontAssetChanger : MonoBehaviour
{
    public TMP_FontAsset newFontAsset;

    void Start()
    {
        ChangeFontAssets();
    }

    // UI가 활성화될 때마다 폰트 에셋 변경
    void OnEnable()
    {
        ChangeFontAssets();
    }

    void ChangeFontAssets()
    {
        // 모든 TextMeshProUGUI 컴포넌트 찾기 (비활성화된 오브젝트 포함)
        TextMeshProUGUI[] textMeshProsUGUI = FindObjectsByType<TextMeshProUGUI>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        foreach (TextMeshProUGUI tmp in textMeshProsUGUI)
        {
            // 폰트 에셋 변경
            tmp.font = newFontAsset;
        }

        // 모든 TextMeshPro 컴포넌트(TMP) 찾기 (비활성화된 오브젝트 포함)
        TextMeshPro[] textMeshProsTMP = FindObjectsByType<TextMeshPro>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        foreach (TextMeshPro tmp in textMeshProsTMP)
        {
            // 폰트 에셋 변경
            tmp.font = newFontAsset;
        }
    }

    public TextMeshProUGUI CreateNewTextMeshProUGUI(Vector3 position, string text)
    {
        GameObject newGameObject = new GameObject("NewTextMeshProUGUI");
        newGameObject.transform.position = position;

        TextMeshProUGUI newTMP = newGameObject.AddComponent<TextMeshProUGUI>();
        newTMP.font = newFontAsset; // 새로 생성된 텍스트의 폰트 에셋 설정
        newTMP.text = text;

        return newTMP;
    }

    public TextMeshPro CreateNewTextMeshPro(Vector3 position, string text)
    {
        GameObject newGameObject = new GameObject("NewTextMeshPro");
        newGameObject.transform.position = position;

        TextMeshPro newTMP = newGameObject.AddComponent<TextMeshPro>();
        newTMP.font = newFontAsset; // 새로 생성된 텍스트의 폰트 에셋 설정
        newTMP.text = text;

        return newTMP;
    }
}
