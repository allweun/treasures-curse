using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public Image loadimage;
    public void LoadThisLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsyncOperation(sceneIndex));
    }
    IEnumerator LoadAsyncOperation(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (operation.progress < 1)
        {
            loadimage.fillAmount = operation.progress;
            yield return new WaitForEndOfFrame();
        }
    }

}
