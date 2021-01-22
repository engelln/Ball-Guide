using UnityEngine;
using UnityEngine.UI;

public class PlayAgainButton : MonoBehaviour
{
    private Button button;

	private void Start()
	{
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
	}

    private void OnClick()
    {
        ModeManager.Inst.RestartGame();
    }
	

}
