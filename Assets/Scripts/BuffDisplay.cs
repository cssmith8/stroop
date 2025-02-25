using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffDisplay : MonoBehaviour
{
    public Buff buff = new SampleBuff();
    private bool isDragging = false;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if the mouse is over the buff display
        if (isDragging)
        {
            transform.position = offset + Input.mousePosition;
        }
    }

    public void PlayAnimation()
    {
        Debug.Log("Play Animation");
    }

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - Input.mousePosition;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }
}
