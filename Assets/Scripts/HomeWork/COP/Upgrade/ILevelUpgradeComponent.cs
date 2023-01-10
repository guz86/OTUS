using System;

namespace HomeWork
{
    public interface ILevelUpgradeComponent
    {
        event Action<int> OnLevelUpgrate;
        void UpgradeLevel(int hitPoints);
        int Level { get; }
    }
}