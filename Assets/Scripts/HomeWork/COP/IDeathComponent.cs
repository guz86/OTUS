using System;

namespace HomeWork
{
    public interface IDeathComponent
    {
        event Action OnDied;
        
        void Die();
    }
}