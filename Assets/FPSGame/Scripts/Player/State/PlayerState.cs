using UnityEngine;

namespace FPSGame
{
    // �÷��̾� ����(������Ʈ)�� ��� Ŭ����.
    // ������ ������-������Ʈ-���� �޼ҵ� �� ���� ��� ����.
    public class PlayerState : MonoBehaviour
    {
        // Ʈ������ ���� ����.
        protected Transform refTransform;

        // ĳ���� ��Ʈ�ѷ� ������Ʈ ���� ����.
        [SerializeField] protected CharacterController characterController;

        // ȸ�� �ӵ�.
        [SerializeField] protected float rotationSpeed = 540f;

        // ���� ���� �Լ�.
        protected virtual void OnEnable()
        {
            // Ʈ������ ������Ʈ �ʱ�ȭ.
            if (refTransform == null)
            {
                refTransform = transform;
            }

            // ������Ʈ �ʱ�ȭ.
            if (characterController == null)
            {
                characterController = GetComponent<CharacterController>();
            }
        }

        // ���� ������Ʈ �Լ�.
        protected virtual void Update()
        {
            // ĳ������ �߷� ����.
            Vector3 gravity = new Vector3(0f, -9.8f, 0f);           
            characterController.Move(gravity * Time.deltaTime);

            // �¿� ĳ���� ȸ�� ó��.
            Vector3 rotation = new Vector3(
                0f, 
                PlayerInputManager.Turn * rotationSpeed * Time.deltaTime,
                0f
            );

            // ȸ�� ����.
            refTransform.Rotate(rotation);
        }

        // ���� ���� �Լ�.
        protected virtual void OnDisable()
        {
            
        }
    }
}