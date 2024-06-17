using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace FPSGame
{
    // ���±�踦 ������ ������ ��ũ��Ʈ
    public class EnemyStateManager : MonoBehaviour
    {
        // �� ĳ���Ͱ� ���� ���¸� ��Ÿ���� ������
        public enum State
        {
            None = -1,
            Idle,
            Patrol,
            Dead,
        }

        // �� ĳ������ ���� ���� ���� ��Ÿ��
        [SerializeField] private State state = State.None;
        // �� ���¸� ����� ��ũ��Ʈ Ŭ������ �迭(�����Ϳ��� ����)
        [SerializeField] private EnemyState[] states;
        [SerializeField] private EnemyData data;
        // �� ĳ������ ���°� ����Ǵ� ����Ǵ� �̺�Ʈ
        [SerializeField] private UnityEvent<State> OnEnemyStateChanged;

        // ���� �޽� ������Ʈ ������Ƽ
        public NavMeshAgent Agent { get; private set; }

        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            Agent.updateRotation = false;
            Agent.isStopped = true;

            // ������ �ʱ�ȭ
            // waypoint ���� ������Ʈ �˻�
            data.Initialize(GameObject.FindGameObjectWithTag("WaypointGroup").transform);

            foreach (var state in states)
                state.SetData(data);

            SetState(State.Idle);
        }

        // ���� ��ȯ �޼ҵ� (�޽���)
        public void SetState(State newState)
        {
            // ����ó�� (�����Ϸ��� ���°� ���� ���¿� ������ Ȯ��)
            if (state == newState) return;

            // ���� ���� ��Ȱ��ȭ
            if (state != State.None)
                states[(int)state].enabled = false;

            // ���ο� ���� Ȱ��ȭ
            if (newState != State.None)
                states[(int)newState].enabled = true;

            // ���� ���� ������Ʈ
            state = newState;

            // ���� ���� �̺�Ʈ ����
            OnEnemyStateChanged?.Invoke(state);
        }

        // ���� �޽� ������Ʈ�� �̵� ��ų�� ����� �޼ҵ�
        public void SetAgentDestination(Vector3 destination, float moveSpeed)
        {
            // ���� �޽� ������Ʈ�� ���� ��ġ�� �̵� ��ǥ�������� ����
            Agent.SetDestination(destination);
            Agent.speed = data.PatrolSpeed;
            Agent.isStopped = false;
            Agent.updateRotation = true;
        }

        // ������Ʈ�� ������Ű�� �޽���
        public void StopAgent()
        {
            Agent.isStopped = true;
            Agent.velocity = Vector3.zero;
            Agent.updateRotation = false;
        }

        // �׾��� �� ����� �޽���
        public void OnEnemyDead()
        {
            // ���¸� Dead�� ����
            SetState(State.Dead);

            // ���� �޽� ������Ʈ ����.
            StopAgent();
        }
    }
}