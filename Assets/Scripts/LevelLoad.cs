using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    [SerializeField] private int sceneIndex;
    public void OnSceneLoad()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
