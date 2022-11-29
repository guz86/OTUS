using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public class AIShootBehavior : MonoBehaviour
    {
        [SerializeField] private Entity _unit;
        [SerializeField] private TimerBehavior _timer;
        private IAttackBulletComponent _attackBulletComponent;


        private void Start()
        {
            _timer.Play();
            _attackBulletComponent = _unit.Get<IAttackBulletComponent>();
        }

        private void Update()
        {
            if (!_timer.IsPlaying)
            {
                _timer.ResetTime();
                _timer.Play();
                _attackBulletComponent.Attack();
            }
        }
    }
}