using System;
using UnityEngine;

namespace FPSGame
{
    public class CameraRig : MonoBehaviour
    {
        [Header("�÷��̾� ����ٴϴ� ���")]
        // ī�޶� ����ٴ� ���.
        [SerializeField] private Transform target;

        // �̵��� �� ������ ����(������, Delay) ��.
        [SerializeField] private float damping = 5f;

        // ȸ���� �� ������ ����(������, Delay) ��.
        [SerializeField] private float rotationDamping = 5f;

        private Transform refTransform;
        
        [Header("ī�޶� ���� �巡��")]
        // ���� ȸ���� ����ϴ� ����
        [SerializeField] private Transform cameraTransform;     // ���� ī�޶� Ʈ������
        [SerializeField] private float minAngle = -30f;         // ���� ȸ�� �ּ� ���� ��
        [SerializeField] private float maxAngle = 40f;          // ���� ȸ�� �ִ� ���� ��
        [SerializeField] private float xRotation = 0f;          // ī�޶��� x�� ���� ȸ���� ���

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

            // ���� ȸ�� ó�� �Լ� ȣ��
            Look();
        }

        // ���� ȸ���� ó���ϴ� �Լ�.
        private void Look()
        {
            // ī�޶� X ȸ���� ���� �Ʒ��� �����ϱ�.
            // ī�޶� Ʈ������ | ���콺 �巡�� ��(Y)

            // ���콺 ��/�Ʒ� �巡�� ���� -1���� 1������ ������ ����.
            float mouseY = Mathf.Clamp(PlayerInputManager.Look, -1f, 1f);

            // ���콺 �巡�� ������ X�� ȸ�� ����
            xRotation -= mouseY;

            // ȸ�� �� ����.
            xRotation = Mathf.Clamp(xRotation, minAngle, maxAngle);

            // ī�޶��� ���Ϸ� ȸ�� �� ��������
            Vector3 targetRotation = cameraTransform.localRotation.eulerAngles;
            targetRotation.x = xRotation;

            // ���Ϸ� ȸ���� ���ʹϾ����� ��ȯ�� �Ŀ� ī�޶� ���� ȸ���� ����
            cameraTransform.localRotation = Quaternion.Euler(targetRotation);
        }

        // ī�޶��� X�� ȸ�� ���� ��ȯ�ϴ� �Լ�
        public float GetXRotation()
        {
            return xRotation;
        }
    }
}