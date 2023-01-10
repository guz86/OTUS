using System;

namespace HomeWork
{
    public interface IBulletHitUpgade
    {
        event Action<int> OnBulletUpgrate;
        void UpgradeHit(int hit);
        int Hit { get; }
    }
}