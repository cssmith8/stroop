using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSidebar : MonoBehaviour
{
    //singleton
    public static BuffSidebar instance;

    [SerializeField]
    private Transform firstSlot, lastSlot;

    [SerializeField]
    private GameObject anchors, buffAnchor;

    private List<GameObject> buffAnchors = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AddAnchor()
    {
        GameObject newAnchor = Instantiate(buffAnchor, anchors.transform);
        buffAnchors.Add(newAnchor);
        newAnchor.transform.SetParent(anchors.transform);
        newAnchor.transform.localPosition = Vector3.zero;
        UpdateAnchors();
    }

    private void RemoveAnchor()
    {
        if (buffAnchors.Count > 0)
        {
            GameObject anchorToRemove = buffAnchors[buffAnchors.Count - 1];
            buffAnchors.Remove(anchorToRemove);
            Destroy(anchorToRemove);
            UpdateAnchors();
        }
    }

    private void UpdateAnchors()
    {
        for (int i = 0; i < buffAnchors.Count; i++)
        {
            GameObject anchor = buffAnchors[i];
            if (i == 0)
            {
                anchor.transform.position = firstSlot.position;
            }
            else if (i == buffAnchors.Count - 1)
            {
                anchor.transform.position = lastSlot.position;
            }
            else
            {
                anchor.transform.position = Vector3.Lerp(firstSlot.position, lastSlot.position, (float)i / (buffAnchors.Count - 1));
            }
        }
    }
}
