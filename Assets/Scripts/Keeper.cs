
using TMPro;
using UnityEngine;

public class Keeper : MonoBehaviour
{
    [SerializeField] private TMP_Text _recordScores;
    [SerializeField] private TMP_Text _walletCount;
    public static int WalletCount;
    public static int Scores ;
    private int _highScores=0;
    
    private void Start()
    {
      Scores=0;
      WalletCount=0;
    }

   private void Update()
    {
      _walletCount.text = WalletCount.ToString();
      Consevation();
    }
    private void Consevation()
    {
         _highScores = Scores;  
     
       if(PlayerPrefs.GetFloat("Score") <= _highScores)       
          PlayerPrefs.SetFloat("Score",_highScores);
    
         _recordScores.text = PlayerPrefs.GetFloat("Score").ToString();
    }
}

