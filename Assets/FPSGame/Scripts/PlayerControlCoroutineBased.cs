using UnityEngine;

namespace FPSGame
{
    // 코루틴 기반 유한 상태 기계 스크립트
    // Sline is violent.
    public class PlayerControlCoroutineBased : MonoBehaviour
    {
        public enum State
        {
            Idle, Move
        }

        // 현재 상태를 보여주는 상태 변수
        [SerializeField] private State currentState = State.Idle;
        
        // 상태를 변경(설정)하는 함수(메소드)
        public void SetState(State newState)
        {
            currentState = newState;
        }

        // FSM 실행 함수.

        // Idle 상태 함수.

        // Move 상태 함수.
    }

}
