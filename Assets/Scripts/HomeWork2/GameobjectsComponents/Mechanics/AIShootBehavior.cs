using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public class AIShootBehavior : MonoBehaviour
    {
        [SerializeField] private Entity _unit;
        [SerializeField] private TimerBehavior _timer;
        private IAttackComponent _attackComponent;


        private void Start()
        {
            _timer.Play();
            _attackComponent = _unit.Get<IAttackComponent>();
        }

        private void Update()
        {
            if (!_timer.IsPlaying)
            {
                _timer.ResetTime();
                _timer.Play();
                _attackComponent.Attack();
            }
        }
    }
}