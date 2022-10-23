
using UnityEngine;

 [RequireComponent(typeof(Rigidbody2D))]
 [RequireComponent(typeof(CapsuleCollider2D))]
public abstract class Enemy : MonoBehaviour
{
   //[SerializeField] protected float _damage;
    public abstract float Speed{ get; }
    public abstract float HealthPoint{ get;set;} 
    public abstract float  Damage{get;}
    public abstract GameObject Effect{get;}
     private UIController _uIController = new UIController();
     private Coin _coin=new Coin();
     [SerializeField] protected GameObject _coins;

     private Vector3 _position; 
     
     protected  void Move(float speed)
     {
        transform.Translate(Vector3.down*Time.deltaTime*speed);
     } 
      private void OnTriggerEnter2D(Collider2D other) 
      {
         if(other.gameObject.GetComponent<Bullet>()) 
          {
             _position=transform.position;
              HealthPoint--; 
              HitEffect(Effect);
         }  
          if(other.gameObject.GetComponent<Finish>())
        {
            EventManager.HealthPointsDecrease();  
            Destroy(gameObject);               
        }                                           
      }
      protected abstract void HitEffect(GameObject effect);
     
      protected void Death(float healthPoint)
      {
          if(healthPoint<=0)  
              {    
             _coin.Create(_position,_coins);
               Destroy(gameObject);                 
            }   
     }  
     
      private void OnDestroy() 
      {
         EventManager.OnZombyTakeFinish -= _uIController.HealthPointDescrease;        
      }
}

