using UnityEngine;

namespace HomeWork
{
    [CreateAssetMenu(
        fileName = "Upgrade",
        menuName = "Lessons/New Upgrade (Presentation Model)"
    )]
    public class Upgrade : ScriptableObject
    {
        [SerializeField] public string title;
        
        [Space] [SerializeField] public int level;
        [Space] [SerializeField] public int hitPoints;
        [Space] [SerializeField] public int manaPoints;
        [Space] [SerializeField] public int damage;
        
        [Space] [SerializeField] public int price;
    }
}