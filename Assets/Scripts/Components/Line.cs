using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// used to run each line during the game
[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRederer;
    [SerializeField] private EdgeCollider2D edgeCol;

    private List<Vector2> points;


    private void Start()
    {
        LineManager.Inst.RegisterActiveLine(this);
    }

    private void Update()
    {
        if (InputManager.TouchEnded)
        {
            if (points.Count < 2)
            {
                Destroy(gameObject);
                MaterialManager.Inst.AddMaterial(1);
            }

        }
    }

    public void UpdateLine(Vector2 pos)
    {
        if (points == null)
        {
            points = new List<Vector2>();
            SetPoint(pos);
            return;
        }

        if (Vector2.Distance(points.Last(), pos) > .1f)
        {
            SetPoint(pos);
        }
	}

    private void SetPoint(Vector2 point)
    {
        points.Add(point);

        lineRederer.positionCount = points.Count;
        lineRederer.SetPosition(points.Count - 1, point);

        if(points.Count > 1)
        {
            edgeCol.points = points.ToArray();
        }

        MaterialManager.Inst.SubtractMaterial();
    }

    public int Materials { get { return points.Count; } }
}
