using UnityEngine;

namespace FPSGame
{
    public class EnemyPatrolState : EnemyState
    {
        protected override void OnEnable()
        {
            base.OnEnable();

            // �������� ���� ���� ����
            int index = Random.Range(0, data.Waypoints.Count);
            Vector3 destination = data.Waypoints[index].position;

            manager.SetAgentDestination(destination, data.PatrolSpeed);
        }

        protected override void Update()
        {
            base.Update();

            // �÷��̾ �þ� �ȿ� ������ �Ѿư���
            // �÷��̾ ����־�� ��
            float distanceToPlayer = (manager.PlayerTransform.position - refTransform.position).magnitude;

            if (!manager.IsPlayerDead && distanceToPlayer <= data.TraceDistance)
            {
                manager.SetState(EnemyStateManager.State.Trace);
                return;
            }

            // �����ߴ��� Ȯ�� �� ����������, Idle ���·� ��ȯ
            if (manager.Agent.remainingDistance <= 0.2f)
            {
                manager.SetState(EnemyStateManager.State.Idle);
                manager.StopAgent();
            }
        }
    }
}