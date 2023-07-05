using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    //Main Menu
        public void OnPlayButtonClick()
        {
            SceneManager.LoadScene("Game1");
        }
    
        public void OnSettingsButtonClick()
        {
            SceneManager.LoadScene("SettingsScene");
        }
    
        public void OnQuitButtonClick()
        {
    #if !UNITY_EDITOR
            Application.Quit();
    #else
            UnityEditor.EditorApplication.isPlaying = false;
    #endif
        }

}
