using UnityEngine;

namespace HomeWork
{
    public class MoveInDirectionСomponent : MonoBehaviour, IMoveInDirectionComponent
    {
        // логика взаимодействия с ядром

        [SerializeField] private Vector3EventReceiver _moveReceiver;

        public void Move(Vector3 vector)
        {
            _moveReceiver.Call(vector);
        }
    }
}