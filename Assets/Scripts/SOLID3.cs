using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class SOLID3
    {
    }

    // SRP Принцип единой ответственности
    
    // как у класса появляется несколько отвественностей
    // враг поворачивается в сторону игрок и идет к нему - можно объединить в одну логику

    // признаки нарушения

    // - именования класса, если хочется добавить два слова в название для описания логики
    // создает и перемещает
    public class SpawnPositioningSystem
    {
        public void Spawn()
        {
        }

        public void MoveToPosition()
        {
        }
    }

    // объединены предметы для кравта и рецепты
    public class CraftItemsAndRecipes
    {
    }

    // поля которые могут в теории относится к разным логикам
    public class ShouldBeSeparated
    {
        private int _health;
        private int _mana;

        private int _level;
        private int _experience;

        private int _killCount;

        private int _damage;
        private int _resistance;
    }
    
    // пример нарушения SRP
    // * sealed запрет наследования
    public sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private void Update()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                this.Move(Vector3.up);
            }
            else  if (Input.GetKey(KeyCode.DownArrow))
            {
                this.Move(Vector3.down);
            }
            else  if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.Move(Vector3.left);
            }
            else  if (Input.GetKey(KeyCode.RightArrow))
            {
                this.Move(Vector3.right);
            }
        }

        private void Move(Vector3 direction)
        {
            this.transform.position = direction * (Time.deltaTime * _speed);
            this.transform.rotation = Quaternion.LookRotation(direction,Vector3.up);
        }
        
        // смешивается логика считывания с клавиатуры  Input.GetKey и логика перемещения void Move

    } 
          
    // разделение согласно SRP, разделяем на два класса
    // Player (отвественнен за перемещение) и MoveController (за считывание и передачу вектора)
    
    // Input <=> Move
    
    //Это позволяет менять метод ввода, ИИ может управлять перемещением,
    //и наоборот мы можем заставить систему управлять кораблем, врагом...
    
    public sealed class Player2 : MonoBehaviour
    {
        [SerializeField] private float _speed;
 
        public void Move(Vector3 direction)
        {
            this.transform.position = direction * _speed;
            this.transform.rotation = Quaternion.LookRotation(direction,Vector3.up);
        } 
    }

    public sealed class MoveController
    {
        [SerializeField] private Player2 _player2;
        private void Update()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                this.Move(Vector3.up);
            }
            else  if (Input.GetKey(KeyCode.DownArrow))
            {
                this.Move(Vector3.down);
            }
            else  if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.Move(Vector3.left);
            }
            else  if (Input.GetKey(KeyCode.RightArrow))
            {
                this.Move(Vector3.right);
            }
        }

        private void Move(Vector3 direction)
        {
            this._player2.Move(direction * Time.deltaTime);
        }

    }
    
    // пример нарушения SRP
    // смешались логики подсчет очков и выдача достижений 
    public class ScoreController
    {
        private int _points;
        private bool _notAwardedYet = true;

        public void AddPoints(int amount)
        {
            _points += amount;
            CheckAchievement();
        }

        private void CheckAchievement()
        {
            if (_points > 1000 && _notAwardedYet)
            {
                _notAwardedYet = true;
                Debug.Log("Achievement unlocked");
            }
        }
    }
    
    // тут одна ачивка, но их обычно много и у каждой условия, поэтому нужен менеджер
    
    // Система очков PointsManager <> Система ачивок AchievementManager <> ачивка Achievement
    
    // когда добавляем очки может произойти: обновление UI, возможно выдать ачивку, увеличить уровень перса, и т.д.
    // поэтому добавляем публичный ивент который будем вызывать каждый раз при добавлении очков

    public class PointsManager
    {
        public event Action PointsChangedEvent;
        public int Points => _points;
        private int _points;

        public void AddPoints(int points)
        {
            _points += points;
            PointsChangedEvent?.Invoke();
        }
    }
    
    // для разных ачивок делаем абстрактный класс
    public abstract class Achievement
    {
        public string name;
        public abstract bool IsCompleted();
    }

    public class PointsAchievement : Achievement
    {
        private PointsManager _pointsManager;
        public override bool IsCompleted()
        {
            return _pointsManager.Points > 1000;
        }
    }

    public class AchievementManager
    {
        private List<Achievement> _achievements = new();
        private PointsManager _pointsManager;
        // чтобы лишний раз не выдавать ачивки
        private HashSet<string> _completedAchievements = new();

        public void Init()
        {
            // подписывается на событие и запускает CheckAchievements
            _pointsManager.PointsChangedEvent += CheckAchievements;
            
        }

        private void CheckAchievements()
        {
            foreach (var achievement in _achievements)
            {
                if (achievement.IsCompleted() && !_completedAchievements.Contains(achievement.name))
                {
                    CompleteAchievement(achievement);
                }
            }
        }

        private void CompleteAchievement(Achievement achievement)
        {
            _completedAchievements.Add(achievement.name);
        }
    }
    
    
    

    // OCP Принцип открытости закрытости
    
    
}