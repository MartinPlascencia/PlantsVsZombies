using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System.Collections;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onSceneStart;
    [SerializeField]
    private Animator fade;
    [SerializeField]
    private string fadeAnimationName = "FadeOut";
    private void Start()
    {
        onSceneStart?.Invoke();
    }
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        fade.Play(fadeAnimationName);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}
