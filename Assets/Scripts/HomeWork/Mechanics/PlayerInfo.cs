using UnityEngine;

namespace HomeWork
{
    public class PlayerInfo : MonoBehaviour
    {
        [SerializeField] private CharacterInfo _character;

        public CharacterInfo GetCharacter()
        {
            return _character;
        }
    }
}