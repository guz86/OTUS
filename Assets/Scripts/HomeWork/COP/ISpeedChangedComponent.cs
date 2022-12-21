using System;

namespace HomeWork
{
    public interface ISpeedChangedComponent
    {
        event Action<float> OnSpeedChanged;
        float Speed { get; }
    }
}