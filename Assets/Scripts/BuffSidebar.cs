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

    private List<GameObject> buffAnchors = new();

    [HideInInspector] public bool rearranging = false;


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

        foreach (Transform child in anchors.transform)
        {
            buffAnchors.Add(child.gameObject);
        }
        UpdateAnchors();
    }

    public GameObject GetAnchor(int index)
    {
        if (index < buffAnchors.Count)
        {
            return buffAnchors[index];
        }
        else
        {
            Debug.Log("Anchor Index out of range");
        }
        return null;
    }

    public List<GameObject> GetAllAnchors()
    {
        return buffAnchors;
    }

    public int GetAnchorIndex(GameObject anchor)
    {
        return buffAnchors.IndexOf(anchor);
    }

    public BuffDisplay GetBuffDisplayOnAnchor(GameObject anchor)
    {
        if (anchor.transform.childCount > 0)
        {
            return anchor.transform.GetChild(0).GetComponent<BuffDisplay>();
        }
        return null;
    }

    public GameObject AddAnchor()
    {
        GameObject newAnchor = Instantiate(buffAnchor, anchors.transform);
        buffAnchors.Add(newAnchor);
        newAnchor.transform.SetParent(anchors.transform);
        newAnchor.transform.localPosition = Vector3.zero;
        UpdateAnchors();
        return newAnchor;
    }
    
    public void RemoveAnchor()
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
            int defaultMax = 5;
            if (buffAnchors.Count <= defaultMax)
            {
                anchor.transform.position = Vector3.Lerp(firstSlot.position, lastSlot.position, (float)i / (defaultMax - 1));
            }
            else
            {
                anchor.transform.position = Vector3.Lerp(firstSlot.position, lastSlot.position, (float)i / (buffAnchors.Count - 1));
            }
        }
    }
}
