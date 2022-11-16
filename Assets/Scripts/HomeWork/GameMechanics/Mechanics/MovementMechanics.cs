using System.Collections;
using UnityEngine;

namespace HomeWork.GameMechanics.Mechanics
{
    public class MovementMechanics : MonoBehaviour
    {
        [SerializeField] private VectorEventReceiver _moveReceiver;
        [SerializeField] private GameObject _visualObject;
        [SerializeField] private float _speed; //15f
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
            var startPosition = _visualObject.transform.position;

            float progress = 0;
            float time = 0;
            var distance = (startPosition - targetPosition).magnitude;

            while (progress < 1)
            {
                time += Time.deltaTime;
                progress = time / distance * _speed;
                var targetX = targetPosition.x - startPosition.x;
                var targetZ = targetPosition.z - startPosition.z;
                var target = new Vector3((targetX) * progress, 0f, (targetZ) * progress);

                _visualObject.transform.position = target + startPosition;
                yield return null;
            }

            _coroutineMove = null;
        }
    }
}