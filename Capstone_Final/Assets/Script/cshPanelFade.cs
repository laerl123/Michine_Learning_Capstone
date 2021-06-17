using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshPanelFade : MonoBehaviour
{
    public CanvasGroup Panel;
    public bool fade_in = false, fade_out = false;
    // Start is called before the first frame update
    void Start()
    {
        startFadeOut();
    }

    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (fade_in)
        {
            Debug.Log("페이드인");
            Panel.interactable = true;
            Panel.alpha += Time.deltaTime / 0.1f;
            if (Panel.alpha >= 1.0f)
            {
                fade_in = false;
            }
        }
        else if (fade_out)
        {

            Panel.alpha -= Time.deltaTime / 0.1f;
            if (Panel.alpha <= 0.0f)
            {
                fade_out = false;
                Panel.interactable = false;
                this.gameObject.SetActive(false);
            }
        }
        else
        {

        }
    }

    public void startFadeIn()
    {
        Panel.alpha = 0.0f;
        fade_in = true;

    }

    public void startFadeOut()
    {
        fade_out = true;
    }
}