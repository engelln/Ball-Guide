using UnityEngine;

public class PauseButton : GameButton
{
	private void Start()
	{
        button.onClick.AddListener(OnClick);
	}

    private void OnClick()
    {
        ModeManager.Inst.PauseGame();
    }
	

}
