using UnityEngine;

// used to handle input across different platforms
public class InputManager : Singleton<InputManager>
{
    public static Vector2 WorldPosition { get; private set; }
    public static bool TouchBegan { get; private set; }
    public static bool TouchEnded { get; private set; }
    public static bool Touching { get; private set; }

    private Camera cam;


    private void Start()
    {
        cam = Camera.main;
        UpdateWorldPosition();
        UpdateTouchStatus();
    }

    private void Update()
    {
        UpdateWorldPosition();
        UpdateTouchStatus();
    }

    private void UpdateWorldPosition()
    {
#if !UNITY_EDITOR
        if (Input.touchCount > 0)
            WorldPosition = cam.ScreenToWorldPoint(Input.GetTouch(0).position);

#else
        WorldPosition = cam.ScreenToWorldPoint(Input.mousePosition);
#endif
    }

    private void UpdateTouchStatus()
    {
        /* Mobile Controls */
#if !UNITY_EDITOR
        if (Input.touchCount > 0)
        {
            Touching = true;
            switch (Input.GetTouch(0).phase)
            {
                case TouchPhase.Began:
                    TouchBegan = true;
                    TouchEnded = false;
                    break;
                case TouchPhase.Ended:
                    TouchEnded = true;
                    TouchBegan = false;
                    break;
                default:
                    TouchBegan = false;
                    TouchEnded = false;
                    break;
            }
        }
        else
        {
            Touching = false;
            TouchBegan = false;
            TouchEnded = false;
        }
#else
        /* PC Controls */

        if (Input.GetMouseButtonDown(0))
        {
            TouchBegan = true;
            TouchEnded = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            TouchBegan = false;
            TouchEnded = true;
        }
        else
        {
            TouchBegan = false;
            TouchEnded = false;
        }

        if (Input.GetMouseButton(0))
        {
            Touching = true;
        }
        else
        {
            Touching = false;
        }
#endif
    } 
}
