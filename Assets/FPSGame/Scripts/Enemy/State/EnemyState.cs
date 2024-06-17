using UnityEngine;

namespace FPSGame
{
    // 적 캐릭터의 상태 기계에 사용할 상태 스크립트의 기반 클래스
    public class EnemyState : MonoBehaviour
    {
        // 필드
        // 상태 관리자 스크립트 참조 변수
        protected EnemyStateManager manager;

        // 적 캐릭터 데이터 참조 변수.
        // 누군가 이 값을 설정해줘야 함 -> 상태 관리자에서 전달해 줌
        protected EnemyData data;

        // 트랜스폼 참조 변수
        protected Transform refTransform;

        // 데이터 설정 함수
        public void SetData(EnemyData data)
        {
            this.data = data;
        }

        // 상태기계에서 요구하는 조건 만족
        // 스테이트. 진입점 - 업데이트 - 종료

        // 진입점
        protected virtual void OnEnable()
        {
            // 참조 변수 초기화
            if (manager == null)
                manager = GetComponent<EnemyStateManager>();

            if (refTransform == null)
                refTransform = transform;
        }

        // 업데이트
        protected virtual void Update()
        {
            
        }

        // 종료
        protected virtual void OnDisable()
        {
            
        }
    }
}
