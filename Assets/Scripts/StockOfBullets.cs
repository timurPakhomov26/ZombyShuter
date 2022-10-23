
using System.Collections;
using UnityEngine;

public class StockOfBullets : MonoBehaviour
{
    private static int _count=1;
    public int BulletsCount {get => _count;set => _count = value;}
    private float _timeForRelod;

  
   private void Update()
    {  
     if(BulletsCount<=0)   
      Reload();        
   }
   
  IEnumerator ReloadStock()
   {     
        for(;BulletsCount < 5;)
        {
              yield return new WaitForSeconds(2f);   
            BulletsCount++;                            
        }                    
   }
   private void Reload()
   { 
     _timeForRelod += Time.deltaTime;
        if( _timeForRelod > 1.5f)
        {              
            BulletsCount++;   
            _timeForRelod=0;                         
        }   
   }   
}
