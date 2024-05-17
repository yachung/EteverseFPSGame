using UnityEngine;

namespace FPSGame
{
    public class PlayerControl : MonoBehaviour
    {
        // ������.
        public enum State
        {
            Idle, 
            Move
        }

        // �÷��̾��� ���¸� ��Ÿ���� ����.
        [SerializeField] private State currentState = State.Idle;

        // �̵� �ӵ�.
        [SerializeField] private float moveSpeed = 5f;

        // Animator ������Ʈ ����.
        [SerializeField] private Animator refAnimator;
        
        // Ʈ������ ������Ʈ ���� ����.
        private Transform refTransform;

        private void Awake()
        {
            // Ʈ������ ���� ����.
            refTransform = transform;

            // ���� ����.
            refAnimator = GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            // ����Ű �Է� �ޱ�.
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            // ���⿡ ���� �ִϸ��̼� ����.
            //refAnimator.SetFloat("Horizontal", horizontal);
            //refAnimator.SetFloat("Vertical", vertical);
            refAnimator.SetFloat("Horizontal", horizontal > 0f ? 1f : horizontal < 0f ? -1f : 0f);
            refAnimator.SetFloat("Vertical", vertical > 0f ? 1f : vertical < 0f ? -1f : 0f);

            // �ִϸ��̼� ����.
            if (horizontal == 0f && vertical == 0f)
            {
                // ���� ����.
                currentState = State.Idle;

                //// �Է��� ����.
                //refAnimator.SetInteger("State", (int)currentState);
            }
            else
            {
                // ���� ����.
                currentState = State.Move;

                //// �Է��� ����.
                //refAnimator.SetInteger("State", (int)currentState);
            }

            // �Է��� ����.
            refAnimator.SetInteger("State", (int)currentState);

            // �̵�.
            refTransform.position += 
                new Vector3(horizontal, 0f, vertical).normalized 
                * moveSpeed 
                * Time.deltaTime;
        }
    }
}