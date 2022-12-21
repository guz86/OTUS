using System;

namespace HomeWork
{
    public interface IHitPointsChangedComponent
    {
        event Action<int> OnHitPointsChanged;
        int HitPoints { get; }
    }
}