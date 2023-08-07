using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Character player;
    [Header("Panels")]
    public GameObject pausePanel;
    public GameObject controllerUI;
    public GameObject endLevelUI;
    public LevelLoader levelLoader;
    public GameObject TimeCounter;
    public GameObject LoadPanel;
    public GameObject levelSelecter;
    public GameObject settPanel;
    public GameObject quitPanel;
    public GameObject creditsPanel;

    public GameObject menuMainPanel;
    public Image soundOff;
    private bool soundOn;
    public string PrivacyUrl;


    public static bool isGamePaused = false;

    public void OpenPrivacy(){
        Application.OpenURL(PrivacyUrl);
    }
    public void OpenCredits(){
        menuMainPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }
    public void OpenCreditsinUI(){
        creditsPanel.SetActive(true);
    }public void CloseCreditsinUI(){
        creditsPanel.SetActive(false);
    }
    public void BackCredits(){
        creditsPanel.SetActive(false);
        menuMainPanel.SetActive(true);
    }
    public void Start()
    {
        audioMixer.SetFloat("volume", 0);
        soundOn=true;
        levelLoader = FindObjectOfType<LevelLoader>();
        player = FindObjectOfType<Character>();
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void Sound(){
        if(soundOn){
        soundOff.gameObject.SetActive(true);
        audioMixer.SetFloat("volume", -80);
        soundOn=false;
        }else if(!soundOn){
            soundOff.gameObject.SetActive(false);
            audioMixer.SetFloat("volume", 0);
            soundOn=true;
        }
    }



    public void SettingsPanel(){
        pausePanel.SetActive(false);
        settPanel.SetActive(true);

    }

    public void Pause()
    {
        TimeCounter.SetActive(false);
        controllerUI.SetActive(false);
        Time.timeScale = 0f;
        isGamePaused = true;
    }
    public void Resume()
    {
        TimeCounter.SetActive(true);
        controllerUI.SetActive(true);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
    public void BackMenu()
    {
        Time.timeScale = 0f;
        isGamePaused = true;
        SceneManager.LoadScene("Menus");
    }
    public void BackLevelSettings(){
        Time.timeScale=1f;
        menuMainPanel.SetActive(true);
        levelSelecter.SetActive(false);
    }


    public void Quit()
    {
        Application.Quit();
    }

    public void LevelSelection(int sceneIndex)
    {
        LoadPanel.SetActive(true);
        levelSelecter.SetActive(false);
        levelLoader.LoadThisLevel(sceneIndex);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void EndThisLevel()
    {
        Time.timeScale = 0f;
        isGamePaused = true;
        endLevelUI.gameObject.SetActive(true);
    }
    public void CloseUI()
    {
        controllerUI.SetActive(false);
        TimeCounter.SetActive(false);
    }
    public void Replay(int sceneName)
    {
        LoadPanel.SetActive(true);
        SceneManager.LoadSceneAsync(sceneName);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
    public void NextLevel(int SceneIndex)
    {
        CloseUI();
        LoadPanel.SetActive(true);
        SceneManager.LoadSceneAsync(SceneIndex);
        Time.timeScale = 1f;
        isGamePaused = false;
        Resume();
    }
    public void Play()
    {
        //Load and "Save"
    }
    public void BackPause(){
        settPanel.SetActive(false);
        pausePanel.SetActive(true);
    }
    public void SettingsPanelMenu(){
        settPanel.SetActive(true);
    }
    public void BackSettingsMainMenu(){
        settPanel.SetActive(false);
    }
    public bool ReturnPause(){
        return isGamePaused;
    }
    public void BackQuitMenu(){
        quitPanel.SetActive(false);
    }
}
