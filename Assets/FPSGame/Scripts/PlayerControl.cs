using Unity.VisualScripting;
using UnityEngine;

namespace FPSGame
{
    public class PlayerControl : MonoBehaviour
    {
        public enum States
        {
            Idle = 0,
            Move
        }

        // �÷��̾��� ���¸� ��Ÿ���� ����
        [SerializeField] private States currentState = States.Idle;

        // �̵��ӵ�
        [SerializeField] private float moveSpeed = 5f;

        // Animator ������Ʈ ����
        [SerializeField] private Animator refAnimator;

        // Ʈ������ ������Ʈ ���� ����
        private Transform refTransform;

        private void Awake()
        {
            refTransform = transform;

            refAnimator = GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            // �̵�
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            // ���⿡ ���� �ִϸ��̼� ����
            refAnimator.SetFloat("Horizontal", horizontal > 0f ? 1f : horizontal < 0f ? -1f : 0f);
            refAnimator.SetFloat("Vertical", vertical > 0f ? 1f : vertical < 0f ? -1f : 0f);

            // �ִϸ��̼� ����
            if (horizontal == 0f && vertical == 0f) currentState = States.Idle;
            else currentState = States.Move;

            refAnimator.SetInteger("State", (int)currentState);

            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            refTransform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}
