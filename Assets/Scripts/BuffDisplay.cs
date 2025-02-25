using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuffDisplay : MonoBehaviour, DragListener
{
    public GameObject anchor;
    public Buff buff = new SampleBuff();
    private Drag drag;


    // Start is called before the first frame update
    void Start()
    {
        drag = GetComponent<Drag>();
        drag.RegisterListener(this);
        anchor = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBuffRearrange()
    {
        StartCoroutine(BuffRearrange());
    }

    public void EndBuffRearrange()
    {
        StopCoroutine(BuffRearrange());
    }

    private IEnumerator BuffRearrange()
    {
        BuffSidebar bs = BuffSidebar.instance;
        while (bs.rearranging)
        {
            //Debug.Log(Time.time);
            yield return new WaitForSeconds(0.25f);
        }
    }

    public void OnBeginDrag()
    {
        //Debug.Log("Begin Drag");
        BuffSidebar.instance.StartBuffRearrange(gameObject);
    }

    public void OnEndDrag()
    {
        //Debug.Log("End Drag");
        BuffSidebar.instance.rearranging = false;
        StartCoroutine(ReturnToAnchor());
    }

    private IEnumerator ReturnToAnchor()
    {
        bool dragFlag = drag.draggable;
        drag.draggable = false;
        while (Vector2.Distance(transform.position, anchor.transform.position) > 0.04f)
        {
            transform.position = Vector2.Lerp(transform.position, anchor.transform.position, Mathf.Clamp(Time.deltaTime * 8f, 0f, 0.9f) + Time.deltaTime);
            yield return null;
        }
        transform.position = anchor.transform.position;
        drag.draggable = dragFlag;
    }

    public void PlayAnimation()
    {
        Debug.Log("Play Animation");
    }
}
