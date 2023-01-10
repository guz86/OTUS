using System;

namespace HomeWork
{
    public interface IHitPointsUpgradeComponent
    {
        event Action<int> OnHitPointsUpgrate;
        void UpgradeMaxHitPoints(int hitPoints);
        void UpgradeHitPoints(int hitPoints);
    }
}