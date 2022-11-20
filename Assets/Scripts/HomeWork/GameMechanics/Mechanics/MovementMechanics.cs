using System.Collections;
using UnityEngine;

namespace HomeWork.GameMechanics.Mechanics
{
    public class MovementMechanics : MonoBehaviour
    {
        [SerializeField] private VectorEventReceiver _moveReceiver;
        [SerializeField] private GameObject _visualObject;
        [SerializeField] private IntBehaviour _MovementSpeed; //15f
        private Coroutine _coroutineMove;

        private void OnEnable()
        {
            _moveReceiver.OnEvent += OnMove;
        }

        private void OnDisable()
        {
            _moveReceiver.OnEvent -= OnMove;
        }

        public void OnMove(Vector3 position)
        {
            if (_coroutineMove == null) _coroutineMove = StartCoroutine(Move(position));
        }

        private IEnumerator Move(Vector3 targetPosition)
        {
            
            var startPosition = _visualObject.transform.position;

            var distance = (targetPosition - startPosition).magnitude;
            var duration = distance / _MovementSpeed.Value;
             
            float progress = 0;
            float currentTime = 0;

            while (progress < 1)
            {
                yield return null;
                currentTime += Time.deltaTime;
                progress = Mathf.Clamp01(currentTime / duration);

                targetPosition = new Vector3(targetPosition.x, 0.5f, targetPosition.z);
                
                _visualObject.transform.position = Vector3.Lerp(startPosition, targetPosition, progress);
                

            }

            _coroutineMove = null;
        }
    }
}