using UnityEngine;
using UnityEngine.AI;

namespace FPSGame
{
    // 네비게이션 메시 에이전트 테스트 스크립트
    public class EnemyNavTester : MonoBehaviour
    {
        // 길찾기 시스템 위에서 이동을 할 수 있는 에이전트 클래스
        [SerializeField] private NavMeshAgent agent;
        // 이동할 목적지
        [SerializeField] private Transform destination;

        // 트랜스폼 컴포넌트 참조 변수
        private Transform refTransform;

        private void Awake()
        {
            // 에이전트에 목적지 설정
            if (agent == null)
                agent = GetComponent<NavMeshAgent>();

            /// 유니티는 C# 사용 , 실제 엔진이 사용하는 언어는 C++
            /// C#이 C++의 함수를 호출(dll 사용)
            /// 언어가 다른 시스템을 횡단(마샬링) -> 다른 언어의 함수를 호출하는건 리소스가 많이듬
            /// 따라서 Unity 내장 기능을 사용할 땐 미리 선언하고 사용하는게 효율적임.
            if (refTransform == null)
                refTransform = transform;

            agent.SetDestination(destination.position);
            agent.isStopped = false;
        }

        private void Update()
        {
            agent.SetDestination(destination.position);
            // 도착했는지 확인 후 도착했으면 에이전트 정지
            // 1. 도착했는지 확인 -> 목표위치와 내 위치와의 거리를 측정해서 확인
            //float remainDistance = (destination.position - refTransform.position).magnitude;

            // 루트 계산이 리소스를 많이먹어서 제곱만 처리
            float remainDistance = (destination.position - refTransform.position).sqrMagnitude;

            // 2. 정지
            //if (remainDistance <= 0.2f)

            // 정확한 거리가 필요한 경우엔 루트를 통해서 정확한 거리를 측정해야하지만
            // 그렇지 않은경우엔 제곱으로 처리하는것이 효율적이다.
            if (remainDistance <= (0.2f * 0.2f))
            {
                // 정지 처리
                agent.isStopped = true;

                // 속력 0으로 설정
                agent.velocity = Vector3.zero;
            }
        }
    }

}
