using UnityEngine;

namespace FPSGame
{
    public class PlayerControl : MonoBehaviour
    {
        // 이동속도
        [SerializeField] private float moveSpeed = 5f;

        // Animator 컴포넌트 변수
        [SerializeField] private Animator refAnimator;

        // 트랜스폼 컴포넌트 참조 변수
        private Transform refTransform;

        enum State
        {
            Idle = 0,
            RunF
        }

        private void Awake()
        {
            refTransform = transform;

            refAnimator = GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            // 이동
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            // 애니메이션 설정
            if (horizontal != 0f || vertical != 0f) refAnimator.SetInteger("State", (int)State.RunF);
            else refAnimator.SetInteger("State", (int)State.Idle);

            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            refTransform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}
