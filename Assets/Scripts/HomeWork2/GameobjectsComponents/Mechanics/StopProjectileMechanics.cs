using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public class StopProjectileMechanics : MonoBehaviour
    {
        private void OnEnable()
        {
            transform.GetComponent<Rigidbody>().WakeUp();
        }
        
        private void OnDisable()
        {
            transform.GetComponent<Rigidbody>().Sleep();
        }
    }
}