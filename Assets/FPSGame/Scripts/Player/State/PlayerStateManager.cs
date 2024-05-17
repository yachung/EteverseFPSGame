using UnityEngine;

namespace FPSGame
{
    // �ۼ���: �弼��(2024.05.14).
    // �÷��̾��� ����(������Ʈ)�� �����ϴ� ������ ��ũ��Ʈ.
    public class PlayerStateManager : MonoBehaviour
    {
        // �÷��̾��� ���¸� ��Ÿ���� ������ ����.
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

        // �÷��̾� ������
        [SerializeField] private PlayerData data;

        private void OnEnable()
        {
            // ó�� ������ ������Ʈ ����
            SetState(State.Idle);

            // �� ������Ʈ�� ������ ����
            foreach (PlayerState state in states)
            {
                state.SetData(data);
            }
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