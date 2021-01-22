using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Theme[] themes;
    private Theme currentTheme;
    public GameMode currentMode;


    private void Start()
    {
        currentTheme = themes[0];
        currentMode = GameMode.Menu;
    }

    public Theme CurrentTheme { get { return currentTheme; } }
    public GameMode CurrentMode { get; set; }

}
