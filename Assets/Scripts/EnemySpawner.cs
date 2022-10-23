
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{  
    [SerializeField] private Enemy[] _enemyes;
    [SerializeField] private float _timeForCreation;
    private float _time; 
     private const float MaxXPositionRight = 2.8f;
      private const float MaxXPositionLeft = -2.8f;
      private const float YPosition=5.8f;
    
   private void Update() 
    {
      Create();
    }
    private void Create() 
     {  
       _time += Time.deltaTime;
      var randomZomby=Random.Range(0,_enemyes.Length);   
      var randomX = Random.Range(MaxXPositionLeft,MaxXPositionRight);       
           if(_time >= _timeForCreation)
           {
               Instantiate(_enemyes[randomZomby],new Vector3(randomX,YPosition,1f),Quaternion.identity);
               _time=0;
           }       
     }              
}
