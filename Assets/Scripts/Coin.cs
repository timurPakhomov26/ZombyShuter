
using UnityEngine;

public class Coin : MonoBehaviour
{
   [SerializeField] private float _moveSpeed;
   private Transform _coinsWallet;
   private bool _readyForWallet = false;


   private void Start()
   {
      _coinsWallet= GameObject.FindGameObjectWithTag("CoinsCount").GetComponent<Transform>();
   }
    private void Update() 
    {
       MoveToWallet();
    }
    public void Create(Vector3 _zombyPosition,GameObject coin)
    { 
        Instantiate(coin,_zombyPosition,Quaternion.identity);
    }
    
     private void OnMouseEnter()
      {
        _readyForWallet=true;
     }  
    private void MoveToWallet()
    {  
      if(_readyForWallet==true)
         transform.position= Vector3.MoveTowards(transform.position,_coinsWallet.position, _moveSpeed * Time.deltaTime);
    }
     private void OnTriggerEnter2D(Collider2D other) 
      {
          if(other.gameObject.CompareTag("CoinsCount"))
        {
           EventManager.CreateAnimation();
           Destroy(gameObject);              
        }                                           
      }
}
