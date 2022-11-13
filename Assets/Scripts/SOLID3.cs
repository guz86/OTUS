using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class SOLID3 : MonoBehaviour
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
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                this.Move(Vector3.down);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.Move(Vector3.left);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                this.Move(Vector3.right);
            }
        }

        private void Move(Vector3 direction)
        {
            this.transform.position = direction * (Time.deltaTime * _speed);
            this.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
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
            this.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
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
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                this.Move(Vector3.down);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.Move(Vector3.left);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
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


    // +++sakut
    // если довести принцип до идеала, то получим антипринцип SRP, куча классов и ничего не понятно, откуда, что и куда идет
    // пример нарушения SRP - GameManager - класс который пытается сделать все

    public class GameManager : MonoBehaviour
    {
        // состояние ресурсов
        private int _money;
        private int _health;

        // спаунер
        private int _enemyCount;
        private Transform _spawnPoint;
        private float _spawnTimer;
    }

    // разбиваем

    public class EnemySpawner : MonoBehaviour
    {
        // спаунер
        private int _enemyCount;
        private Transform _spawnPoint;
        private float _spawnTimer;
    }

    public class Player3 : MonoBehaviour
    {
        // состояние ресурсов
        private int _money;
        private int _health;
    }

    // при добавлении новых задач в Player3 
    public class Player4 : MonoBehaviour
    {
        // состояние ресурсов
        private int _money;
        private int _health;

        private List<Good> _items;
        private List<float> _cooldowns;
    }

    internal class Good
    {
    }

    // выделяем и добавляем новый класс
    public class Inventory : MonoBehaviour
    {
        private List<Good> _items;
        private List<float> _cooldowns;
    }

    // декомпозиция происходит при расширении системы

    // +++sakut


    // OCP Принцип открытости закрытости

    // класс закрыт для модификации, но открыт для расширений (стараться не менять базовую логику которая работает)
    // можем сломать логику наследников или их части
    // принцип реализуется через Абстрактные классы, интерфейсы, дженерики.

    //Если сущности имеют схожую базовую логику, но отличаются в реализации, то общую логику в абстрактный класс.
    //Если нет общей логики или ее мало, подойдет интерфейс.

    // OCPExample

    //абстрактный класс пример апгрейд персонажа(улучшаем разные параметры - урон, здоровье и т.д.)


    public abstract class Upgrade
    {
        //[ReadOnly][ShowInInpector] 
        public abstract string CurrentStats { get; }
        public abstract string NextImprovement { get; }
        protected abstract void ProcessLevelUp(int level);
    }


    public sealed class DamageUpgrade : Upgrade // , IGameInitElement
    {
        public override string CurrentStats { get; } // return this.config.damageTable.GetDamage.ToString();
        public override string NextImprovement { get; } // return this.config.damageTable.DamageStep.ToString();

        protected override void ProcessLevelUp(int level)
        {
            //this.SetDamage(level)
        }
    }
    //абстрактный класс пример апгрейд персонажа(улучшаем разные параметры - урон, здоровье и т.д.)


    //пример интерфейсов - вариант первоначальной инициализации игры

    public interface ILoadingTask
    {
        void Do(Action<LoadingResult> callback);
    }

    public readonly struct LoadingResult
    {
        //
    }

    public sealed class LoadingTask_InitializePurchasing : ILoadingTask
    {
        public void Do(Action<LoadingResult> callback)
        {
            // PurchasingInitializer.Init(result =>
            // {
            //     if (result.isSuccess)
            //     {
            //         callback?.Invoke(LoadingResult.Success());
            //     }
            //     else
            //     {
            //         callback?.Invoke(LoadingResult.Fail(result.error.ToString()));
            //     }
            // });
        }
    }

    public static class PurchasingInitializer
    {
        //
    }

    //пример интерфейсов - вариант первоначальной инициализации игры

    // OCPExample Враг может переходить к разным состояниям 
    // наследники переопределяют абстрактную логику Patrol DoAttack DoIdle - разные враги

    public abstract class Enemy : MonoBehaviour
    {
        private WarriorState _currentState;
        private Dictionary<WarriorState, Action> _stateDelegates;

        public void Init()
        {
            _stateDelegates = new()
            {
                {WarriorState.Idle, DoIdle},
                {WarriorState.Attack, DoAttack},
                {WarriorState.Patrol, DoPatrol},
            };
        }

        public void OnStateChanged()
        {
            _stateDelegates[_currentState].Invoke();
        }

        protected abstract void DoPatrol();
        protected abstract void DoAttack();
        protected abstract void DoIdle();
    }

    internal class WarriorState
    {
        public static WarriorState Idle { get; set; }
        public static WarriorState Attack { get; set; }
        public static WarriorState Patrol { get; set; }
    }

    // нарушить принцип в примере 
    // сделать виртуальным OnStateChanged() и переопределить, 
    // как пример подкупленный враг патрулирует в дальнейшем может поломать логику

    public abstract class Enemy2 : MonoBehaviour
    {
        private WarriorState _currentState;
        private Dictionary<WarriorState, Action> _stateDelegates;

        protected virtual void OnStateChanged2()
        {
            _stateDelegates[_currentState].Invoke();
        }

        protected abstract void DoPatrol();
        protected abstract void DoAttack();
        protected abstract void DoIdle();
    }

    public class MeleeEnemy : Enemy2
    {
        private bool _isBribed;

        protected override void OnStateChanged2()
        {
            if (_isBribed)
            {
                DoPatrol();
            }
            else
            {
                base.OnStateChanged2();
            }
        }

        protected override void DoPatrol()
        {
        }

        protected override void DoAttack()
        {
        }

        protected override void DoIdle()
        {
        }
    }

    // +++sakut
    //при появлении новых требований нельзя будет изменить базовый класс,
    //потому что это изменение отразится на работе других классов

    // пример если мы резко затормозили занчит мы с чем то столнулись. (можно проверить через колизии)
    [RequireComponent(typeof(Rigidbody))] // должен присутствовать Rigidbody
    public class Player5 : MonoBehaviour
    {
        //открываем код для расширения через события
        public UnityEvent OnFalled; // если игрок упал на объекте в события добавляется например воспроизведение звука


        private Vector3 _lastVelocity;
        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if ((_lastVelocity - _rigidbody.velocity).magnitude > 5) // резко поменялась скорость
            {
                OnFalled?.Invoke();
            }

            _lastVelocity = _rigidbody.velocity;
        }
    }
    // +++sakut


    // LSP Принцип подстановки Барбары Лисков

    // Если класс пользуется классом Animal, то он должен пользоваться и наследниками Dog Cat.
    // Без разницы базовый класс или наследник.

    // LSPExample

    // нарушение принципа 1
    // проверили что towerbase.price > _playerMoney денег хватает списали деньги, а башня уже максимального уровня
    // изменили логику работы метода UpgradeTower()

    public class TowerManager
    {
        private int _playerMoney;

        public bool TryUpgradeTower(TowerBase towerbase)
        {
            if (towerbase.price > _playerMoney)
            {
                return false;
            }

            _playerMoney -= towerbase.price;
            towerbase.UpgradeTower();
            return true;
        }
    }

    public abstract class TowerBase
    {
        public int price;
        public abstract void UpgradeTower();
    }

    public class MageTower : TowerBase
    {
        private int _currentLevel;
        private int _maxLevel;

        public override void UpgradeTower()
        {
            if (_currentLevel < _maxLevel)
            {
                _currentLevel++;
            }
        }
    }
    
    // исправление
    // если уровень прокачки есть у всех башень то выносится в TowerBase
    // если уровень прокачки только у MageTower, (TowerManager не должен
    // знать детали реализации MageTower (время, количество врагов, уровень и т.д.))  
    // есть вариант вынести в абстрактную проверку CanUpgrade
    
    //вариант исправления
    
    public class TowerManager2
    {
        private int _playerMoney;

        public bool TryUpgradeTower(TowerBase2 towerbase)
        {
            if (towerbase.price > _playerMoney)
            {
                return false;
            }

            return towerbase.TryUpgradeTower();
        }
    }

    public abstract class TowerBase2
    {
        public int price;
        private int _currentLevel;
        private int _maxLevel;
        protected float Damage;
        

        public bool TryUpgradeTower()
        {
            if (_currentLevel >= _maxLevel)
            {
                return false;
            }
            
            _currentLevel++;
            UpgradeTower();
            return true;
        }
        
        protected abstract void UpgradeTower();
    }

    public class MageTower2 : TowerBase2
    {
        protected override void UpgradeTower()
        {
            Damage += 10;
        }
    }
    
    // отнимание денег на другом уровне если if (TryUpgradeTower(towerbase)) _playerMoney -=towerbase.price;
    // отнимаем деньги если получается проапгредить
    
    
    // нарушение принципа 2
    // два наследника и один из наследников не атакует, т.к. мы обязаны реализовать
    // его мы выкидываем исключение - плохой стиль
    
    public class TowerManager3 : MonoBehaviour
    {
        private int _playerMoney;

        private List<TowerBase3> _towers = new();

        private void Update()
        {
            foreach (var towerBase in _towers)
            {
                towerBase.Attack();
                towerBase.Support();
            }
        }
    }

    public abstract class TowerBase3
    {
        public int price;
        public abstract void Attack();
        public abstract void Support();
    }

    public class MageTower3 : TowerBase3
    {
        public override void Attack()
        {
            // DealDamage(5);
        }

        public override void Support()
        {
            // AddShield(10);
        }
    }
    public class BoostTower3 : TowerBase3
    {
        public override void Attack()
        {
            // throw new NotImplementedException(); в оригинале не закоммичена
        }

        public override void Support()
        {
            // BoostAttckSpeed(10);
        }
    }
    
    
    // вариант исправления
    // через интерфейсы
    
    public class TowerManager4 : MonoBehaviour
    {
        private int _playerMoney;
        private List<TowerBase4> _towers = new();

        // лучше избегать писать код в Update() лучше отдельно сделать массивы с AttackTowers и SupportTowers
        // и в нужный момент проходиться по этим спискам и не делать проверку
        
        private void Update()
        {
            foreach (var towerBase in _towers)
            {
                // безопасное приведение 
                if (towerBase is IAttackTower attackTower)
                {
                    attackTower.Attack();
                }
                if (towerBase is ISupportTower supportTower)
                {
                    supportTower.Support();
                }
            }
        }
    }

    public interface IAttackTower
    {
        public void Attack();
    }
    
    public interface ISupportTower
    {
        public void Support();
    }

    public abstract class TowerBase4
    {
        public int price;
    }

    public class MageTower4 : TowerBase4, IAttackTower, ISupportTower
    {
        public void Attack()
        {
            // DealDamage(5);
        }

        public void Support()
        {
            // AddShield(10);
        }
    }
    public class BoostTower4 : TowerBase4, ISupportTower
    {
        public void Support()
        {
            // BoostAttckSpeed(10);
        }
    }
    
    
    // +++sakut
    // базовый тип служит неким контрактом, который производный тип обязан соблюдать
    // +++sakut
    
    
    // ISP Принцип разделения интерфейсов
    // сущности не должны зависеть от методов которые они не используют. Большие интерфейсы лучше разделять на мелкие.

    public interface IBadInterface
    {
        public void Move();
        public void Jump();
        public void Craft();
        public void Run();
    }
    // кто-то может не уметь прыгать
    
    public interface IMoveComponent
    {
        public void Move();
    }

    public interface IJumpComponent
    {
        public void Jump();
    }
    
    public interface ICraftComponent
    {
        public void Craft();
    }
    
    public interface IRunComponent
    {
        public void Run();
    }

    // DIP Принцип инверсии зависимостей
    
    // Модули верхних уровней не должны зависеть от модулей нижних уровней
    // модули обоих уровней должны зависеть от абстракций
    // Абстракции НЕ должны зависеть от деталей, детали должны зависеть от абстракций
    
    // утюг <=> электростанция
    // утюг получает от электростанции энергию, как сделать лучше?
    // выделить интерфейсы Электроприбор <=> источник энергии  // абстрактный уровень
    //                     Утюг                Электростанция  // конкретный уровень
    
    // таким образом и утюг и электростанции могут поменяться
    
    
    // DIP Example 
    
    // UISystem обращается к объект StatusView при этом не зная экземпляром какого наследника объект является,
    // а уже наследники реализуют базовый метод по-разному
    
    public abstract class StatusView : MonoBehaviour
    {
        public class Data
        {
            public float progress;
            public Sprite icon;
            public int amount;
        }

        public abstract void SetData(Data data);
    }

    public class StatusViewOnlyText : StatusView
    {
        [SerializeField] private TextMeshProUGUI _statusText;
        public override void SetData(Data data)
        {
            _statusText.text = data.amount.ToString();
        }
    }
    
    public class StatusViewTextAndBar : StatusView
    {
        [SerializeField] private TextMeshProUGUI _statusText;
        [SerializeField] private Slider _slider;
        public override void SetData(Data data)
        {
            _statusText.text = data.amount.ToString();
            _slider.value = data.progress;
        }
    }
    


}