using UnityEngine;

namespace HomeWork
{
    public sealed class TakeDamageObserver_PlayParticles : MonoBehaviour
    {
        [SerializeField] private IntEventReceiver _takeDamageReceiver;
        [SerializeField] private ParticleSystem _particleSystem;
        

        private void OnEnable()
        {
            _takeDamageReceiver.OnEvent += OnDamageTaken;
        }

        private void OnDisable()
        {
            _takeDamageReceiver.OnEvent -= OnDamageTaken;
        }

        private void OnDamageTaken(int damage)
        {
            _particleSystem.Play(withChildren:true);
        }
    }
}