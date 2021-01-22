using UnityEngine;

public class ThemeSetter : MonoBehaviour
{
    private Theme theme;

	private void Start()
	{
        theme = GameManager.Inst.CurrentTheme;
        SetColor(tag);
        
	}

    // camera
    // ball
    // lines
    // guides
    // chutes
    private void SetColor(string tag)
    {
        switch (tag)
        {
            case "OverrideColor":
                break;
            case "MainCamera":
                GetComponent<Camera>().backgroundColor = theme.background; break;
            case "Ball":
                GetComponent<SpriteRenderer>().color = theme.ball; break;
            case "PlayerLine":
                GetComponent<LineRenderer>().material.color = theme.line; break;
            case "Guide":
                foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
                {
                        //sr.color = theme.guide;
                }
                break;
            case "Start":
                foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
                {
                    if(sr != null)
                        sr.color = theme.start;
                }
                break;
            case "Finish":
                foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
                {
                    if(sr != null)
                        sr.color = theme.finish;
                }
                break;
            case null:
                print("error"); break;

        }
    }
}
