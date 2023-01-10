﻿using UnityEngine;

namespace HomeWork
{
    public class TakeDamageMechanics : MonoBehaviour
    {
        [SerializeField] private IntEventReceiver _takeDamageReceiver;
        [SerializeField] private HitPointsEngine _hitPoints; 
        

        private void OnEnable()
        {
            this._takeDamageReceiver.OnEvent += this.OnDamageTaken;
        }

        private void OnDisable()
        {
            this._takeDamageReceiver.OnEvent -= this.OnDamageTaken;
        }

        private void OnDamageTaken(int damage)
        {
            this._hitPoints.CurrentHitPoints -= damage;
        }
    }
}