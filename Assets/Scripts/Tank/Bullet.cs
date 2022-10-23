
using UnityEngine;

public class Bullet : MonoBehaviour
{ 
    [SerializeField] private float _speed;   
    [SerializeField] private float _maxDistanceToTank;
    [SerializeField] private GameObject _effect;
    private Transform _tank;

     private void Start() 
     {
         _tank = FindObjectOfType<Tank>().transform;   
     }
    private void Update() 
    {
       Move();
       Destroy();
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.GetComponent<Enemy>())       
            Destroy(gameObject);                
    }
    private void Destroy()
    {   
         Destroy(gameObject,2.5f);   
    }
    private void Move()
    {
       transform.Translate(Vector2.up *Time.deltaTime * _speed);
    }
}
