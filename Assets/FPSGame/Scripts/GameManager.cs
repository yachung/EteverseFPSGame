using UnityEngine;

namespace FPSGame
{
    public class GameManager : MonoSingleton<GameManager>
    {
        // 필드
        [SerializeField] private int score = 0;

        private int addScoreValue = 1;

        // 점수 획득 메시지
        public void AddScore()
        {
            score += addScoreValue;
        }
    }
}
