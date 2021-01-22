using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    private static bool created;


	private void Awake()
	{
        if (!created)
        {
            created = true;
            DontDestroyOnLoad(gameObject);
        }

        //SceneManager.activeSceneChanged += SceneChange;
	}

    private void SceneChange(Scene newScene, Scene oldScene)
    {
        if(newScene.name != "Game")
        {
            Destroy(gameObject);
        }
    }



}
