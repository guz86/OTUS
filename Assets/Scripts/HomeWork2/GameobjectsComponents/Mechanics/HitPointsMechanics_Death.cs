using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public sealed class HitPointsMechanics_Death : MonoBehaviour
    {
        [SerializeField] private IntBehaviour _hitPoints;
        [SerializeField] private EventReceiver _deathReceiver;


        private void OnEnable()
        {
            this._hitPoints.OnValueChanged += OnHitPointsChanged;
        }

        private void OnDisable()
        {
            this._hitPoints.OnValueChanged -= OnHitPointsChanged;
        }

        private void OnHitPointsChanged(int newHitPoints)
        {
            if (newHitPoints <= 0)
            {
                _deathReceiver.Call();
            }
        }
    }
}