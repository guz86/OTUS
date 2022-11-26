using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HomeWork2.GameobjectsComponents
{
    public class MovePositionRandomizer : MonoBehaviour
    {
        //[SerializeField] private TransformEngine _transformEngine;
        [SerializeField] private Entity _unit; //-5
        [SerializeField] private float _pointPositionXOne; //-5
        [SerializeField] private float _pointPositionXTwo; //6
        private ITransformComponent _transformComponent;

        private void Start()
        {
            _transformComponent = _unit.Get<ITransformComponent>();
        }

        public Vector3 RandomPosition()
        {
            Vector3 objectPosition = _transformComponent.GetPosition();;
            var randomX = Random.Range(_pointPositionXOne,
                _pointPositionXTwo);
            return new Vector3(randomX, objectPosition.y, objectPosition.z);
        }
    }
}