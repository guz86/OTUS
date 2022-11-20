using UnityEngine;

namespace HomeWork.GameMechanics.Mechanics
{
    public class RandomMovementMechanics : MonoBehaviour
    {
        [SerializeField] private VectorEventReceiver _movementReceiver;
        [SerializeField] private TransformEngine _transformEngine;
        [SerializeField] private EventReceiver _eventReceiver;
        [SerializeField] private IntBehaviour _pointPositionXOne; //-5
        [SerializeField] private IntBehaviour _pointPositionXTwo; //6


        private void OnEnable()
        {
            _eventReceiver.OnEvent += OnMove;
        }

        private void OnDisable()
        {
            _eventReceiver.OnEvent -= OnMove;
        }

        // двигаться в случайное положение по Х
        public void OnMove()
        {
            Vector3 objectPosition = _transformEngine.GetPosition();
            Vector3 randomPosition = new Vector3(Random.Range(_pointPositionXOne.Value,
                    _pointPositionXTwo.Value),
                objectPosition.y,
                objectPosition.z);

            _movementReceiver.Call(randomPosition);
        }
    }
}