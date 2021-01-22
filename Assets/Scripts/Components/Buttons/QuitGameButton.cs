using UnityEngine;
using UnityEngine.UI;

public class QuitGameButton : MonoBehaviour
{
	private void Start()
	{
        GetComponent<Button>().onClick.AddListener(OnClick);
	}
	
	private void OnClick()
	{
        Application.Quit();
	}
}
