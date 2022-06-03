using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // refazer esse codigo.
    Animator anim;
    CanvasGroup groupCanvas;
    public bool IsOpen
    {
        get { return anim.GetBool("IsOpen"); }
        set { anim.SetBool("IsOpen", value); }
    }
    public void Awake()
    {
        anim = GetComponent<Animator>();
        groupCanvas = GetComponent<CanvasGroup>();

        var rect = GetComponent<RectTransform>();
        rect.offsetMax = rect.offsetMin = new Vector2(0, 0);

    }

    public void Update()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Open"))
        {
            groupCanvas.blocksRaycasts = groupCanvas.interactable = false;
        }
        else
        {
            groupCanvas.blocksRaycasts = groupCanvas.interactable = true;
        }
    }
}
