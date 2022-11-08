using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class BasisArchitecture2 : MonoBehaviour
{
}

// DryExample

public class WarriorMelee : MonoBehaviour
{
    private float _attackRange = 3f;

    public bool IsEnemyInRange(Vector3 enemyPosition)
    {
        // .magnitude дистанция между векторами
        return (transform.position - enemyPosition).magnitude <= _attackRange;
    }
}

public class WarriorRanged : MonoBehaviour
{
    private float _attackRange = 3f;

    public bool IsEnemyInRange(Vector3 enemyPosition)
    {
        // .magnitude дистанция между векторами
        return (transform.position - enemyPosition).magnitude <= _attackRange &&
               CanSeeTarget(enemyPosition);
    }

    // цель в зоне прямой видимости, не за камнем        
    private bool CanSeeTarget(Vector3 target)
    {
        return true;
    }
}

// варианты избавления от повторения кода

// базовый класс // если не будет использоваться то будет абстрактным

public abstract class Warrior : MonoBehaviour
{
    private float _attackRange = 3f;

    //public abstract bool IsEnemyInRange(Vector3 enemyPosition);
    public virtual bool IsEnemyInRange(Vector3 enemyPosition)
    {
        return (transform.position - enemyPosition).magnitude <= _attackRange;
    }
}

public class WarriorMelee2 : Warrior
{
}

public class WarriorRanged2 : Warrior
{
    public override bool IsEnemyInRange(Vector3 enemyPosition)
    {
        return base.IsEnemyInRange(enemyPosition);
    }

    public bool CanAttack(Vector3 enemyPosition) => CanSeeTarget(enemyPosition) && IsEnemyInRange(enemyPosition);

    private bool CanSeeTarget(Vector3 target)
    {
        return true;
    }
}


// интерфейс, не помогает

public interface IWarrior
{
    //private float _attackRange = 3f;
    public float AttackRange { get; }

    public bool IsEnemyInRange(Vector3 enemyPosition);
}

public class WarriorMelee3 : MonoBehaviour, IWarrior
{
    public float AttackRange => 3f;

    public bool IsEnemyInRange(Vector3 enemyPosition)
    {
        return (transform.position - enemyPosition).magnitude <= AttackRange;
    }
}

public class WarriorRanged3 : MonoBehaviour, IWarrior
{
    // добавим вызов карутины
    private CoroutineManager _coroutineManager;

    private Animation _animation;

    private IEnumerator PlayDeathAnimation()
    {
        _animation.Play("Death");
        yield return new WaitUntil(() => !_animation.isPlaying); // ждем пока проиграется анимация
    }
    // добавим вызов карутины


    // добавим случайно выпадающее золото для примера
    private List<int> _gold = new() {1, 2, 33, 44, 55, 112};

    public int GetRandomGold()
    {
        // добавим вызов карутины
        // вызывается и без MonoBehaviour
        _coroutineManager.RunCorounineWithCallback(PlayDeathAnimation(), OnDeath);
        // добавим вызов карутины

        int xcount = Random.Range(1, 6);
        //return _gold[Random.Range(0, _gold.Count)];
        //используем метод расширения
        return _gold.GetRandomElementofList();
    }

    // вызов из карутины
    private void OnDeath()
    {
        Debug.Log("Dead");
    }

    // добавим случайно выпадающее золото для примера

    public float AttackRange => 3f;

    public bool IsEnemyInRange(Vector3 enemyPosition)
    {
        return (transform.position - enemyPosition).magnitude <= AttackRange;
    }

    public bool CanAttack(Vector3 enemyPosition) => CanSeeTarget(enemyPosition) && IsEnemyInRange(enemyPosition);

    private bool CanSeeTarget(Vector3 target)
    {
        return true;
    }
}


// статический класс как пример оптимизации методов

public static class UtilsNew
{
    // метод расширения который можем использовать в любом месте проекта
    public static T GetRandomElementofList<T>(this List<T> _list)
    {
        return _list[Random.Range(0, _list.Count)];
    }
}


// карутины
// кто угодно может обратиться и без MonoBehaviour использовать карутины
public class CoroutineManager : MonoBehaviour
{
    public void RunCorounineWithCallback(IEnumerator coroutine, Action callback)
    {
        StartCoroutine(RunCoroutine(coroutine, callback));
    }

    private IEnumerator RunCoroutine(IEnumerator coroutine, Action callback)
    {
        yield return coroutine;
        callback?.Invoke();
    }
}