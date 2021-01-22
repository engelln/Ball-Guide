using UnityEngine;

public abstract class ModeManager : Singleton<ModeManager>
{
    // superclass for different gamemodes.
    // Each mode has a score, line manager, ball
    //public GameObject gameMenu;

    protected bool paused, currentLevelWon, continued;

    public virtual void StartLevel() { }
    public virtual void WinCurrentLevel() { }
    public virtual void EndLevel() { }
    public virtual void RestartGame() { }
    public virtual void ContinueGame() { }
    public virtual void PauseGame() { }
    public virtual void UnPauseGame() { }

    public bool Continued { get { return continued; } }


}
