using UnityEngine;

[CreateAssetMenu(fileName ="Theme", menuName = "Theme")]
public class Theme : ScriptableObject
{
    public Color background;
    public Color ball;
    public Color text;
    public Color line;
    public Color start;
    public Color finish;
    public Color guide;

    public Font font;
    public Font title;
}
