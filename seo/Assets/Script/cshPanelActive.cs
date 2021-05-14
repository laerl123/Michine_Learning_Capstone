using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshPanelActive : MonoBehaviour
{
    private bool state;
    // Start is called before the first frame update
    void Start()
    {
        state = false;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void Activating()
    {
        if (state)
            gameObject.SetActive(state = false);

        else
            gameObject.SetActive(state = true);
    }

}
