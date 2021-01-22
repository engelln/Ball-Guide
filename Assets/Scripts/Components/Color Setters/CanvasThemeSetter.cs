using UnityEngine;
using UnityEngine.UI;

public class CanvasThemeSetter : MonoBehaviour
{
    private Theme theme;

	private void Start()
	{
        theme = GameManager.Inst.CurrentTheme;
        SetTheme();
	}
	
	private void SetTheme()
	{
        Text[] texts = GetComponentsInChildren<Text>(true);
        foreach(Text text in texts)
        {
            if(text.tag == "OverrideFont")
            {
                continue;
            }
            if(text.tag == "Title")
            {
                text.font = GameManager.Inst.CurrentTheme.title;
            }
            else
            {
                text.font = theme.font;
            }
            text.color = theme.text;
        }

        Image[] images = GetComponentsInChildren<Image>(true);
        foreach(Image img in images)
        {
            if(img.tag == "Background")
            {
                img.color = theme.background;
            }
            else if(img.tag == "Foreground")
            {
                img.color = theme.line;
            }
        }


	}
}
