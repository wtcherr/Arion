using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationController: MonoBehaviour
{
    public void GoToScene(int sceneBuildIndex){
        Scene scene=SceneManager.GetSceneByBuildIndex(sceneBuildIndex);
        SceneManager.LoadScene(sceneBuildIndex,LoadSceneMode.Single);
    }
    public void Quit(){
        Application.Quit();
    }
}
