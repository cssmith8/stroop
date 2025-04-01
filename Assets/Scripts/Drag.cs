using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface DragListener
{
    void OnBeginDrag();
    void OnEndDrag();
    void DuringDragUpdate();
}

public class Drag : MonoBehaviour, IDragHandler
{
    private Canvas canvas;
    private bool isDraggingNow = false;
    public bool draggable = true;
    private bool draggabilityPaused = false;
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

    public void PauseDraggability()
    {
        draggabilityPaused = true;
    }

    public void ResumeDraggability()
    {
        draggabilityPaused = false;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (draggable && !draggabilityPaused)
        {
            if (!isDraggingNow)
            {
                isDraggingNow = true;
                listeners.ForEach(listener => listener.OnBeginDrag());
                StartCoroutine(DragCoroutine());
            }
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    private IEnumerator DragCoroutine()
    {
        while (Input.GetKey(KeyCode.Mouse0))
        {
            listeners.ForEach(listener => listener.DuringDragUpdate());
            yield return null;
        }
        isDraggingNow = false;
        listeners.ForEach(listener => listener.OnEndDrag());
    }
}
