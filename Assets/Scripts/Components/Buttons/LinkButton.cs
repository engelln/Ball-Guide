using UnityEngine;
using UnityEngine.UI;

public class LinkButton : MonoBehaviour
{
    [SerializeField] private string Link;

    private Button button;

	private void Start()
	{
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
	}
	
	private void OnClick()
	{
        Application.OpenURL(Link);
	}
}
