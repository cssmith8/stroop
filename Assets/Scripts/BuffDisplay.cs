using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuffDisplay : MonoBehaviour, DragListener, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject descPrefab;
    private GameObject activeDesc;
    [HideInInspector]
    public GameObject anchor;
    public Buff buff = new SampleBuff();
    private Drag drag;


    // Start is called before the first frame update
    void Start()
    {
        drag = GetComponent<Drag>();
        drag.RegisterListener(this);
        drag.draggable = false;
        anchor = transform.parent.gameObject;
    }

    public void SetDraggable(bool value)
    {
        drag.draggable = value;
    }

    public void SetBuff(Buff b)
    {
        buff = b;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (BuffSidebar.instance.rearranging) return;
        CreateDesc();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DestroyDesc();
    }

    private void CreateDesc()
    {
        if (activeDesc == null)
        {
            activeDesc = Instantiate(descPrefab, transform.GetChild(0).position, Quaternion.identity);
            activeDesc.transform.SetParent(transform.GetChild(0));
            activeDesc.transform.localPosition = Vector3.zero;
            activeDesc.transform.localScale = Vector3.one;

            activeDesc.GetComponent<BuffDescription>().SetText(buff.GetDescription());
            activeDesc.GetComponent<BuffDescription>().SetChips(buff.upgrades);
        }
    }

    private void DestroyDesc()
    {
        if (activeDesc != null)
        {
            Destroy(activeDesc);
            activeDesc = null;
        }
    }

    public void OnBeginDrag()
    {
        DestroyDesc();
        BuffSidebar.instance.rearranging = true;
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
                transform.SetParent(anchor.transform);
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

    public void SetAnchor(GameObject a)
    {
        anchor = a;
        transform.SetParent(anchor.transform);
    }

    public void OnEndDrag()
    {
        BuffSidebar.instance.rearranging = false;
        StartCoroutine(ReturnToAnchor());
    }

    public void AfterSwapAnchor()
    {
        StartCoroutine(ReturnToAnchor());
    }

    public void BeginReturnToAnchor()
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
        Debug.Log("Buff played animation");
    }
}
