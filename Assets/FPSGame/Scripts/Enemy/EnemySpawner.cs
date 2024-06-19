using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace FPSGame
{
    // 적 캐릭터를 생성하는 시스템
    public class EnemySpawner : MonoBehaviour
    {
        // 필드
        // 생성 지점(위치)
        [SerializeField] private Transform spawnGroup;
        [SerializeField] private List<Transform> spawnPoints;

        // 적 캐릭터 프리팹
        [SerializeField] private GameObject enemyPrefab;

        // 생성 간격
        [SerializeField] private float spawnDelay = 3f;

        // 윌드에 한번에 배치가 가능한 적 캐릭터의 최대 수 (제한 값)
        [SerializeField] private int maxSpawnEnemy = 10;

        // 기타
        private bool isPlayerDead = false;

        private WaitForSeconds waitDelay;

        private Coroutine coSpawnEnemy = null;

        // 초기화
        private void OnEnable()
        {
            if (spawnGroup != null)
            {
                // spawnGroup 하위에 있는 transform 컴포넌트를 리스트에 저장
                spawnGroup.GetComponentsInChildren<Transform>(spawnPoints);
                spawnPoints.RemoveAt(0);
            }

            var playerDamagedController = FindFirstObjectByType<PlayerDamageController>();
            if (playerDamagedController != null)
                playerDamagedController.SubscribeOnPlayerDead(OnPlayerDead);

            if (waitDelay == null)
                waitDelay = new WaitForSeconds(spawnDelay);

            if (coSpawnEnemy != null)
                StopCoroutine(coSpawnEnemy);

            coSpawnEnemy = StartCoroutine(SpawnEnemy());
        }

        // 이벤트 리스너 메소드
        private void OnPlayerDead()
        {
            isPlayerDead = true;
        }

        // 생성 메소드
        private IEnumerator SpawnEnemy()
        {
            while (isPlayerDead == false)
            {
                // 현재 맵에 배치된 적의 수 확인
                int EnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
                
                yield return new WaitUntil(() => (EnemyCount < maxSpawnEnemy));

                // 일정 시간 대기
                yield return waitDelay;

                // 생성
                int index = Random.Range(0, spawnPoints.Count);
                Instantiate(enemyPrefab, spawnPoints[index].position, Quaternion.identity);
            }
        }
    }
}
