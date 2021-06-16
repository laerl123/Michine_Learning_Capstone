using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshPanelActive : MonoBehaviour
{
    private bool state = false;
    private bool all_active = false;
    private bool popup, popdown;
    private float scale = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        if (popup)
        {
            this.transform.localScale = new Vector2(scale, scale);
            scale += Time.deltaTime / 0.1f;
            if (scale >= 1.0f)
            {
                this.transform.localScale = new Vector2(1.0f, 1.0f);
                scale = 1.0f;
                state = true;
                popup = false;
            }
        }
        else if (popdown)
        {
            this.transform.localScale = new Vector2(scale, scale);
            scale -= Time.deltaTime / 0.1f;
            if (scale <= 0.0f)
            {
                this.transform.localScale = new Vector2(0.0f, 0.0f);
                scale = 0.0f;
                state = false;
                gameObject.SetActive(state = false);
                popdown = false;
            }
        }
    }

    // Update is called once per frame
    public void Activating()
    {
        if (state)
        {
            Debug.Log("종료");
            popdown = true;
        }

        else
        {
            gameObject.SetActive(true);
            Debug.Log("실행");
        }
    }

    public void AllActivating()
    {
        if (all_active)
        {
            if (state)
                popdown = true;

            all_active = false;
        }

        else
        {
            if(!state)
                gameObject.SetActive(true);

            all_active = true;
        }
    }

    private void OnEnable()
    {
        Debug.Log("켜짐");
        popup = true;
    }

    /*private void OnDisable()
    {
        popdown = true;
    }*/

}
