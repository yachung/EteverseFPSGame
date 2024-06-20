using UnityEngine;
using UnityEngine.UI;

namespace FPSGame
{
    // 적 캐릭터가 머리에 달고다니는 HUD HPBar 스크립트
    public class EnemyHPBar : MonoBehaviour
    {
        [SerializeField] private Image HPBar;
        private Transform cameraTransform;
        private Transform refTransform;

        private void OnEnable()
        {
            if (!gameObject.activeSelf)
                gameObject.SetActive(true);

            if (cameraTransform == null)
                cameraTransform = Camera.main.transform;

            if (refTransform == null)
                refTransform = transform;
        }

        // 기능
        // 빌보드 (카메라를 항상 바라보도록 회전을 설정하는 기능)
        // - 카메라 방향.
        private void Update()
        {
            // 카메라의 앞방향과 항상 방향을 맞춤
            // refTransform.LookAt(cameraTransform.forward);
            refTransform.rotation = Quaternion.LookRotation(cameraTransform.forward);
        }

        // 체력 게이지 처리
        // - 현재 체력, 최대 체력
        // - UI Image 컴포넌트 참조
        public void OnEnemyDamaged(float currentHP, float maxHP)
        {
            if (maxHP <= 0f)
                HPBar.fillAmount = 0f;
            else
                HPBar.fillAmount = currentHP / maxHP;
        }

    }
}
