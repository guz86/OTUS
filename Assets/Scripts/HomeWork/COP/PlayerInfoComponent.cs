using UnityEngine;

namespace HomeWork
{
    public class PlayerInfoComponent : MonoBehaviour, IPlayerInfoComponent
    {
        [SerializeField] private PlayerInfo _player;
        
        public string GetName()
        {
            return _player.GetCharacter().title;
        }

        public string GetDescription()
        {
            return _player.GetCharacter().description;
        }
        
        public Sprite GetIcon()
        {
            return _player.GetCharacter().icon;
        }
    }
}