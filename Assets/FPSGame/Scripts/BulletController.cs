using UnityEngine;

namespace FPSGame
{
    // �÷��̾ �߻��ϴ� ź���� �����ϴ� ��ũ��Ʈ.
    public class BulletController : MonoBehaviour
    {
        // �浹�� ������ ������ ��Į(Decal) ȿ��.
        [SerializeField] private GameObject collisionDecal;

        private void OnCollisionEnter(Collision collision)
        {
            // �浹�� ��ü�� ���̾ Ȯ��. Wall�̸� ź�� ǥ��.
            //if (collision.gameObject.layer == (1 << 6))

            Debug.Log($"OnCollisionEnter: {collision.gameObject.layer}");

            if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                // �浹 ���� �޾ƿ���.
                ContactPoint contact = collision.contacts[0];

                // ��Į�� ����� �����ֱ� ���� ȸ�� ����.
                Quaternion rotation = Quaternion.LookRotation(contact.normal);

                // ��Į ���� ������Ʈ ����.
                // Instantiate: ���� ������Ʈ�� ��Ÿ�ӿ� ������ �� ���.
                Instantiate(collisionDecal, contact.point, rotation);
            }

            // �� ���� ������Ʈ(ź��)�� ����.
            Destroy(gameObject);
        }
    }
}