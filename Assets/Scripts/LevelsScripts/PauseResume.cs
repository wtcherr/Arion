using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResume : MonoBehaviour
{
    public GameObject pauseScreen;
    private static bool paused;
    public KeyCode pauseBtn;

    // Update is called once per frame
    void Start(){
        paused=false;
        pauseScreen.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(pauseBtn) && paused){
            resume();
        }else if(Input.GetKeyDown(pauseBtn) && !paused){
            pause();
        }
        if(paused)Time.timeScale=0;
        else Time.timeScale=1;
    }
    public void resume(){
        pauseScreen.SetActive(false);
        paused=false;
        Time.timeScale=1;
    }
    public void pause(){
        pauseScreen.SetActive(true);
        paused=true;
        Time.timeScale=0;
    }
    public void quit(){
        new NavigationController().Quit();
    }
}
