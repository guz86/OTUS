using UnityEngine;

namespace HomeWork.GameMechanics.Mechanics
{
    public class DestroyMechanics : MonoBehaviour
    {
        [SerializeField] private FloatBehavior _destoyTime;

        private void Awake()
        {
            Destroy(gameObject, _destoyTime.Value);
        }
    }
}
