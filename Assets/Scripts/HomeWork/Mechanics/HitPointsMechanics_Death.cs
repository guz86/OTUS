using UnityEngine;

namespace HomeWork
{
    public sealed class HitPointsMechanics_Death : MonoBehaviour
    {
        [SerializeField] private HitPointsEngine _hitPoints;
        [SerializeField] private EventReceiver _deathReceiver;


        private void OnEnable()
        {
            this._hitPoints.OnHitPointsEmpty += OnHitPointsChanged;
        }

        private void OnDisable()
        {
            this._hitPoints.OnHitPointsEmpty -= OnHitPointsChanged;
        }

        private void OnHitPointsChanged()
        {
            _deathReceiver.Call();
        }
    }
}