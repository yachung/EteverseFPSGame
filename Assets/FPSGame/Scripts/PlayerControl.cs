using UnityEngine;

namespace FPSGame
{
    public class PlayerControl : MonoBehaviour
    {
        // 이동속도
        [SerializeField] private float moveSpeed = 5f;

        // 트랜스폼 컴포넌트 참조 변수
        private Transform refTransform;

        private void Awake()
        {
            refTransform = transform;
        }

        private void Update()
        {
            // 이동
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            refTransform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}
