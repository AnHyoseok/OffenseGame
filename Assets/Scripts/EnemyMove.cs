using UnityEngine;
using UnityEngine.AI; // Nav Mesh 를 사용하기 위해 필요한 using 문

public class EnemyMove : MonoBehaviour
{
    NavMeshAgent agent; // 탐색 메시 에이전트에 대한 참조가 필요
    Transform target; // 따라갈 타겟
    [SerializeField] float speed = 1f;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false; // Agent 가 Target 을 향해 이동할 때 방향을 회전할지
        agent.updateUpAxis = false; // 캐릭터의 이동을 평면으로 제한하기 위해

        // PlayerController 컴포넌트를 가진 오브젝트를 찾음
        PlayerController playerController = FindAnyObjectByType<PlayerController>();
        if (playerController != null)
        {
            target = playerController.transform;
        }
        else
        {
            Debug.LogError("PlayerController object not found!");
        }
    }

    void Update()
    {
        if (target != null)
        {
            agent.speed = speed;
            agent.SetDestination(target.position); // Agent에게 target의 현재 위치로 이동하도록 지시
        }
    }
}
