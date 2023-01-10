using System;

namespace HomeWork
{
    public interface IManaPointsUpgradeComponent
    {
            event Action<int> OnManaPointsUpgrate;
            void UpgradeManaPoints(int manaPoints);
    }
}