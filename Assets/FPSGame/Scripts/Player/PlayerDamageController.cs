using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace FPSGame
{
    // 플레이어의 대미지를 처리하는 스크립트
    public class PlayerDamageController : MonoBehaviour
    {
        // 플레이어 체력
        [SerializeField] private float currentHp = 0f;
        // 플레이어 데이터 컴포넌트 참조변수
        [SerializeField] private PlayerData data;
        // 플레이어가 죽을 때 발행되는 이벤트
        [SerializeField] private UnityEvent OnPlayerDead;

        // 플레이어가 대미지를 입었을 때 발생하는 이벤트
        // 두 개의 파라미터를 전달 - 현재 체력 값, 최대 체력 값
        [SerializeField] private UnityEvent<float, float> OnPlayerDamaged;

        private void OnEnable()
        {
            currentHp = data.maxHP;
        }

        // 트리거 타입의 충돌이 발생 할 때 엔진이 실행해주는 이벤트 메소드
        private void OnTriggerEnter(Collider other)
        {
            // 적 캐릭터가 발사한 탄약인지 확인.
            if (other.CompareTag("EnemyBullet"))
            {
                // 대미지 처리
                currentHp -= other.GetComponent<BulletDamage>().Damage;
                currentHp = currentHp < 0f ? 0f : currentHp;

                // 대미지 변동 이벤트 발행
                OnPlayerDamaged?.Invoke(currentHp, data.maxHP);

                // 탄약 제거
                Destroy(other.gameObject);

                // 죽음 알리기
                if (currentHp == 0f)
                    OnPlayerDead?.Invoke();
            }
        }
        
        // 외부에서 이벤트를 등록할 때 사용할 메소드
        public void SubscribeOnPlayerDead(UnityAction action)
        {
            OnPlayerDead.AddListener(action);
        }
    }
}
