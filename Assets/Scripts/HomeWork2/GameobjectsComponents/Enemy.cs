using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EventReceiver _shootReceiver;
        [SerializeField] private Vector3EventReceiver  _moveReceiver;


        public void Shoot()
        {
            _shootReceiver.Call();
        }

        public void Move(Vector3 vector)
        {
            _moveReceiver.Call(vector);
        }
    }
}