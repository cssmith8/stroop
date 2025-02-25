using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface DragListener
{
    void OnBeginDrag();
    void OnEndDrag();
}

public class Drag : MonoBehaviour, IDragHandler
{
    private Canvas canvas;
    private bool isDraggingNow = false;
    public bool draggable = true;
    private RectTransform rectTransform;
    private List<DragListener> listeners = new();

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GameObject.FindGameObjectWithTag("GameCanvas").GetComponent<Canvas>();
    }

    public void RegisterListener(DragListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(DragListener listener)
    {
        listeners.Remove(listener);
    }

    public bool isDragging()
    {
        return isDraggingNow;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (draggable)
        {
            if (!isDraggingNow)
            {
                isDraggingNow = true;
                foreach (DragListener listener in listeners)
                {
                    listener.OnBeginDrag();
                }
                StartCoroutine(DragCoroutine());
            }
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    private IEnumerator DragCoroutine()
    {
        while (Input.GetKey(KeyCode.Mouse0))
        {
            yield return null;
        }
        isDraggingNow = false;
        foreach (DragListener listener in listeners)
        {
            listener.OnEndDrag();
        }
    }
}
