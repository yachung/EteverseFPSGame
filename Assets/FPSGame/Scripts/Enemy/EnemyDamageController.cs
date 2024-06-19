using UnityEngine;
using UnityEngine.Events;

namespace FPSGame
{
    /*
     * - 적 캐릭터 대미지 처리
      -> 플레이어 탄약이 캐릭터에 맞음 -> EnemyDamageController의 OnCollisionEnter 실행 -> 대미지 처리 -> 죽음 이벤트 발행 -> EnemyStateManager의 OnEnemyDead 함수 실행
     */

    // 적 캐릭터의 데미지 처리를 담당하는 스크립트
    public class EnemyDamageController : MonoBehaviour
    {
        // 총을 맞았을 때 재생할 이펙트 프리팹.
        [SerializeField] private GameObject bloodEffect;

        // 적 캐릭터 데이터 컴포넌트
        [SerializeField] private EnemyData data;

        // 적 캐릭터가 죽을 때 발행하는 이벤트
        [SerializeField] private UnityEvent OnEnemyDead;

        // 충돌이 발생했을 때 비교할 탄약 태그 값
        private const string bulletTag = "Bullet";

        // 체력
        private float hp = 0f;

        // 이펙트 재생 시간
        private float effectDuration = 0f;

        private void OnEnable()
        {
            hp = data.MaxHP;
            effectDuration = bloodEffect.GetComponent<ParticleSystem>().main.duration;
        }

        // 다른 물체와 Collision 방식으로 충돌을 시작할 때 유니티 엔진이 호출해주는 이벤트 함수
        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.collider.CompareTag(bulletTag))
                return;

            // 피격 효과 재생
            PlayBloodEffect(collision);

            // 대미지 처리(체력감소)
            hp -= collision.gameObject.GetComponent<BulletDamage>().Damage;

            hp = hp < 0f ? 0f : hp;

            // 탄약 제거
            Destroy(collision.gameObject);

            // 죽음판단
            if (hp == 0f)
            {
                OnEnemyDead?.Invoke();
                // 점수 획득
                GameManager.Instance.AddScore();
            }
        }

        private void PlayBloodEffect(Collision collision)
        {
            // 맞은 위치 지점 구하기
            Vector3 position = collision.contacts[0].point;

            // 맞은 위치의 노멀(법선) 구하기
            Vector3 normal = collision.contacts[0].normal;

            // 노멀을 기준으로 적절한 회전 구하기
            Quaternion rotation = Quaternion.LookRotation(normal);

            // 위치/ 회전을 사용해서 프리팹 생성
            GameObject objEffect = Instantiate(bloodEffect, position, rotation);

            objEffect.transform.SetParent(transform);
                
            // 재생 후 프리팹 제거
            Destroy(objEffect, effectDuration);
        }
    }
}
