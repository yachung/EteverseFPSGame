using System.Collections;
using UnityEngine;

namespace FPSGame
{
    public class CoroutineTest : MonoBehaviour
    {
        private void Awake()
        {
            StartCoroutine(TestFunction());
        }

        // 코루틴 함수 선언
        private IEnumerator TestFunction()
        {
            yield return new WaitForSeconds(1f);

            Debug.Log("1");

            yield return new WaitForSeconds(1f);
            
            Debug.Log("2");
            yield return new WaitForSeconds(1f);
            Debug.Log("3");
        }
    }
}