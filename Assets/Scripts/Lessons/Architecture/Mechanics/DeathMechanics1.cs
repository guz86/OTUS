using UnityEngine;

namespace Lessons.Architecture.Mechanics
{
    public sealed class DeathMechanics1 : MonoBehaviour
    {
        [SerializeField] private IntBehaviour1 _hitPoints;
        [SerializeField] private EventReceiver1 deathReceiver1;

        private void OnEnable()
        {
            this._hitPoints.OnValueChanged += this.OnHitPointsChanged;
        }

        private void OnDisable()
        {
            this._hitPoints.OnValueChanged -= this.OnHitPointsChanged;
        }

        private void OnHitPointsChanged(int newHitPoints)
        {
            if (newHitPoints <= 0)
            {
                this.deathReceiver1.Call();
            }
        }
    }
}