using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trans : MonoBehaviour
{
    public void OnClickCatch()
    {
        SceneManager.LoadScene("Trans_Catch");
    }
    public void OnClickPlot()
    {
        SceneManager.LoadScene("Trans_Plot");
    }
    public void OnClickPlot1()
    {
        SceneManager.LoadScene("Plot1");
    }
    public void OnClickExit()
    {
        SceneManager.LoadScene("Trans_Main");
        
    }

}
