using UnityEngine;

namespace FPSGame
{
    // 플레이어 상태의 기반 클래스
    // 상태의 진입점-업데이트-종료 메소드 및 공통기능 제공
    public class PlayerState : MonoBehaviour
    {
        protected Transform refTransform;

        protected virtual void OnEnable()
        {
            if (refTransform == null)
            {
                refTransform = transform;
            }
        }

        protected virtual void Update()
        {
            
        }

        protected virtual void OnDisable()
        {
            
        }
    }

}
