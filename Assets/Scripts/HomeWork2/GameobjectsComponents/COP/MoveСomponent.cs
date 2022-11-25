using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public class MoveСomponent : MonoBehaviour, IMoveComponent
    {
        // логика взаимодействия с ядром

        [SerializeField] private Vector3EventReceiver _moveReceiver;

        public void Move(Vector3 vector)
        {
            _moveReceiver.Call(vector);
        }
    }
}