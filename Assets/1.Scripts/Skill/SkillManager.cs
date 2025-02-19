using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public GameObject skillPrefab;  // SkillProjectile 프리팹
    public Transform hero;  // Hero의 위치
    public SkillSystem skillSystem;  // SkillSystem 객체
    public SkillData someSkillData;

    void Start()
    {

        skillSystem = new SkillSystem();  // SkillSystem 객체 생성
        skillSystem.skillData = someSkillData;  
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))  // Q키를 눌렀을 때
        {
            CreateSkill();  // 스킬 생성
        }
        skillSystem.Update();  // 매 프레임 Update 호출
    }
    void CreateSkill()
    {
        // Hero 위치에서 SkillProjectile 생성
        Instantiate(skillPrefab, hero.position, Quaternion.identity);
    }
    // 스킬 활성화
    public void ActivateSkill()
    {
        skillSystem.ActivateSkill();  // 스킬 활성화
    }

    // 스킬 비활성화
    public void DeactivateSkill()
    {
        skillSystem.DeactivateSkill();  // 스킬 비활성화
    }
}
