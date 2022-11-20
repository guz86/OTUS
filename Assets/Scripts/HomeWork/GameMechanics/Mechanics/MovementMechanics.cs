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

            // если позиция не меняется
            if (targetPosition - startPosition == Vector3.zero) yield return null;
            
            float progress = 0;
            float currentTime = 0;
            var distance = (targetPosition - startPosition).magnitude;

            while (progress < 1)
            {
                yield return null;
                currentTime += Time.deltaTime;
                progress = currentTime * _MovementSpeed.Value / distance;
                var targetX = targetPosition.x - startPosition.x;
                var targetZ = targetPosition.z - startPosition.z;
                var target = new Vector3((targetX) * progress, 0f, (targetZ) * progress);

                _visualObject.transform.position = target + startPosition;
                
            }

            _coroutineMove = null;
        }
    }
}