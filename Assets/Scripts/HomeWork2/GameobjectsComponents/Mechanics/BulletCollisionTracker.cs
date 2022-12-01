/*using UnityEngine;

namespace HomeWork2.GameobjectsComponents
{
    public class BulletCollisionTracker : MonoBehaviour
    {
        [SerializeField] private EventReceiverCollision _shootbulletReceiver;

        private void OnEnable()
        {
            _shootbulletReceiver.OnCollisionEntered += OnShoot;
        }

        private void OnDisable()
        {
            _shootbulletReceiver.OnCollisionEntered -= OnShoot;
        }
        
        // мы проверяем с каким объектом столнулись и у него берем демедж компонент
        

        private void OnShoot(Collision collision)
        {
            Debug.Log(collision + " " + collision.gameObject.name);
            Debug.Log(collision.gameObject.GetComponent<Entity>().TryGet(out ITakeDamageComponent takeDamageComponent));
            Debug.Log(gameObject.GetComponent<Entity>().Get<IDamageComponent>().Damage());
            takeDamageComponent.TakeDamage(gameObject.GetComponent<Entity>().Get<IDamageComponent>().Damage());
   
            /*if (obj.gameObject.GetComponent<Entity>().TryGet(out ITakeDamageComponent takeDamageComponent)){
             //   takeDamageComponent.TakeDamage(bullet.Get<IDamageComponent>().Damage);
            }#1#	 
        }


    }
}*/