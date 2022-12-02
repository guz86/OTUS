using UnityEngine;

namespace HomeWork
{
    public sealed class GameContextInstaller : MonoBehaviour
    {
        [SerializeField] private GameContext _context;

        [SerializeField] private MonoBehaviour[] _listeners;

        private void Awake()
        {
            foreach (var listener in _listeners)
            {
                _context.AddListener(listener);
            }
        }
    }
}