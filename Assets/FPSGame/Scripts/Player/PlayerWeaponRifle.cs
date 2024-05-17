using UnityEngine;

namespace FPSGame
{
    public class PlayerWeaponRifle : PlayerWeapon
    {
        // ź�� �߻縦 ���� ����.
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform muzzleTransform;

        // �߻��� �� �Ҹ� ����� ���� ����.
        [SerializeField] private AudioSource audioPlayer;
        [SerializeField] private AudioClip fireSound;

        public override void Fire()
        {
            base.Fire();

            // ź�� ���� ������Ʈ ����.
            Instantiate(bulletPrefab, muzzleTransform.position, muzzleTransform.rotation);

            // �߻� �Ҹ� ���.
            // �ѹ� ���.
            audioPlayer.PlayOneShot(fireSound);
        }
    }
}