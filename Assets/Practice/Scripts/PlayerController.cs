using UnityEngine;

namespace FPSGame
{
    public class PlayerController : MonoBehaviour
    {
        public enum State
        {
            Idle,
            Move,
            None,
        }

        // 상태 변수.
        [SerializeField] private State currentState = State.None;

        // 스테이트 컴포넌트 배열 변수.
        [SerializeField] private PlayerState[] states;

        // 애니메이션 컨트롤러 변수.
        [SerializeField] private PlayerAnimationController animationController;

        // 입력 값을 저장하는 변수.
        public static float Horizontal { get; private set; } = 0f;
        public static float Vertical { get; private set; } = 0f;

        // 캐릭터 회전에 사용.
        public static float Turn { get; private set; } = 0f;    // 좌우 드래그.
        public static float Look { get; private set; } = 0f;    // 상하 드래그.

        private void OnEnable()
        {
            // 처음 시작할 스테이트 설정
            SetState(State.Idle);
        }

        // 상태 설정 함수.
        public void SetState(State newState)
        {
            // 예외 처리.
            // try-catch ( 될 수 있으면 쓰지 마세요 ).
            if (currentState == newState)
            {
                return;
            }

            if (currentState != State.None)
            {
                // 현재 상태 스크립트 끄기.
                states[(int)currentState].enabled = false;
            }


            // 새로운 상태 스크립트 켜기.
            states[(int)newState].enabled = true;

            // 상태 변수 업데이트.
            currentState = newState;

            // 애니메이션 설정.
            animationController.SetStateParameter((int)currentState);
        }

        private void Update()
        {
            // 방향키 입력 저장.
            Horizontal = Input.GetAxis("Horizontal");
            Vertical = Input.GetAxis("Vertical");

            // 마우스 드래그 값 저장.
            Turn = Input.GetAxis("Mouse X");
            Look = Input.GetAxis("Mouse Y");

            // 입력이 없는 지 확인.
            if (PlayerInputManager.Horizontal == 0f
                && PlayerInputManager.Vertical == 0f)
            {
                // 입력이 없으면 기본 상태로 전환.
                SetState(State.Idle);
            }
            else
            {
                // 이동 상태로 전환.
                SetState(State.Move);

                // 애니메이션 설정.
                animationController.SetHorizontalParameter(PlayerInputManager.Horizontal);

                animationController.SetVerticalParameter(PlayerInputManager.Vertical);
            }
        }
    }
}