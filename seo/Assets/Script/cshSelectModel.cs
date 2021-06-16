using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cshSelectModel : MonoBehaviour
{
    public CanvasGroup Alert;
    public bool fade_in = false, fade_out = false;


    public void changeScene_1()
    {
        if (GameObject.Find("SceneNumber").GetComponent<cshSceneState>().state == 1)
        {
            Alert.GetComponent<cshAlertFade>().SetText(true);
            Alert.gameObject.SetActive(true);
            Alert.GetComponent<cshAlertFade>().startFadeIn();
        }

        else
        {
            Alert.GetComponent<cshAlertFade>().SetText(false);
            Alert.gameObject.SetActive(true);
            Alert.GetComponent<cshAlertFade>().startFadeIn();
            Invoke("changeScene1", 1.0f);
        }
    }
    public void changeScene_2()
    {
        if (GameObject.Find("SceneNumber").GetComponent<cshSceneState>().state == 2)
        {
            Alert.GetComponent<cshAlertFade>().SetText(true);
            Alert.gameObject.SetActive(true);
            Alert.GetComponent<cshAlertFade>().startFadeIn();
        }

        else
        {
            Alert.GetComponent<cshAlertFade>().SetText(false);
            Alert.gameObject.SetActive(true);
            Alert.GetComponent<cshAlertFade>().startFadeIn();
            Invoke("changeScene2", 1.0f);
        }
    }

    public void changeScene1()
    {
        SceneManager.LoadScene("1stModel");
    }
    public void changeScene2()
    {
        SceneManager.LoadScene("2ndModel");
    }
}
