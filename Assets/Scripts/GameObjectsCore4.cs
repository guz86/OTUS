namespace Lesson
{
    public class GameObjectsCore4
    {
        
    }
    
    // организация проекта
    // game - meta - метамеханики в игре
    // каждая папка модульная, при удалении, проект продолжает работать = В папке Конфиги, Скрипты, Префабы, Контент
    
    // Основы механик игровых объектов
    
    // ядро: здоровье, получение урона, смерть, атака
    
    // Примитивные механики
    // Число int float - здоровье персонажа, линейная скорость
    // координаты transform - перемещение в пространстве
    // состояние bool enum - гибель, переключение состояние бегал, прыгал, вкл выкл подсказку
    // таймер писать класс timer - кулдаун для атаки
    // событие event - гибель персонажа, выстрел из оружия
    // коллизия collider - персонаж входит в зону тригера, столновение объекта 
    
    
    //механика получения урона это какое-то событие
    
    // здоровье это некий элемент с int
    // нужен элемент который будет хранить числа
    // IntBehaviour добавляется к HitPoints Объекту
    // EventReceiver - некий триггер с помощью которого можем вызывать событие
    // добавляем на TakeDamage Объект
    // хотим вызывать метод из EventReceiver в инспекторе
    // для этого есть плагин OdinInspector из кода [Button] добавлет кнопку
    // соединяем два элемента механикой TakeDamageMechanics через Observer
    // TakeDamageMechanics с EventReceiver будет висеть на объекте TakeDamage
    // в TakeDamage передаем EventReceiver (TakeDamage) и IntBehaviour (HitPoints) - связываем
    // По вызову Call() механика будет уменьшать здоровье
    
    // механика смерти по событию  -- Death + DeathMechanics.cs, EventReceiver.cs
    
    // К объекту Death добавляем новую механику DeathMechanics
    // где будем подписывать
    // из HitPoints - IntBehaviour - OnValueChanged наш метод OnHitPointsChanged 
    // OnHitPointsChanged будет выполнять проверку Value и вызывать при хп 0 Call() в ресивере 

    // механика атаки c кулдауном
    
    // делаем противника и добавляем таймер TimerBehavior на объект Attack
    // теперь нужен примитив с событием - EventReceiver добавляем на объект Attack 
    // механика которая свяжет примитивы - AttackMechanics
    //  обычно логика нанесения урона - от синего к красному - из атаки синего обратиться к TakeDamage красного
    // TEMP!!! временный варинат через Enemy.cs который свяжет логику нанесения урона
    // на Enemy(Red) добавляем Enemy.cs и указываем ссылку на обьект TakeDamage в _takeDamageReceiver
    // в AttackMechanics нам понадобится ссылка на Enemy
    // и в AttackMechanics логику нанесения урона TakeDamage() который отнимет здоровье
    // на синего игрока добавляем d Attack - AttackMechanics
    // -AttackMechanics +ресивер на событие из объекта
    // -AttackMechanics +таймер с объекта
    // -AttackMechanics + в Enemy наш красный куб
    
    //кастамизируем атаку и получение урона
    // - передаем значение урона в TakeDamageMechanics
    // - передаем значение урона  в Enemy
    // добавим еще один примитив IntEventReceiver.cs c Action<int> событием
    // в TakeDamageMechanics будем добавлять IntEventReceiver вместо EventReceiver
    // в Enemy будем добавлять IntEventReceiver вместо EventReceiver
    // на объект TakeDamage ставим IntEventReceiver
    // в AttackMechanics нужно передавать значение урона - 
    // в объект Attack добавляем объект Damage +  нему IntBehaviour 3

    // механика восстановления здоровья
    
    



}