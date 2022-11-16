using System.Collections;
using UnityEngine;

namespace HomeWork.GameMechanics.Mechanics
{
    public class JumpMechanics : MonoBehaviour
    {
        [SerializeField] private EventReceiver _eventReceiver;
        [SerializeField] private GameObject _visualObject;
        [SerializeField] private AnimationCurve _yAnimation;
        [SerializeField] private float _height = 5f;
        [SerializeField] private float duration = 1f;

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

        private IEnumerator JumpRoutine()
        {
            var position = _visualObject.transform.position;
            var startPosition = new Vector3(position.x, 0.5f , position.z);
            float progress = 0;
            float time = 0;

            while (progress < 1)
            {
                time += Time.deltaTime;
                progress = time / duration;
                _visualObject.transform.position = new Vector3(0,_yAnimation.Evaluate(progress) * _height,0) + startPosition;
                yield return null;
            }
            
            _coroutineJump = null;
        }
        
        
    }
}