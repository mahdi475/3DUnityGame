using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleThenNotVisible : MonoBehaviour
{
    public bool canChange = true; //TODO
    private Renderer renderer;
    bool Visible = true;
    float timer = 0f;
    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        YouCanSeeMe();
        timer -= Time.deltaTime; // i have no clue how the other timer thingy works. so if you can make it please do it.
    }

    void YouCanSeeMe() // yes you can deffenetyl improve this code
    {
        if (!canChange) // TODO
        {
            return;
        }

        if(timer > 0) { return; }
        if (Visible)
        {
            renderer.enabled = true;
            timer = 1f;
            Visible = !Visible;
            return;
        }
        if (!Visible)
        {
            renderer.enabled = false;
            timer = 5f;
            Visible = !Visible;
            return;
        }
    }

}
