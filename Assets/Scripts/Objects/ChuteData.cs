using UnityEngine;

// used to hold data for creating a chute
public class ChuteData
{
    private int wall;
    private float rotation;
    private Vector3 position;
    private Vector2 limits;

    public ChuteData(int wall, float rotation, Vector3 position, Vector2 limits)
    {
        this.wall = wall;
        this.rotation = rotation;
        this.position = position;
        this.limits = limits;
    }

    public int Wall { get { return wall; } }
    public float Rotation { get { return rotation; } }
    public Vector3 Position { get { return position; } }
    public Vector2 Limits { get { return limits; } }
    public float LowerLimit { get { return limits.x; } }
    public float UpperLimit { get { return limits.y; } }

}
