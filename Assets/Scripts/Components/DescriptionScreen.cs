using UnityEngine;

public class DescriptionScreen : MonoBehaviour
{
	
	private void Update()
	{
        if (InputManager.TouchBegan)
        {
            gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
	}
}
