using Sirenix.OdinInspector;
using UnityEngine;

namespace HomeWork.GameMechanics.Mechanics
{
    public class ActionBehaviourPlayParticle :MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particle;

        [GUIColor(0, 1, 0)]
        [Button]
        public void Do()
        {
            _particle.Play();
        }
    }
}