using UnityEngine;

namespace FPSGame
{
    // �� ĳ���Ͱ� Idle ������ �� ����� ��ũ��Ʈ
    // 1. ������ �ð���ŭ ���
    // 2. ���� ���·� ��ȯ
    public class EnemyIdleState : EnemyState
    {
        // ����� �ð� ��
        [SerializeField] private float waitTime = 0f;

        // ����ð� ���� ����
        [SerializeField] private float elapsedTime = 0f;

        protected override void OnEnable()
        {
            base.OnEnable();

            // ����� �ð� ����
            waitTime = Random.Range(data.PatrolWaitTime * 0.8f, data.PatrolWaitTime * 1.2f);

            // ��� �ð� ���� �ʱ�ȭ
            elapsedTime = 0f;
        }

        protected override void Update()
        {
            base.Update();

            // �ð� ������Ʈ
            elapsedTime += Time.deltaTime;
            
            // ��� �ð����� �� ��������
            if (elapsedTime > waitTime)
            {
                // ���� ��ȯ -> ���� �����ڸ� ���ؼ� ��ȯ
                manager.SetState(EnemyStateManager.State.Patrol);
            }
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            // ����� ���� �ʱ�ȭ.
            elapsedTime = 0f;
            waitTime = 0f;
        }
    }
}