using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
   [SerializeField] private TMP_Text _timerText;

   [SerializeField] private TMP_Text _recordTime;
   [SerializeField] private TMP_Text _bullets;
   [SerializeField] private GameObject _losePanel;
   [SerializeField] private TMP_Text _coinsWalletCount;
   private Animation _coinsWalletAnimation;
    private float _coinsCount;
    private Enemy[] _zombyes;
    private Image _healthPoint;
    private float _healthPointCount = 1;
    private StockOfBullets _stockOfBullets = new StockOfBullets();    
    
   private void OnEnable() 
     {
      EventManager.OnZombyTakeFinish += HealthPointDescrease;
      EventManager.OnCoinsToWallet += StartAnim;
     }
     private void OnDisable()
      {
       EventManager.OnZombyTakeFinish -= HealthPointDescrease; 
       EventManager.OnCoinsToWallet -= StartAnim;
     }
     
   private void Start()
   {      
      Time.timeScale=1;       
      _losePanel.SetActive(false);     
      _healthPoint = GameObject.Find("Bar").GetComponent<Image>(); 
      _coinsWalletAnimation= GameObject.Find("CoinsWallet").GetComponentInChildren<Animation>();    
      StartCoroutine(TimeFlow());   
   }
   private void Update()
    {          
      ShowElements();
       LoseGame();     
    }
   IEnumerator TimeFlow()
   {
      while(true)
       {                          
         Keeper.Scores++;
          _timerText.text =  Keeper.Scores.ToString("D2");
          yield return new WaitForSeconds(1f);
       }
   }
   private void ShowElements()
   {
     _healthPoint.fillAmount = _healthPointCount;
      _recordTime.text = _timerText.text;
       _bullets.text = _stockOfBullets.BulletsCount.ToString();
   }
  
   public void HealthPointDescrease()
   {
      _healthPointCount -= 0.21f;     
   }
   private void LoseGame()
   {
       if(_healthPointCount <= 0)
       {
          Time.timeScale=0;
        _healthPointCount=0;
         _losePanel.SetActive(true); 
         _zombyes = FindObjectsOfType<Enemy>();                    
       }     
   }
   public void OnClickReload()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
   
  private void StartAnim()
  {
     Keeper.WalletCount ++;
     _coinsWalletAnimation.Play();
  } 
}
