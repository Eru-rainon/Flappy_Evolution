using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class viewscores : MonoBehaviour
{
   public Text easyScore;
   public Text medSCore;
   public Text hardScore;

    void Start()
    {
        easyScore.text = "EASY :        "+PlayerPrefs.GetInt("easy",0).ToString();
        medSCore.text = "NORMAL:  "+PlayerPrefs.GetInt("medium",0).ToString();
        hardScore.text = "HARD:        "+PlayerPrefs.GetInt("hard",0).ToString();
        
    }

    public void loadmenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

}
