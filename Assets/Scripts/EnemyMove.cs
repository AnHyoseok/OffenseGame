using UnityEngine;
using UnityEngine.AI; // Nav Mesh �� ����ϱ� ���� �ʿ��� using ��

public class EnemyMove : MonoBehaviour
{
    NavMeshAgent agent; // Ž�� �޽� ������Ʈ�� ���� ������ �ʿ�
    Transform target; // ���� Ÿ��
    [SerializeField] float speed = 1f;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false; // Agent �� Target �� ���� �̵��� �� ������ ȸ������
        agent.updateUpAxis = false; // ĳ������ �̵��� ������� �����ϱ� ����

        // PlayerController ������Ʈ�� ���� ������Ʈ�� ã��
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
            agent.SetDestination(target.position); // Agent���� target�� ���� ��ġ�� �̵��ϵ��� ����
        }
    }
}
