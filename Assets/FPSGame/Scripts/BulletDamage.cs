using UnityEngine;

namespace FPSGame
{
    // 탄약의 대미지 정보를 가지는 스크립트
    public class BulletDamage : MonoBehaviour
    {
        [SerializeField] private float damage = 30f;

        public float Damage
        {
            get
            {
                return damage;
            }
        }
    }
}
