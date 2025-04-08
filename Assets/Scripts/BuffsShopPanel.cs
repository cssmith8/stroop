using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffsShopPanel : MonoBehaviour
{
    [SerializeField] private GameObject buffAnchor, chipAnchor;
    [SerializeField] private GameObject buffDisplayPrefab, chipPrefab;

    private GameObject activeBuffDisplay, activeChip;

    // Start is called before the first frame update
    void Start()
    {
        activeBuffDisplay = Instantiate(buffDisplayPrefab, buffAnchor.transform.position, Quaternion.identity, buffAnchor.transform);
        activeChip = Instantiate(chipPrefab, chipAnchor.transform.position, Quaternion.identity, chipAnchor.transform);
    }

    public void ContinueButton()
    {
        GameManager.instance.OnBuffsContinue();
    }

    public void ClaimButton()
    {
        GameObject anchor = BuffSidebar.instance.AddAnchor();
        BuffDisplay active = activeBuffDisplay.GetComponent<BuffDisplay>();
        active.SetDraggable(true);
        active.SetAnchor(anchor);
        active.BeginReturnToAnchor();
        RunProgression.instance.AddBuff(active.buff);
    }

    public void ClaimChipButton()
    {
        activeChip.GetComponent<Chip>().SetDraggable(true);
    }
}
