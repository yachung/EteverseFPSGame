using System.Collections.Generic;
using UnityEngine;

namespace FPSGame
{
    // �� ĳ���Ͱ� ����� ������ ��ũ��Ʈ
    public class EnemyData : MonoBehaviour
    {
        // ����.
        [SerializeField] private float attackDistance = 5f;           // ���� ���� �Ÿ�(���� ����).
        public float AttackDistance { get { return attackDistance; } }

        [SerializeField] private float traceDistance = 10f;           // �߰� ���� �Ÿ�(���� ����).
        public float TraceDistance { get { return traceDistance; } }

        [SerializeField] private float patrolWaitTime = 3f;           // ������ ������ ����ϴ� �ð�(��).
        public float PatrolWaitTime { get { return patrolWaitTime; } }

        [SerializeField] private float moveRotateDamping = 7f;        // �̵� �� ȸ�� ���� ��.
        public float MoveRotateDamping { get { return moveRotateDamping; } }

        [SerializeField] private float attackRotateDamping = 10f;     // ���� �� ȸ�� ���� ��.
        public float AttackRotateDamping { get { return attackRotateDamping; } }

        [SerializeField] private float fireRate = 0.2f;               // �߻� ����(��).
        public float FireRate { get { return fireRate; } }

        [SerializeField] private int maxBullet = 3;                   // �ִ� ź�� ��.
        public float MaxBullet { get { return maxBullet; } }

        [SerializeField] private float maxHP = 100f;                  // ü��
        public float MaxHP { get { return maxHP; } }

        [SerializeField] private readonly float patrolSpeed = 1.5f;   // ���� �� �̵� �ӵ�.
        public float PatrolSpeed { get { return patrolSpeed; } }

        [SerializeField] private readonly float traceSpeed = 3.5f;    // �߰� �� �̵� �ӵ�.
        public float TraceSpeed { get { return traceSpeed; } }

        [SerializeField] private readonly float reloadTime = 2f;      // ������ �ð�.
        public float ReloadTime { get { return reloadTime; } }

        [SerializeField] private List<Transform> waypoints;           // ���� ��ġ (�迭).
        public List<Transform> Waypoints { get { return waypoints; } }

        // ���� ��ġ �ʱ�ȭ �Լ�.
        public void Initialize(Transform waypointGroup)
        {
            // waypointGroup Ʈ�������� �ڽ� Ʈ�������� ��� ���� �������� ����.
            waypointGroup.GetComponentsInChildren(waypoints);

            // 0�� Ʈ�������� �ڱ� �ڽ��̱� ������ ����.
            waypoints.RemoveAt(0);
        }
    }
}
