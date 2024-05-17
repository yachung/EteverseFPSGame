using UnityEngine;
using UnityEngine.UI;

namespace FPSGame
{
    // �÷��̾��� �߻� ������ �����ϴ� ��ũ��Ʈ.
    public class PlayerWeaponAimController : MonoBehaviour
    {
        // �߻� ��ġ.
        [SerializeField] private Transform muzzleTransform;

        // ���� ��ġ.
        [SerializeField] private Image aimTarget;

        // ���� ���⿡ ��ü�� ���� �� ������ ����.
        [SerializeField] private Color targetDetectedColor = Color.red;

        // ���� ���⿡ ��ü�� ���� �� ������ ����.
        [SerializeField] private Color targetUndetectecColor = Color.white;

        // RayCast�� ������ �� ī�޶� ����ϱ� ������ �̸� �����ϱ� ���� ���� ����.
        private Camera mainCamera;

        void Awake()
        {
            // ���� ī�޶� ����.
            if (mainCamera == null)
            {
                mainCamera = Camera.main;
            }
        }

        void Update()
        {
            // UI ��ġ���� ī�޶� �������� �����ϴ� Raycast ����.
            Ray ray = mainCamera.ScreenPointToRay(aimTarget.transform.position);

            // ������ Ray�� �߻�(Raycast).
            if (Physics.Raycast(ray, out RaycastHit hit, 10000f))
            {
                // ���ص� ��ü�� ���� ��, ���� �������� ����.
                aimTarget.color = targetDetectedColor;

                // Ray�� �ε��� ��ü�� ������, �ε��� ��ü�� ��ġ�� ���ϵ��� �߻� ���� ����.
                muzzleTransform.rotation 
                    = Quaternion.LookRotation(hit.point - muzzleTransform.position);
            }
            else
            {
                // ���ص� ��ü�� ������, ���� �������� ����.
                aimTarget.color = targetUndetectecColor;

                // Ray�� �ε��� ��ü�� ������, Ray ������ ���ϵ��� �߻� ���� ����.
                muzzleTransform.rotation = Quaternion.LookRotation(ray.direction);
            }
        }
    }
}