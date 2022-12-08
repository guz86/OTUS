using Elementary;
using UnityEngine;

namespace HomeWork
{
    public class CheckCharacterFallsController : MonoBehaviour
    {
        
        [SerializeField] private GameContext _gameContext;
        [SerializeField] private EventReceiver_Trigger _fallCheckTrigger;
        [SerializeField] private string _playerTag = "Player";
        
        private void OnEnable()
        {
            _fallCheckTrigger.OnTriggerEntered += CharacterFalls;
        }

        private void OnDisable()
        {
            _fallCheckTrigger.OnTriggerEntered -= CharacterFalls;
        }

        private void CharacterFalls(Collider obj)
        {
            if (obj.CompareTag(_playerTag))
            {
                _gameContext.FinishGame();
            }
        }
    }
}