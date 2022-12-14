namespace Lesson
{
    public class GameobjectsComponents5
    {
    }
    // когда подходит компонентный подход и когда нет и нужно ООП
    // ООП
    //  напишем фасад (англ. Facade) для Character (интерфейс к сложной системе классов) еще есть Enemy
    // через него с помощью событий мы сможем вызывать и получить доступ к методам и полям нашего героя
    // мы оборачиваем все методами свойствами и ивентами
    // реализуем контроллер для взаимодействия MoveController, взаимодействие будет реализовано через нашу обертку Character
    // CharacterMoveController добавляем на объект на сцене Controller
    // Проблема. если на другом уровне нам надо играть за другой кубик, то нам надо еще один MoveController
    // реализуем для Enemy тоже перемещение, надо добавить механику Move, добавляем в Enemy логику перемещения
    // добавим для Enemy EnemyMoveController и добавим его на объект Controller
    // появившееся проблемы: дублирование кода, (аналогичная проблема будет с респауном, атакой и прочим)
    // для решения проблемы вынесем логику в AbstractMoveController
    // CharacterMoveController и EnemyMoveController будут наследоваться от AbstractMoveController - вынесли общую логику
    // остается проблема в реализации отдельных классов для перемещения, будет много кода
    // как сделать чтобы можно было переиспользовать код?
    // проблема - с Character классом могут взаимодействать другие классы (смерть, респаун, создание модели и .д.)
    // и если его выпилить, то не скомпилируется проект.
    // если сделаем ICharacter все равно зависимость от контракта будет тянуться через весь проект
    // нужно представить объект в виде композиции из компонентов - Entity Component Pattern
    // компоненты - интерфейс общения внешних объектов с ядром
    //  один компонент работает с одним примитивным элементом в ядре "дробим фасад на провайдеры"
    // каждый класс компонента должен иметь уникальное название
    // Реализуем компонентый подход
    // Напишем сущность, где будут храниться наши компоненты Entity в каталоге COP, контроллеры в каталоге Controllers
    // в Entity будем хранить монобехи, базовый функционал Get<T> ищет компонент по типу, TryGet<T> пытается найти компонент
    // добавим Entity на Enemy и Character
    // напишем MoveController который будет работать с нашей сущьностью Entity
    // добавляем на объект MoveController и создадим новый геймоббжект Components - Move
    // и нужно реализовать MoveСomponent для IMoveComponent
    // MoveСomponent без бизнес логики это связующее звено объекта с внешним миром
    // Controller - Char(Entity) - Component - Move (MoveComponent) - через Receiver - в ядро Core - Movement(MoveMechanics)
    // Controller - Enemy(Entity) - Component - Move (MoveComponent) - через Receiver - в ядро Core - Movement(MoveMechanics)
   

}