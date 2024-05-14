using UnityEngine;

namespace FPSGame
{
    // �÷��̾� ������ ��� Ŭ����
    // ������ ������-������Ʈ-���� �޼ҵ� �� ������ ����
    public class PlayerState : MonoBehaviour
    {
        protected Transform refTransform;

        protected virtual void OnEnable()
        {
            if (refTransform == null)
            {
                refTransform = transform;
            }
        }

        protected virtual void Update()
        {
            
        }

        protected virtual void OnDisable()
        {
            
        }
    }

}
