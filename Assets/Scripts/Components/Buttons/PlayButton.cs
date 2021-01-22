using UnityEngine;

public class PlayButton : GameButton
{
    private void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        ModeManager.Inst.StartLevel();
    }

    private void OnEnable()
    {
        button.enabled = true;
    }
}
