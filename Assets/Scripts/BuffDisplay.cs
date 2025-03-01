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

    public void OnBeginDrag()
    {
        //Debug.Log("Begin Drag");
        //BuffSidebar.instance.StartBuffRearrange(gameObject);
    }

    public void DuringDragUpdate()
    {
        List<GameObject> anchors = BuffSidebar.instance.GetAllAnchors();
        //find the closest anchor
        GameObject closestAnchor = anchors[0];
        float minDistance = Vector2.Distance(transform.position, closestAnchor.transform.position);
        foreach (GameObject a in anchors)
        {
            float distance = Vector2.Distance(transform.position, a.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestAnchor = a;
            }
        }
        if (anchor != closestAnchor)
        {
            BuffDisplay other = BuffSidebar.instance.GetBuffDisplayOnAnchor(closestAnchor);
            if (other != null)
            {
                SwapAnchors(other);
                other.AfterSwapAnchor();
            }
            else
            {
                anchor = closestAnchor;
            }
        }
    }

    public void SwapAnchors(BuffDisplay other)
    {
        GameObject temp = other.anchor;
        other.anchor = anchor;
        anchor = temp;

        other.transform.SetParent(other.anchor.transform);
        transform.SetParent(anchor.transform);
    }

    public void OnEndDrag()
    {
        //Debug.Log("End Drag");
        BuffSidebar.instance.rearranging = false;
        //if  the coroutine is not already running

        StartCoroutine(ReturnToAnchor());
    }

    public void AfterSwapAnchor()
    {
        StartCoroutine(ReturnToAnchor());
    }

    private IEnumerator ReturnToAnchor()
    {
        drag.PauseDraggability();
        while (Vector2.Distance(transform.position, anchor.transform.position) > 0.02f)
        {
            transform.position = Vector2.Lerp(transform.position, anchor.transform.position, Mathf.Clamp(Time.deltaTime * 8f, 0f, 1f - Time.deltaTime * 2f) + Time.deltaTime * 2f);
            yield return null;
        }
        transform.position = anchor.transform.position;
        drag.ResumeDraggability();
    }

    public void PlayAnimation()
    {
        Debug.Log("Play Animation");
    }
}
