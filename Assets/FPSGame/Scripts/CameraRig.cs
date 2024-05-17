using UnityEngine;

namespace FPSGame
{
    public class CameraRig : MonoBehaviour
    {
        // ī�޶� ����ٴ� ���.
        [SerializeField] private Transform target;

        // �̵��� �� ������ ����(������, Delay) ��.
        [SerializeField] private float damping = 5f;

        // ȸ���� �� ������ ����(������, Delay) ��.
        [SerializeField] private float rotationDamping = 5f;

        private Transform refTransform;

        private void Awake()
        {
            refTransform = transform;

            // Ŀ�� ��.
            Cursor.lockState = CursorLockMode.Locked;
        }

        // �� ������ �����. Update ���� ���� ������ ����.
        private void LateUpdate()
        {
            // Lerp.
            refTransform.position = Vector3.Lerp(
                refTransform.position,
                target.position,
                damping * Time.deltaTime
            );

            // ȸ�� (Lerp).
            //Quaternion.Lerp
            //Quaternion.Slerp
            refTransform.rotation = Quaternion.Lerp(
                refTransform.rotation,
                target.rotation,
                rotationDamping * Time.deltaTime
            );
        }
    }
}