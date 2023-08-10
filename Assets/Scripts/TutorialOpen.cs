using UnityEngine;
using UnityEngine.SceneManagement;
public class TutorialOpen : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.HasKey(TreasureCurseConst.TutorialKey) != false)
            return;
        SceneManager.LoadScene(TreasureCurseConst.TutorialKey);
        PlayerPrefs.Save();
    }
}
