using UnityEngine;

public class ManualChute : MonoBehaviour
{
    public enum Wall { Top, Right, Bottom, Left }
    public Wall wall;
    [Range(0f, 1f)] public float widthPosition;
    [Range(0f, 1f)] public float heightPosition; 

	private void Start()
	{
        float coordinate;
        switch (wall)
        {
            case Wall.Top:
                coordinate = Camera.main.ScreenToWorldPoint(new Vector3(widthPosition * Screen.width, 0, 0)).x;
                transform.position = new Vector3(coordinate, 5.3f, 0f); break;
            case Wall.Bottom:
                coordinate = Camera.main.ScreenToWorldPoint(new Vector3(widthPosition * Screen.width, 0, 0)).x;
                transform.position = new Vector3(coordinate, -5.3f, 0f); break;
            case Wall.Left:
                coordinate = transform.position.y;
                transform.position = new Vector3(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x - .25f, coordinate, 0f); break;
            case Wall.Right:
                coordinate = transform.position.y;
                transform.position = new Vector3(Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x + .25f, coordinate, 0f); break;
        }
	}
	

}
