using IdleGame.Enemy;
using UnityEngine;

public class SkillProjectile : MonoBehaviour
{
    public float speed = 10f;  // 투사체 속도
    public int damage = 20;    // 데미지
    public float maxDistance = 5f;  // 최대 사거리

    private Transform target;  // 타겟(가장 가까운 적)
    private Vector3 startPosition;  // 투사체 시작 위치
    private Vector3 direction;  // 이동 방향

    void Start()
    {
        target = FindClosestEnemy();
        startPosition = transform.position;  // 시작 위치 저장

        if (target != null)
        {
            // 적이 있으면 타겟 방향 설정
            direction = (target.position - transform.position).normalized;
        }
        else
        {
            // 적이 없으면 오른쪽(X 양수 방향)으로 이동
            direction = Vector3.right;
            transform.rotation = Quaternion.Euler(0, 0, -45f);  // Z축 -45도 회전
        }
    }

    void Update()
    {
        // 투사체 이동
        transform.position += direction * speed * Time.deltaTime;

        // 적이 있는 경우 회전 보정
        if (target != null)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 45f));

            // 타겟과 충돌하면 제거
            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                ApplyDamage(target);
                Destroy(gameObject);
            }
        }

        // 사거리를 초과하면 제거
        if (Vector3.Distance(startPosition, transform.position) >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    // 가장 가까운 적을 찾는 함수
    Transform FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Transform closestEnemy = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                closestEnemy = enemy.transform;
                minDistance = distance;
            }
        }

        return closestEnemy;
    }

    // 데미지 적용 함수
    void ApplyDamage(Transform enemy)
    {
        EnemyStatus enemyScript = enemy.GetComponent<EnemyStatus>();  // 적 스크립트 가져오기
        if (enemyScript != null)
        {
            enemyScript.TakeDamage(damage);  // 데미지 적용
        }
    }
}
