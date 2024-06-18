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
            Trace,
            Attack,
            Dead,
        }

        // �� ĳ������ ���� ���� ���� ��Ÿ��
        [SerializeField] private State state = State.None;
        // �� ���¸� ����� ��ũ��Ʈ Ŭ������ �迭(�����Ϳ��� ����)
        [SerializeField] private EnemyState[] states;
        [SerializeField] private EnemyData data;
        // �� ĳ������ ���°� ����Ǵ� ����Ǵ� �̺�Ʈ
        // ������ ����
        // ���� : ������� �����
        // ���� : ��Ŀ�ø�
        [SerializeField] private UnityEvent<State> OnEnemyStateChanged;
        [SerializeField] private Transform trWaypointGroup;

        // ���� �޽� ������Ʈ ������Ƽ
        public NavMeshAgent Agent { get; private set; }

        // �÷��̾� ����
        public Transform PlayerTransform { get; private set; }

        // �÷��̾��� ���� ����
        public bool IsPlayerDead { get; private set; }

        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            StopAgent();

            // ������ �ʱ�ȭ
            // waypoint ���� ������Ʈ �˻�
            trWaypointGroup = GameObject.FindGameObjectWithTag("WaypointGroup").transform;
            data.Initialize(trWaypointGroup);

            foreach (var state in states)
                state.SetData(data);

            // �÷��̾� ���� �ʱ�ȭ
            // �̱����� ����Ҽ� ������ Ŀ�ø� ����
            PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;

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
            Agent.speed = moveSpeed;
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

        // �� ĳ������ ���� ����
        public bool IsDead
        {
            get { return state == State.Dead; }
        }

        // �÷��̾ �׾��� �� ����� �̺�Ʈ ������ �޼ҵ�
        public void OnPlayerDead()
        {
            IsPlayerDead = true;
            SetState(State.Idle);
            StopAgent();
        }
    }
}