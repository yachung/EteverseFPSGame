using UnityEngine;

namespace FPSGame
{
    public class PlayerAnimationController : MonoBehaviour
    {
        // Animator 컴포넌트
        [SerializeField] private Animator animator;

        // State 값 설정 함수
        public void SetStateParameter(int state)
        {
            animator.SetInteger("State", state);
        }

        public void SetHorizontalParameter(float horizontal)
        {
            horizontal = horizontal > 0f ? 1f : horizontal < 0f ? -1f : 0f;
            animator.SetFloat("Horizontal", horizontal);
        }

        public void SetVerticalParameter(float vertical)
        {
            vertical = vertical > 0f ? 1f : vertical < 0f ? -1f : 0f;
            animator.SetFloat("Vertical", vertical);
        }
    }
}