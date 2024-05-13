using UnityEngine;

// Todo: 모시기모시기
namespace FPSGame
{
    public class CameraRig : MonoBehaviour
    {
        // Todo: 플레이어를 따라다니는 카메라 기능 추가.

        // 카메라가 따라다닐 대상.
        [SerializeField] private Transform target;

        // 이동할 때 적용할 지연값.
        [SerializeField] private float damping = 5f;

        private Transform refTransform;

        private void Awake()
        {
            refTransform = transform;
        }

        // 매 프레임 Update 뒤에 실행 됨.
        private void LateUpdate()
        {
            // Lerp
            refTransform.position = Vector3.Lerp(
                refTransform.position,
                target.position,
                damping * Time.deltaTime
                );
        }
        /*
         * 플레이어만 따라다니면 실제 벡터 계산은 엔진이 대신해줌
         */
    }
}
