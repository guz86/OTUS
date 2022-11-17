using UnityEngine;

namespace HomeWork.GameMechanics.Mechanics
{
    public sealed class DeathMechanics : MonoBehaviour
    {
        [SerializeField] private IntBehaviour _hitPoints;
        [SerializeField] private EventReceiver _deathReceiver;
        [SerializeField] private GameObject _gameobject;
        

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
                this._deathReceiver.Call();
                _gameobject.SetActive(false);
            }
        }
    }
}