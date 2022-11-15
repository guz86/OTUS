using System.Collections;
using UnityEngine;

namespace HomeWork.GameMechanics.Mechanics
{
    public class JumpMechanics : MonoBehaviour
    {
        [SerializeField] private EventReceiver _eventReceiver;
        [SerializeField] private GameObject _visualObject;
        [SerializeField] private float _velocity;
        [SerializeField] private float _jumpPower;
        [SerializeField] private bool _isJump;

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
            if (!_isJump)
            {
                StartCoroutine(JumpRoutine()); 
                _isJump = false;
            }
        }

        private IEnumerator JumpRoutine()
        {
            
            while (_jumpPower <= _velocity && !_isJump)
            {
                yield return null;
                _jumpPower += Time.deltaTime;
                _visualObject.transform.Translate(new Vector3(0, _jumpPower * 2, 0));
            }

            _jumpPower = _velocity;
            
            _isJump = true;
            
            while (_jumpPower >= 0)
            {
                yield return null;
                _jumpPower -= Time.deltaTime;

                    if (_jumpPower < 0) _jumpPower = 0;
                
                _visualObject.transform.Translate(new Vector3(0, -_jumpPower * 2, 0));
            }
            
        }
        
        
    }
}