using UnityEngine;

namespace HomeWork
{
    public interface IPlayerInfoComponent
    {
        string GetName();
        string GetDescription();
        Sprite GetIcon();
    }
}