﻿using UnityEngine;

namespace HomeWork.GameMechanics.Mechanics
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EventReceiver _shootReceiver;
        [SerializeField] private VectorEventReceiver  _moveReceiver;


        public void Shoot()
        {
            _shootReceiver.Call();
        }

        public void Move(Vector3 vector)
        {
            _moveReceiver.Call(vector);
        }
    }
}