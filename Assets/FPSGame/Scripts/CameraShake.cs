using System.Collections;
using UnityEngine;

namespace FPSGame
{
    // ī�޶� ���� ȿ�� ��ũ��Ʈ.
    public class CameraShake : MonoBehaviour
    {
        // ��� ī�޶��� Ʈ������ ������Ʈ.
        [SerializeField] private Transform targetCamera;

        // ī�޶� ��� �� ����� ��.
        [SerializeField] private float duration = 0.1f;           // ���� �ð�(�� ����).
        [SerializeField] private float oscillation = 0.02f;       // ���� ���� ����.

        // ī�޶��� ���� ��ġ.
        private Vector3 originPosition;

        void OnEnable()
        {
            // ������ �� ���� ��ġ ����.
            originPosition = targetCamera.localPosition;
        }

        // ī�޶� ���� ȿ���� ����ϴ� �Լ�.
        public void Play()
        {
            // ShakeCamera �ڷ�ƾ �Լ� ����.
            StartCoroutine("ShakeCamera");
        }

        // �ڷ�ƾ(Coroutine)���� ī�޶� ���� ȿ���� ������ �Լ�.
        IEnumerator ShakeCamera()
        {
            // ��� �ð��� ����� ���� ����.
            float elapsedTime = 0f;

            // duration ������ ������ �ð��� ���� ������ ȿ�� ���.
            while (elapsedTime < duration)
            {
                // ī�޶� ��� ��ġ�� ���� ������ ���ϱ�.
                Vector3 shakePosition = Random.insideUnitSphere;

                // ��� ������� ������ ī�޶��� ��ġ�� ������ ����.
                // ���� = ������ġ + ���� ��ġ * ���� ����;
                targetCamera.localPosition =
                    originPosition + shakePosition * oscillation;

                // ��� �ð� ������Ʈ.
                elapsedTime += Time.deltaTime;

                // �� ������ ���.
                yield return null;
            }

            // ���� ȿ���� ��� ����� �������� ī�޶� ��ġ�� ���� ��ġ�� ����.
            targetCamera.localPosition = originPosition;
        }
    }
}