using System;

namespace HomeWork
{
    public interface IManaPointsChangedComponent
    {
        event Action<int> OnManaPointsChanged;
        int ManaPoints { get; }
    }
}