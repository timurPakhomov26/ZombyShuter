using System;
using UnityEngine;

public class EventManager 
{
    public delegate float MyDelegate(Transform damage);
    public static Action OnZombyTakeFinish;
    public static Action OnEmptyStore;
    public static Action OnGetRecord;
    public static Action OnCoinsToWallet;
    
    

    public static void HealthPointsDecrease() => OnZombyTakeFinish?.Invoke();
    public static void AddBullets() => OnEmptyStore?.Invoke();
    public static void GetRecord() => OnGetRecord?.Invoke();
    public static void CreateAnimation() => OnCoinsToWallet?.Invoke();
   
}
