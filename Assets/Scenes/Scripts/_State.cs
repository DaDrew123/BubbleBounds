using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _State : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public bool isPaused;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Pause(){
        if(pauseMenuUI != null){
            // **Add / Show PAUSE menu UI here**
            // Remove or Comment out Debug (placeholder)
            Debug.Log("Game Paused!");
            pauseMenuUI.SetActive(true);
        }
        Time.timeScale=0f;
        isPaused = true;
        
    }
    public void Resume(){
        if(pauseMenuUI != null){
            // ** Remove / Hide PAUSE menu UI here **
            // Remove or Comment out Debug (placeholder)
            Debug.Log("Game Resume!");
            pauseMenuUI.SetActive(false);
        }
        Time.timeScale=1f;
        isPaused=false;
        
    }

}
