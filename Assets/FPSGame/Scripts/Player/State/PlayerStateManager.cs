using UnityEngine;

namespace FPSGame
{
    // 플레이어의 상태를 제어하는 관리자 스크립트.
    public class PlayerStateManager : MonoBehaviour
    {
        // 플레이어의 상태를 나타내는 열거형 선언
        public enum State
        {
            Idle,
            Move
        }

        // 상태 변수
        [SerializeField] private State currentState = State.Idle;

        // 스테이트 컴포넌트 배열 변수
        [SerializeField] private PlayerState[] states;

        [SerializeField] private PlayerAnimationController controller;

        // 상태 설정
        public void SetState(State newState)
        {

            // 예외처리
            if (currentState == newState) return;

            // 현재 상태 스크립트 끄기
            states[(int)currentState].enabled = false;

            // 새로운 상태 스크립트 켜기
            states[(int)newState].enabled = true;

            // 상태 변수 업데이트
            currentState = newState;

            // 애니메이션 설정
            controller.SetStateParameter((int)currentState);
        }

        private void Update()
        {
            // 입력이 없는지 확인
            if (PlayerInputManager.Horizontal == 0f && PlayerInputManager.Vertical == 0f) SetState(State.Idle);
            else
            {
                // 이동 상태로 전환
                SetState(State.Move);

                // 애니메이션 설정
                controller.SetHorizontalParameter(PlayerInputManager.Horizontal);
                controller.SetVerticalParameter(PlayerInputManager.Vertical);
            }
        }
    }
}