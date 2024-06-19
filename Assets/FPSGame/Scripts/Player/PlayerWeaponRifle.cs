using UnityEngine;
using UnityEngine.Events;

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

        // ������ �� �� ����� �Ҹ� ����.
        [SerializeField] private AudioClip reloadWeaponClip;

        // ź�� ���� ȿ�� ��ƼŬ
        [SerializeField] private ParticleSystem cartridgeEjectEffect;
        [SerializeField] private ParticleSystem muzzletFlashEffect;

        // ī�޶� ����
        [SerializeField] private CameraShake cameraShake;

        // �÷��̾� ������
        [SerializeField] private PlayerData data;

        // ���� ���� ź�� ��.
        [SerializeField] private int currentAmmo = 0;

        // �ִϸ��̼� ��Ʈ�ѷ�.
        [SerializeField] private PlayerAnimationController animatorController;

        // �߻� ���� (����: ��)
        [SerializeField] private float fireRate = 0.3f;

        // ������ �߻簡 ������ �ð��� ������ ����
        private float nextFireTime = 0f;

        // ������ �̺�Ʈ
        public UnityEvent OnReloadEvent;

        // ź���� ���� ���� �� �� �߻��ϴ� �̺�Ʈ
        [SerializeField] private UnityEvent<int, int> OnAmmoChanged;

        // �߻簡 �������� Ȯ���ϴ� ������Ƽ
        private bool CanFire { 
            get { return 
                    currentAmmo > 0 && 
                    Time.time > nextFireTime; 
            } 
        }

        protected override void Awake()
        {
            base.Awake();

            // ������ �� ź�� ���� ä���.
            currentAmmo = data.maxAmmo;

            OnAmmoChanged?.Invoke(currentAmmo, data.maxAmmo);
        }

        public override void Fire()
        {
            base.Fire();

            // �߻簡 �������� ������ �Լ� ����.
            if (!CanFire)
                return;

            // ������ �߻簡 ������ �ð� ����.
            nextFireTime = Time.time + fireRate;

            // ź�� ���� ���� ó��.
            --currentAmmo;

            OnAmmoChanged?.Invoke(currentAmmo, data.maxAmmo);

            // ź�� ���� ������Ʈ ����.
            Instantiate(bulletPrefab, muzzleTransform.position, muzzleTransform.rotation);

            // �߻� �Ҹ� ���.
            // �ѹ� ���.
            audioPlayer.PlayOneShot(fireSound);

            // ź�� ���� ȿ�� ���
            cartridgeEjectEffect.Play();

            // �ѱ� ȭ�� ȿ�� ���
            muzzletFlashEffect.Play();

            // ī�޶� ����
            cameraShake.Play();
        
            // �������� �ʿ����� Ȯ��
            if (currentAmmo == 0)
            {
                // ������ ó��.

                // ������ �Ҹ� ���
                audioPlayer.PlayOneShot(reloadWeaponClip);

                // ������ �ִϸ��̼� ���.
                //animatorController.OnReload();
                // ������ �̺�Ʈ ����
                OnReloadEvent?.Invoke();

                // ������ �ִϸ��̼� �ð� ��ŭ ��� �� Reload �Լ� ����
                Invoke("Reload", animatorController.WaitTimeToReload());
            }
        }

        // ������ �Լ�.
        public void Reload()
        {
            // ź�� ä���.
            currentAmmo = data.maxAmmo;

            OnAmmoChanged?.Invoke(currentAmmo, data.maxAmmo);
        }
    }
}