
using UnityEngine;

public class Aim : MonoBehaviour
{
   [SerializeField] private GameObject _aim;
    [SerializeField] private Transform _aimHelper;

    
   private void Start()
    {
        _aim.SetActive(false);
    }
  private void Update()
    {
        Activate();
    }

    private void Activate()
    {
      Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
	  	_aimHelper.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x,mousePos.y,10f));
        _aim.transform.position = new Vector3(Mathf.Clamp(_aimHelper.transform.position.x,-2f,2f),
        Mathf.Clamp(_aimHelper.transform.position.y,-2.4f,0f),10f);

		if (Input.GetMouseButton(0))		
			_aim.SetActive(true);

    else
        _aim.SetActive(false);	
   }	
}
