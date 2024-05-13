using UnityEngine;

// Todo: ��ñ��ñ�
namespace FPSGame
{
    public class CameraRig : MonoBehaviour
    {
        // Todo: �÷��̾ ����ٴϴ� ī�޶� ��� �߰�.

        // ī�޶� ����ٴ� ���.
        [SerializeField] private Transform target;

        // �̵��� �� ������ ������.
        [SerializeField] private float damping = 5f;

        private Transform refTransform;

        private void Awake()
        {
            refTransform = transform;
        }

        // �� ������ Update �ڿ� ���� ��.
        private void LateUpdate()
        {
            // Lerp
            refTransform.position = Vector3.Lerp(
                refTransform.position,
                target.position,
                damping * Time.deltaTime
                );
        }
        /*
         * �÷��̾ ����ٴϸ� ���� ���� ����� ������ �������
         */
    }
}
