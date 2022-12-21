using UnityEngine;

namespace HomeWork
{
    public class WorldCameraService
    {
        public static Camera Instance { get; private set; }

        public static void SetupCamera(Camera camera)
        {
            Instance = camera;
        }
    }
}