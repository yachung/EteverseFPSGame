using System.Collections;
using UnityEngine;
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

        // 피격 효과를 위한 UI 참조변수
        [SerializeField] private Image bloodEffect;
        private WaitForSeconds effectWait;
        private Coroutine coShowBloodEffect;

        private void OnEnable()
        {
            currentHp = data.maxHP;

            if (effectWait == null )
                effectWait = new WaitForSeconds(0.2f);

            coShowBloodEffect = null;
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

                // 탄약 제거
                Destroy(other.gameObject);

                // 죽음 알리기
                if (currentHp == 0f)
                {
                    // Todo: 이벤트 발행
                }

                // 피격 효과 재생 (UI로 피격 효과).
                StartCoroutine(ShowBloodEffect());
            }
        }

        // 피격효과 재생 코루틴
        private IEnumerator ShowBloodEffect()
        {
            bloodEffect.color = new Color(Random.Range(0.7f, 0.9f), 0f, 0f, Random.Range(0.2f, 0.4f));

            yield return effectWait;

            bloodEffect.color = Color.clear;
        }
    }
}
