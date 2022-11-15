using UnityEngine;

namespace HomeWork.GameMechanics.Mechanics
{
    public class MovementMechanics : MonoBehaviour
    {
        [SerializeField] private VectorEventReceiver _moveReceiver;
        [SerializeField] private GameObject _visualObject;
        
        private void OnEnable()
        {
            _moveReceiver.OnEvent += OnMove;
        }

        private void OnDisable()
        {
            _moveReceiver.OnEvent -= OnMove;
        }
        

        private void OnMove(Vector3 position)
        {
            //transform.position = new Vector3(0,0,2) * Time.deltaTime; 
            _visualObject.transform.position = new Vector3(position.x,0.5f,position.z);
        }
    }
}