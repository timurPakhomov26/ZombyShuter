
using UnityEngine;

public class StandartZomby : Enemy
{
    [SerializeField] private float _speed;
    [SerializeField] private float _healthPoint;
    [SerializeField] private GameObject _effect;
     [SerializeField] private float _damage;

   
    public override float Speed => _speed;
      public override float HealthPoint { get =>_healthPoint;  set => _healthPoint = value;}
    public override GameObject Effect => _effect;

    public override float Damage => _damage;

    protected override void HitEffect(GameObject effect)
    {      
         Instantiate(effect,transform.position,Quaternion.identity);   
    }

    private void Update()
    {
      Move(Speed);  
      Death(HealthPoint);
      
    }
}
