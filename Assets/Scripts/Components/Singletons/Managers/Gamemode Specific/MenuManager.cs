using UnityEngine;

public class MenuManager : ModeManager
{
    public Ball ball;


	private void Start()
	{
        LoadNextLevel();
	}

    private void LoadNextLevel()
    {
        MaterialManager.Inst.ResetMaterials();
        LineManager.Inst.ClearLines();
        ChuteSpawner.Inst.RandomizeChuteWidth();
        ChuteSpawner.Inst.SpawnChutes();
        ball.SetUpBall();
        ball.Activate();
    }

    public override void EndLevel()
    {
        LoadNextLevel();
    }

    private void OnDestroy()
    {

    }
}
