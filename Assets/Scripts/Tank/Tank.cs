
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private GameObject _aim;
	[SerializeField] private GameObject _bullet;
	[SerializeField] private Transform _bulletSpawn;
	[SerializeField] private float offset;
	 private Animation _animation;
 	private StockOfBullets _stockOfBullets = new StockOfBullets();
	private AudioSource _audioSource;
	

    private void Start() 
	{		
	  _audioSource=GetComponent<AudioSource>();	
	  _animation=GetComponent<Animation>();
	}																																																																																																		
	private void Update()
	{
		Rotate();
		AimActivate();		
	}
    private void AimActivate()
	 {		
		if (Input.GetMouseButton(0))		
			_aim.SetActive(true);
			
		if(Input.GetMouseButtonUp(0))		
            Shoot();				
	 }
	 private void Shoot()
	 { 	
	  if(_stockOfBullets.BulletsCount > 0)
	   {
		 _animation.Play();
          Instantiate(_bullet,_bulletSpawn.position,transform.rotation);
		  _audioSource.pitch = Random.Range(0.8f,1.2f);
		  _audioSource.Play();		  		
		 _stockOfBullets.BulletsCount--;			
	   }  	            	     
	 }
	 private void Rotate()
	 {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
	 }
  }
