using UnityEngine;

namespace FPSGame
{
    // �� ĳ������ ���� ��迡 ����� ���� ��ũ��Ʈ�� ��� Ŭ����
    public class EnemyState : MonoBehaviour
    {
        // �ʵ�
        // ���� ������ ��ũ��Ʈ ���� ����
        protected EnemyStateManager manager;

        // �� ĳ���� ������ ���� ����.
        // ������ �� ���� ��������� �� -> ���� �����ڿ��� ������ ��
        protected EnemyData data;

        // Ʈ������ ���� ����
        protected Transform refTransform;

        // ������ ���� �Լ�
        public void SetData(EnemyData data)
        {
            this.data = data;
        }

        // ���±�迡�� �䱸�ϴ� ���� ����
        // ������Ʈ. ������ - ������Ʈ - ����

        // ������
        protected virtual void OnEnable()
        {
            // ���� ���� �ʱ�ȭ
            if (manager == null)
                manager = GetComponent<EnemyStateManager>();

            if (refTransform == null)
                refTransform = transform;
        }

        // ������Ʈ
        protected virtual void Update()
        {
            
        }

        // ����
        protected virtual void OnDisable()
        {
            
        }
    }
}
