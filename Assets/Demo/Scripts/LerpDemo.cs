using UnityEngine;

namespace Demo
{
    public class LerpDemo : MonoBehaviour
    {
        [SerializeField] private Transform start;
        [SerializeField] private Transform end;
        [Range(0f, 1f), SerializeField] private float alpha = 0f;
        [SerializeField] private float animationTime = 1f;

        private Transform refTransform;
        private float direction = 1f;

        private void Awake()
        {
            refTransform = transform;
        }

        private void Update()
        {
            alpha += Time.deltaTime * direction;
            if (direction > 0f && alpha >= animationTime)
            {
                direction *= -1f;
            }
            if (direction < 0f && alpha <= 0f)
            {
                direction *= -1f;
            }

            refTransform.position = Vector3.Lerp(
                start.position,
                end.position,
                alpha / animationTime
            );
        }
    }
}