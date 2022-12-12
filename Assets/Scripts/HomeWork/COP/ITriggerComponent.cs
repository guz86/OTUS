using System;
using UnityEngine;

namespace HomeWork
{
    public interface ITriggerComponent
    {
        event Action<Collider> OnTriggerEntered;
    }
}