using UnityEngine;

namespace FPSGame
{
    public class PlayerControl : MonoBehaviour
    {
        // �̵��ӵ�
        [SerializeField] private float moveSpeed = 5f;

        // Animator ������Ʈ ����
        [SerializeField] private Animator refAnimator;

        // Ʈ������ ������Ʈ ���� ����
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
            // �̵�
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            // �ִϸ��̼� ����
            if (horizontal != 0f || vertical != 0f) refAnimator.SetInteger("State", (int)State.RunF);
            else refAnimator.SetInteger("State", (int)State.Idle);

            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            refTransform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}
