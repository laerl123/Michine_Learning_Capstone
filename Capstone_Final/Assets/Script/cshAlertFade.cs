using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshAlertFade : MonoBehaviour
{
    public CanvasGroup alert;
    public Text text;
    public bool fade_in = false, fade_out = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        alert.alpha = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (fade_in)
        {
            
            alert.interactable = true;
            alert.alpha += Time.deltaTime/0.3f;
            if (alert.alpha >= 1.0f)
            { 
                fade_in = false;
            }
        }
        else if(fade_out)
        {
            
            alert.alpha -= Time.deltaTime/0.3f;
            if (alert.alpha <= 0.0f)
            {
                fade_out = false;
                alert.interactable = false;
                this.gameObject.SetActive(false);
            }
        }
        else
        {

        }
    }

    public void startFadeIn()
    {
        Invoke("startFadeOut", 2.0f);
        fade_in = true;
        
    }

    public void startFadeOut()
    {
        fade_out = true;
    }

    public void SetText(bool what)
    {
        if (what)
            text.text = "이미 해당 모델이\n열려있습니다.";
        else
            text.text = "모델 변경 중...\n잠시만 기다려주세요.";
    }
}
