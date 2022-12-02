using UnityEngine;

namespace HomeWork
{
    public sealed class DeathMechanics_DisableGameobject : MonoBehaviour
    {
        [SerializeField] private GameObject _target;
        [SerializeField] private EventReceiver _deathReceiver;


        private void OnEnable()
        {
            _deathReceiver.OnEvent += OnDeath;
        }

        private void OnDisable()
        {
            _deathReceiver.OnEvent -= OnDeath;
        }


        private void OnDeath()
        {
            _target.SetActive(false);
        }
    }
}