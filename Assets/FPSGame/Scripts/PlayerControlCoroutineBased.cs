using System.Collections;
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

        // 이동속도
        [SerializeField] private float moveSpeed = 5f;

        // Animator 컴포넌트 변수
        [SerializeField] private Animator refAnimator;

        // 트랜스폼 컴포넌트 참조 변수
        private Transform refTransform;

        private void Awake()
        {
            refTransform = transform;
            refAnimator = GetComponentInChildren<Animator>();
            StartCoroutine(FSMStart());
        }

        // 상태를 변경(설정)하는 함수(메소드)
        public void SetState(State newState)
        {
            currentState = newState;
            refAnimator.SetInteger("State", (int)currentState); 
        }

        // 업데이트
        public void Update() 
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (horizontal == 0f && vertical == 0f) SetState(State.Idle);
            else SetState(State.Move);
        }

        // FSM 실행 함수.
        IEnumerator FSMStart()
        {
            while (true)
            {
                yield return StartCoroutine(currentState.ToString());
            }
        }

        // Idle 상태 함수.
        IEnumerator Idle()
        {
            while (currentState == State.Idle)
            {
                // 1 프레임 대기
                yield return null;
            }
        }

        // Move 상태 함수.
        IEnumerator Move()
        {
            while (currentState == State.Move)
            {
                yield return null;

                // 이동
                float horizontal = Input.GetAxis("Horizontal");
                float vertical = Input.GetAxis("Vertical");

                // 방향에 대한 애니메이션 설정
                refAnimator.SetFloat("Horizontal", horizontal > 0f ? 1f : horizontal < 0f ? -1f : 0f);
                refAnimator.SetFloat("Vertical", vertical > 0f ? 1f : vertical < 0f ? -1f : 0f);

                Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

                refTransform.position += direction * moveSpeed * Time.deltaTime;
            }
        }
    }

}
