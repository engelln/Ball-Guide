using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayGamemodeButton : MonoBehaviour
{
    [SerializeField] private string SceneName;

	private void Start()
	{
        GetComponent<Button>().onClick.AddListener(OnClick);
	}
	
	private void OnClick()
	{
        SceneManager.LoadScene(SceneName);
	}
}
