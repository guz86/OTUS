using System.Collections;
using UnityEngine;

namespace HomeWork.GameMechanics.Mechanics
{
    public class MovementMechanics : MonoBehaviour
    {
        [SerializeField] private VectorEventReceiver _moveReceiver;
        [SerializeField] private TransformEngine _transformEngine;
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

        private void OnMove(Vector3 position)
        {
            if (_coroutineMove == null) _coroutineMove = StartCoroutine(Move(position));
        }

        private IEnumerator Move(Vector3 targetPosition)
        {
            
            var startPosition =_transformEngine.GetPosition();

            var distance = (targetPosition - startPosition).magnitude;
            var duration = distance / _MovementSpeed.Value;
             
            float progress = 0;
            float currentTime = 0;

            while (progress < 1)
            {
                yield return null;
                currentTime += Time.deltaTime;
                progress = Mathf.Clamp01(currentTime / duration);

                targetPosition = new Vector3(targetPosition.x, 0f, targetPosition.z);
                
                var newPosition = Vector3.Lerp(startPosition, targetPosition, progress);
                _transformEngine.SetPosition(newPosition);

            }

            _coroutineMove = null;
        }
    }
}