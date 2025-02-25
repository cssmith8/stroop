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

    public bool rearranging = false;


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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) AddAnchor();
        if (Input.GetKeyDown(KeyCode.R)) RemoveAnchor();

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

    public int GetAnchorIndex(GameObject anchor)
    {
        return buffAnchors.IndexOf(anchor);
    }

    private void AddAnchor()
    {
        GameObject newAnchor = Instantiate(buffAnchor, anchors.transform);
        buffAnchors.Add(newAnchor);
        newAnchor.transform.SetParent(anchors.transform);
        newAnchor.transform.localPosition = Vector3.zero;
        UpdateAnchors();
    }

    public void StartBuffRearrange(GameObject DraggingBuffDisplay)
    {
        rearranging = true;
        for (int i = 0; i < buffAnchors.Count; i++)
        {
            if (buffAnchors[i].transform.childCount > 0)
            {
                GameObject buff = buffAnchors[i].transform.GetChild(0).gameObject;
                if (buff == DraggingBuffDisplay) continue;
                BuffDisplay buffDisplay = buff.GetComponent<BuffDisplay>();
                if (buffDisplay != null)
                {
                    buffDisplay.OnBuffRearrange();
                }
            }
        }
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
