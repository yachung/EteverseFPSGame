using UnityEngine;

namespace FPSGame
{
    // Scriptable Object�� ������ �÷��̾� ������.
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Create PlayerData")]
    public class PlayerData : ScriptableObject
    {
        // �����ͷ� ���Ϸ� ������ �÷��̾� ������
        public float moveSpeed = 3f;            // �̵� �ӵ�.
        public float rotationSpeed = 540f;      // ȸ�� �ӵ�.
        public float maxHP = 100f;              // ü��(Health Power).
        public int maxAmmo = 20;                // źâ�� ä�� 
    }
}
