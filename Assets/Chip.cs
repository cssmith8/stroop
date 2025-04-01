using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chip : MonoBehaviour, DragListener
{
    //private Material m_Material;
    private Drag drag;

    public Upgrade chipType = Upgrade.BLUE;
    // Start is called before the first frame update
    void Start()
    {
        //m_Material = GetComponent<Image>().material;
        drag = GetComponent<Drag>();
        drag.RegisterListener(this);
        drag.draggable = false;
    }

    // Update is called once per frame
    void Update()
    {
        //vector between the chip and the mouse
        //Vector2 direction = (Vector2)Input.mousePosition - (((Vector2)transform.position + new Vector2(8.9f, 5f)) * (Screen.height / 10f));
        //Debug.Log(((Vector2)transform.position + new Vector2(8.9f, 5f)) * (Screen.height / 10f));
        //m_Material.SetVector("_Direction", direction);
    }

    public void SetDraggable(bool value)
    {
        drag.draggable = value;
    }

    public void OnBeginDrag()
    {

    }

    public void OnEndDrag()
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

        BuffDisplay other = BuffSidebar.instance.GetBuffDisplayOnAnchor(closestAnchor);
        if (other == null || other.buff.TotalUpgrades() >= 3)
        {
            StartCoroutine(GoToGameObject(transform.parent.gameObject));
        }
        else
        {
            AttachToBuff(other.gameObject);
        }
    }

    private void AttachToBuff(GameObject display)
    {
        StartCoroutine(GoToGameObject(display));
        bool added = display.GetComponent<BuffDisplay>().buff.AddUpgrade(chipType);
        if (!added) Debug.Log("Failed to apply chip");
        Destroy(gameObject);
    }

    IEnumerator GoToGameObject(GameObject a)
    {
        //go to the display
        drag.PauseDraggability();
        transform.SetParent(a.transform);
        while (Vector2.Distance(transform.position, a.transform.position) > 0.02f)
        {
            transform.position = Vector2.Lerp(transform.position, a.transform.position, Mathf.Clamp(Time.deltaTime * 8f, 0f, 1f - Time.deltaTime * 2f) + Time.deltaTime * 2f);
            yield return null;
        }
        transform.position = a.transform.position;
        drag.ResumeDraggability();
    }

    public void DuringDragUpdate()
    {
        //m_Material.SetVector("_Direction", direction);
    }
}
