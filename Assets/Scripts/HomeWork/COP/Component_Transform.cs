using UnityEngine;

namespace HomeWork
{
    public class Component_Transform : MonoBehaviour,
        IComponent_GetPosition
    {
        public Vector3 Position
        {
            get { return this.root.position; }
        }

        [SerializeField]
        private Transform root;
    }
}