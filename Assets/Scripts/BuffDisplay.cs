using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuffDisplay : MonoBehaviour, DragListener
{
    public Buff buff = new SampleBuff();
    private Drag drag;


    // Start is called before the first frame update
    void Start()
    {
        drag = GetComponent<Drag>();
        drag.RegisterListener(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBeginDrag()
    {
        Debug.Log("Begin Drag");
    }

    public void OnEndDrag()
    {
        Debug.Log("End Drag");
    }

    public void PlayAnimation()
    {
        Debug.Log("Play Animation");
    }
}
