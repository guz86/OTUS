using UnityEngine;

namespace Lessons.Architecture.Mechanics
{
    public interface IMoveComponent
    {
        void Move(Vector3 vector);
    }
}