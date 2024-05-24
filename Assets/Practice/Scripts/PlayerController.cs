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

        // ���� ����.
        [SerializeField] private State currentState = State.None;

        // ������Ʈ ������Ʈ �迭 ����.
        [SerializeField] private PlayerState[] states;

        // �ִϸ��̼� ��Ʈ�ѷ� ����.
        [SerializeField] private PlayerAnimationController animationController;

        // �Է� ���� �����ϴ� ����.
        public static float Horizontal { get; private set; } = 0f;
        public static float Vertical { get; private set; } = 0f;

        // ĳ���� ȸ���� ���.
        public static float Turn { get; private set; } = 0f;    // �¿� �巡��.
        public static float Look { get; private set; } = 0f;    // ���� �巡��.

        private void OnEnable()
        {
            // ó�� ������ ������Ʈ ����
            SetState(State.Idle);
        }

        // ���� ���� �Լ�.
        public void SetState(State newState)
        {
            // ���� ó��.
            // try-catch ( �� �� ������ ���� ������ ).
            if (currentState == newState)
            {
                return;
            }

            if (currentState != State.None)
            {
                // ���� ���� ��ũ��Ʈ ����.
                states[(int)currentState].enabled = false;
            }


            // ���ο� ���� ��ũ��Ʈ �ѱ�.
            states[(int)newState].enabled = true;

            // ���� ���� ������Ʈ.
            currentState = newState;

            // �ִϸ��̼� ����.
            animationController.SetStateParameter((int)currentState);
        }

        private void Update()
        {
            // ����Ű �Է� ����.
            Horizontal = Input.GetAxis("Horizontal");
            Vertical = Input.GetAxis("Vertical");

            // ���콺 �巡�� �� ����.
            Turn = Input.GetAxis("Mouse X");
            Look = Input.GetAxis("Mouse Y");

            // �Է��� ���� �� Ȯ��.
            if (PlayerInputManager.Horizontal == 0f
                && PlayerInputManager.Vertical == 0f)
            {
                // �Է��� ������ �⺻ ���·� ��ȯ.
                SetState(State.Idle);
            }
            else
            {
                // �̵� ���·� ��ȯ.
                SetState(State.Move);

                // �ִϸ��̼� ����.
                animationController.SetHorizontalParameter(PlayerInputManager.Horizontal);

                animationController.SetVerticalParameter(PlayerInputManager.Vertical);
            }
        }
    }
}