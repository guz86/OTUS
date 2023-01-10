using UnityEngine;

namespace HomeWork
{
    [CreateAssetMenu(
        fileName = "CharacterInfo",
        menuName = "Lessons/New Character"
    )]
    
    public class CharacterInfo : ScriptableObject
    {
            [SerializeField] public string title;
            [Space] [SerializeField] public Sprite icon;
            [Space] [SerializeField] public string description;
    }
}