using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public class JumpСomponent : MonoBehaviour, IJumpComponent
    {
        // логика взаимодействия с ядром

        [SerializeField] private EventReceiver _jumpReceiver;

        public void Jump()
        {
            _jumpReceiver.Call();
        }
    }
}