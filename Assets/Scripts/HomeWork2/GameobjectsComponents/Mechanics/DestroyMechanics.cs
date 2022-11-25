using UnityEngine;

namespace HomeWork2.GameobjectsComponents
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
