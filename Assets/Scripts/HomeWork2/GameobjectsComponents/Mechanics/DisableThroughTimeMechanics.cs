using System.Collections;
using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public class DisableThroughTimeMechanics : MonoBehaviour
    {
        private Coroutine _coroutine;

        private void OnEnable()
        {
            _coroutine = StartCoroutine(Routine());
        }

        private void OnDisable()
        {
            StopCoroutine(_coroutine);
        }

        private IEnumerator Routine()
        {
            yield return new WaitForSeconds(3f);
            gameObject.SetActive(false);
        }
    }
}