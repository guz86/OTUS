using UnityEngine;

namespace HomeWork
{
    public class CameraService : MonoBehaviour
    {
        public Camera Camera
        {
            get { return this.camera; }
        }

        public Transform CameraTransform
        {
            get { return this.cameraTransform; }
        }

        [SerializeField]
        private Transform cameraTransform;

        [SerializeField]
        private new Camera camera;
    }
}