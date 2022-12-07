using UnityEngine;

namespace HomeWork
{
    public class CharacterService : MonoBehaviour
    {
        [SerializeField] private Entity _character;

        public IEntity GetCharacter()
        {
            return _character;
        }
    }
}