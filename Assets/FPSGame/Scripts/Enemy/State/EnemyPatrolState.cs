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

            // �����ߴ��� Ȯ�� �� ����������, Idle ���·� ��ȯ
            if (manager.Agent.remainingDistance <= 0.2f)
            {
                manager.SetState(EnemyStateManager.State.Idle);
                manager.Agent.isStopped = true;
                manager.Agent.velocity = Vector3.zero;
            }
        }
    }
}