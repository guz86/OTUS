using System.Collections;
using UnityEngine;

namespace HomeWork
{
    public class JumpMechanics_Coroutine : MonoBehaviour
    {
        [SerializeField] private EventReceiver _eventReceiver;
        [SerializeField] private GameObject _visualObject;
        [SerializeField] private AnimationCurve _yAnimation;
        [SerializeField] private IntBehaviour _jumpHeight;
        [SerializeField] private IntBehaviour _jumpDuration;

        private Coroutine _coroutineJump;
        
        private void OnEnable()
        {
            _eventReceiver.OnEvent += OnJump;
        }

        private void OnDisable()
        {
            _eventReceiver.OnEvent -= OnJump;
        }


        private void OnJump()
        {
            if (_coroutineJump == null)
            {
                _coroutineJump = StartCoroutine(JumpRoutine()); 
            }
        }

        // с rigidbody вызывает баги, проваливание
        private IEnumerator JumpRoutine()
        {
            var position = _visualObject.transform.position;
            var startPosition = new Vector3(position.x, 0f , position.z);
            float progress = 0;
            float time = 0;

            while (progress < 1)
            {
                time += Time.deltaTime;
                progress = time / _jumpDuration.Value;
                _visualObject.transform.position = new Vector3(0,_yAnimation.Evaluate(progress) * _jumpHeight.Value,0) + startPosition;
                yield return null;
            }
            
            _coroutineJump = null;
        }
        
        
    }
}