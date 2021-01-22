using UnityEngine;
using UnityEngine.UI;

public class DescriptionButton : MonoBehaviour
{
    public GameObject description;

	private void Start()
	{
        GetComponent<Button>().onClick.AddListener(OnClick);
	}

    private void OnClick()
    {
        Time.timeScale = 0;
        description.SetActive(true);
    }
	

}
