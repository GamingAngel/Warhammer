using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    private Image fadeImage;
    private const float fadingTime = 5f;

    private void OnEnable()
    {
        Hero.OnLose += CallFade;
        Flag.OnWin += CallFade;
    }
    private void OnDisable()
    {
        Hero.OnLose -= CallFade;
        Flag.OnWin -= CallFade;
    }


    void Start()
    {
        fadeImage = GetComponent<Image>();
        fadeImage.CrossFadeAlpha(0f, fadingTime, true);
    }

    private void CallFade(int levelIndex) => StartCoroutine(Fade(levelIndex));

    private IEnumerator Fade(int levelIndex)
    {
        fadeImage.raycastTarget = true;
        fadeImage.CrossFadeAlpha(1f, fadingTime, true);
        yield return new WaitForSeconds(fadingTime + 2);
        SceneManager.LoadScene(levelIndex);       
    }
}
