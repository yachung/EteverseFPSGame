using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace FPSGame
{
    // 플레이어의 HP관련 UI 처리를 담당하는 스크립트
    public class PlayerHPUIController : MonoBehaviour
    {
        // 피격 효과를 위한 UI 참조변수
        [SerializeField] private Image bloodEffect;

        [SerializeField] private Image hPBar;

        private WaitForSeconds effectWait;
        private void OnEnable()
        {
            if (effectWait == null)
                effectWait = new WaitForSeconds(0.2f);
        }

        // HP 수치가 변경 되면 호출될 이벤트 리스너 메소드
        public void OnPlayerHPChanged(float currentHP, float maxHP)
        {
            hPBar.fillAmount = currentHP / maxHP;
        }

        public void PlayBloodEffect()
        {
            StartCoroutine(ShowBloodEffect());
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
