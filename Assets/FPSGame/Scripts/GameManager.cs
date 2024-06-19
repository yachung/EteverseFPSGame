using TMPro;
using UnityEngine;

namespace FPSGame
{
    public class GameManager : MonoSingleton<GameManager>
    {
        // 필드
        [SerializeField] private int score = 0;
        [SerializeField] private TextMeshProUGUI scoreText;

        private int addScoreValue = 1;

        private void Awake()
        {
            scoreText.text = $"KILL <color=red>{score:N0}</color>";
        }

        // 점수 획득 메시지
        public void AddScore()
        {
            score += addScoreValue;

            // 점수 텍스트 업데이트
            scoreText.text = $"KILL <color=red>{score:N0}</color>";
        }
    }
}
