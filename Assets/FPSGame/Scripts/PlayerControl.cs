using UnityEngine;

namespace FPSGame
{
    public class PlayerControl : MonoBehaviour
    {
        // �̵��ӵ�
        [SerializeField] private float moveSpeed = 5f;

        // Ʈ������ ������Ʈ ���� ����
        private Transform refTransform;

        private void Awake()
        {
            refTransform = transform;
        }

        private void Update()
        {
            // �̵�
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            refTransform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}
