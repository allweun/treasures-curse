using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FirstLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Image loadimage;
    private void Start()
    {
        StartCoroutine(LoadAsyncOperation());
    }
    IEnumerator LoadAsyncOperation()
    {
        yield return new WaitForSeconds(1);
        loadimage.fillAmount = 0.2f;
        yield return new WaitForSeconds(1);
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
        while (operation.progress < 1)
        {
            loadimage.fillAmount = 0.2f + operation.progress;
            yield return new WaitForEndOfFrame();
        }
    }
}
