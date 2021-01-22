using UnityEngine;

// used to spawn each chute at the start of a game
public class ChuteSpawner : Singleton<ChuteSpawner>
{
    [SerializeField] private GameObject startChute;
    [SerializeField] private GameObject finishChute;
    [SerializeField] private GameObject bar;
    [SerializeField] private float verticalWallSpawnOffset = .25f;
    [SerializeField] private float horizontalWallSpawnOffset = 5.3f;
    [SerializeField] private float defaultChuteWidth = 0.8f;

    private ChuteData startData, finishData;
    private GameObject start, finish;
    private float chuteHalfWidth, xRange, yRangeMin, yRangeMax, chuteWidth;

    private void Start()
    {
        chuteWidth = defaultChuteWidth;
    }



    // destroys any active chutes and spawns new ones
    public void SpawnChutes()
    {
        if (finish == null)
            DetermineValues(finishChute);
        else
            DetermineValues(finish);
        DestroyChutes();
        SpawnStart();
        SpawnFinish();
    }

    private void DetermineValues(GameObject chute)
    {
        ChuteSpawnValueCalculator.Inst.CalculateChuteHalfWidth(chute);
        ChuteSpawnValueCalculator.Inst.CalculateXRange();
        ChuteSpawnValueCalculator.Inst.CalculateYRange();
        chuteHalfWidth = ChuteSpawnValueCalculator.Inst.ChuteHalfWidth;
        xRange = ChuteSpawnValueCalculator.Inst.XRange;
        yRangeMin = ChuteSpawnValueCalculator.Inst.YRangeMin;
        yRangeMax = ChuteSpawnValueCalculator.Inst.YRangeMax;
    }

    // destroys the active chutes
    private void DestroyChutes()
    {
        if(start != null) { Destroy(start); }
        if(finish != null) { Destroy(finish); }
    }

    // generates random data for the start and creates it
    private void SpawnStart()
    {
        startData = CreateChuteData();
        start = Instantiate(startChute, startData.Position, Quaternion.Euler(new Vector3(0, 0, startData.Rotation)));
    }

    // generates random data for the finish and creates it as long as it is not touching the start
    private void SpawnFinish()
    {
        finishData = CreateChuteData();
        if (finishData.Wall == startData.Wall)
        {
            // if the upper or lower limits of the finish are within the bounds of the upper and lower limits of the start redraw
            while ((startData.LowerLimit <= finishData.LowerLimit && finishData.LowerLimit <= startData.UpperLimit) || 
                (startData.LowerLimit <= finishData.UpperLimit && finishData.UpperLimit <= startData.UpperLimit))
            {
                finishData = CreateChuteData();
            }
        }
        finish = Instantiate(finishChute, finishData.Position, Quaternion.Euler(new Vector3(0, 0, finishData.Rotation)));
    }

    // generates random data for spawning
    private ChuteData CreateChuteData()
    {
        int wall = Random.Range(0, 4);
        float rotation = GetRotation(wall);
        Vector3 pos = GetPosition(wall);
        Vector2 limits = GetLimits(wall, pos);
        return new ChuteData(wall, rotation, pos, limits);
    }

    private float GetRotation(int wall)
    {
        switch (wall)
        {
            case 0: return 90f;
            case 1: return 0f;
            case 2: return -90f;
            case 3: return 180f;
            default: return 0f;
        }
    }

    private Vector3 GetPosition(int wall)
    {
        float x = GetX(wall);
        float y = GetY(wall);
        return new Vector3(x, y, 0f);
    }

    private float GetX(int wall)
    {
        switch (wall)
        {
            case 0: case 2: return Random.Range(-xRange, xRange);
            case 1: return Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x + verticalWallSpawnOffset;
            case 3: return Camera.main.ScreenToWorldPoint(Vector2.zero).x - verticalWallSpawnOffset;
            default: return 0f;
        }
    }

    private float GetY(int wall)
    {
        switch (wall)
        {
            case 0: return Camera.main.ScreenToWorldPoint(bar.transform.position).y + .25f;
            case 1: case 3: return Random.Range(yRangeMin, yRangeMax);
            case 2: return -horizontalWallSpawnOffset;
            default: return 0f;
        }
    }

    private Vector2 GetLimits(int wall, Vector3 position)
    {
        float lower = 0f;
        float upper = 0f;
        if(wall == 0 || wall == 2)
        {
            lower = position.x - chuteHalfWidth;
            upper = position.x + chuteHalfWidth;
        }
        if(wall == 1 || wall == 3)
        {
            lower = position.y - chuteHalfWidth;
            upper = position.y + chuteHalfWidth;
        }
        return new Vector2(lower, upper);
    }

    public void DecreaseChuteWidth()
    {
        if (chuteWidth > 0.21f)
        {
            chuteWidth -= 0.02f;
        }
        if(ScoreManager.Inst.Score % 50 == 0)
        {
            chuteWidth = .15f;
        }
    }

    public void RandomizeChuteWidth()
    {
        chuteWidth = Random.Range(.15f, .8f);
    }

    public void ResetChuteWidth()
    {
        chuteWidth = defaultChuteWidth;
    }

    public GameObject StartChute { get { return start; } }
    public GameObject FinishChute { get { return finish; } }
    public float ChuteWidth { get { return chuteWidth; } }
    public float ChuteDistance { get { return Vector3.Distance(start.transform.position, finish.transform.position); } }
    public bool AreWallsSame { get { if(startData.Wall == finishData.Wall) { return true; } else { return false; } } }

}