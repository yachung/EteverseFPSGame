using UnityEngine;

namespace FPSGame
{
    // �ۼ���: �弼��(2024.05.16).
    // �÷��̾��� ���⸦ �����ϴ� ��ũ��Ʈ.
    public class PlayerWeaponController : MonoBehaviour
    {
        // ���⸦ ������ �� ����� ���� ��ġ (Ʈ������).
        [SerializeField] private Transform weaponHolder;

        // ������ ����.
        [SerializeField] private PlayerWeapon weapon;

        private void Awake()
        {
            // ���� ����.
            weapon.LoadWeapon(weaponHolder);
        }

        private void Update()
        {
            // �Է� Ȯ�� �� �߻�.
            if (PlayerInputManager.IsFire)
            {
                // �߻� ��� ����.
                weapon.Fire();
            }
        }
    }
}