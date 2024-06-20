using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FPSGame
{
    // Start 씬에서 Game씬을 로드하는 스크립트
    public class SceneLoader : MonoBehaviour
    {
        // 로드할 씬의 인덱스 값
        [SerializeField] private int sceneIndexToLoad;
        [SerializeField] private Image progressBar;
        [SerializeField] private float waitTimeToStart = 3f;

        private AsyncOperation asyncOperation;
        private float elapsedTime = 0f;

        private void OnEnable()
        {
            // 씬을 로드 ( 동기 방식)
            // SceneManager.LoadScene(sceneIndexToLoad);
            // 비동기 방식
            progressBar.fillAmount = 0f;

            StartCoroutine(LoadScene());
        }

        private void Update()
        {
            // 씬 로드가 완료되지 않았다면, 진행률을 확인
            if (asyncOperation != null && asyncOperation.progress >= 0.9f)
            {
                elapsedTime += Time.deltaTime;

                progressBar.fillAmount = elapsedTime / waitTimeToStart;

                if (elapsedTime > waitTimeToStart)
                    asyncOperation.allowSceneActivation = true;
            }
        }

        private IEnumerator LoadScene()
        {
            yield return new WaitForSeconds(1f);

            asyncOperation = SceneManager.LoadSceneAsync(sceneIndexToLoad);

            // 씬을 로드했을 때 곧바로 활성화 할 지 여부를 지정하는 속성
            asyncOperation.allowSceneActivation = false;
        }
    }
}
