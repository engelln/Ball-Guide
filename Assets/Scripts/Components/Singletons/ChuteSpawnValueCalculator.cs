using System;
using UnityEngine;

// Calculates values needed to randomly spawn chutes
public class ChuteSpawnValueCalculator : Singleton<ChuteSpawnValueCalculator>
{
    [SerializeField] private GameObject chute;
    [SerializeField] private GameObject bar;
    [SerializeField] private float chuteExtension = .3f;

    private float xRange;
    private float yRangeMin;
    private float yRangeMax;
    private float chuteHalfWidth;

    public float XRange { get { return xRange; } }
    public float YRangeMin { get { return yRangeMin; } }
    public float YRangeMax { get { return yRangeMax; } }
    public float ChuteHalfWidth { get { return chuteHalfWidth; } }

    private void Start()
    {
        CalculateChuteHalfWidth(chute);
        CalculateXRange();
        CalculateYRange();
    }

    public void CalculateChuteHalfWidth(GameObject chute)
    {
        float wallWidth = 0f;
        float wallScale = 0f;

        foreach (Transform child in chute.transform)
        {
            if (child.name == "Wall 1")
            {
                wallWidth = child.localPosition.y;
                wallScale = child.localScale.y; break;
            }
        }
        chuteHalfWidth = (wallWidth * 2 + wallScale) / 2f;
    }

    public void CalculateXRange()
    {
        xRange = Mathf.Abs(Camera.main.ScreenToWorldPoint(Vector2.zero).x + chuteHalfWidth + chuteExtension);
    }

    public void CalculateYRange()
    {
        yRangeMin = Camera.main.ScreenToWorldPoint(Vector2.zero).y + chuteHalfWidth + chuteExtension;
        yRangeMax = Camera.main.ScreenToWorldPoint(bar.transform.position).y - chuteHalfWidth - chuteExtension;
    }


}
