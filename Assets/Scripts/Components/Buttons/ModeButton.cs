using UnityEngine;
using UnityEngine.UI;

public class ModeButton : GameButton
{
     [SerializeField] private Text buttonText;
     [SerializeField] private string placeText = "Place";
     [SerializeField] private string eraseText = "Erase";


    private void Start()
    {
        SetText();
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        LineManager.Inst.SwitchDrawMode();
        SetText();
    }

    private void SetText()
    {
        switch (LineManager.Inst.CurrentMode)
        {
            case DrawMode.Place: buttonText.text = placeText; break;
            case DrawMode.Erase: buttonText.text = eraseText; break;
        }
    }

}
