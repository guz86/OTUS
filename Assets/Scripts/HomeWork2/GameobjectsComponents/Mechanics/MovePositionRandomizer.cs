using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public class MovePositionRandomizer : MonoBehaviour
    {
        [SerializeField] private TransformEngine _transformEngine;
        [SerializeField] private float _pointPositionXOne; //-5
        [SerializeField] private float _pointPositionXTwo; //6

        public Vector3 RandomPosition()
        {
            Vector3 objectPosition = _transformEngine.GetPosition();
            var randomX = Random.Range(_pointPositionXOne,
                _pointPositionXTwo);
            return new Vector3(randomX, objectPosition.y,objectPosition.z);
        }
    }
}