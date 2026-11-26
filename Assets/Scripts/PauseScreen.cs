using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    [SerializeField]
    private Animator pauseScreenAnimator;
    [SerializeField]
    private string pauseSound;
    public void ShowPauseScreen()
    {
        SoundManager.instance.Play(pauseSound);
        Pause();
        pauseScreenAnimator.Play("Show", 0, 0f);
    }

    public void HidePauseScreen()
    {
        Resume();
        pauseScreenAnimator.Play("Hide", 0, 0f);
    }
    public void Pause()
    {
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
    }
}
