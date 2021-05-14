using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cshSelectModel : MonoBehaviour
{ 
    public void changeScene_1()
    {
        GameObject.Find("Global").GetComponent<cshSceneState>().state = 1;
        SceneManager.LoadScene("1stModel");
    }
    public void changeScene_2()
    {
        GameObject.Find("Global").GetComponent<cshSceneState>().state = 2;
        SceneManager.LoadScene("2ndModel");
    }
    public void changeScene_3()
    {
        GameObject.Find("Global").GetComponent<cshSceneState>().state = 3;
        SceneManager.LoadScene("3rdModel");
    }
    public void changeScene_select()
    {
        SceneManager.LoadScene("SelectModelScene");
    }
    public void changeScene_back()
    {
       switch(GameObject.Find("Global").GetComponent<cshSceneState>().state)
        {
            case 1:
                SceneManager.LoadScene("1stModel");
                break;
            case 2:
                SceneManager.LoadScene("2ndModel");
                break;
            case 3:
                SceneManager.LoadScene("3rdModel");
                break;
            default:
                break;
        }
    }

}
