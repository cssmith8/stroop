using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buffsShop : MonoBehaviour
{
    [SerializeField] private GameObject anchor;
    [SerializeField] private GameObject buffDisplayPrefab;

    private GameObject activeBuffDisplay;

    // Start is called before the first frame update
    void Start()
    {
        activeBuffDisplay = Instantiate(buffDisplayPrefab, anchor.transform.position, Quaternion.identity, anchor.transform);
    }

    public void ContinueButton()
    {
        GameManager.instance.OnBuffsContinue();
    }

    public void ClaimButton()
    {
        GameObject anchor = BuffSidebar.instance.AddAnchor();
        BuffDisplay active = activeBuffDisplay.GetComponent<BuffDisplay>();
        active.SetAnchor(anchor);
        active.BeginReturnToAnchor();
        RunProgression.instance.AddBuff(active.buff);
    }
}
