using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BuffDescription : MonoBehaviour
{
    [SerializeField]
    private GameObject descText;

    [SerializeField]
    private GameObject chipSlot1, chipSlot2, chipSlot3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(string text)
    {
        descText.GetComponent<TMP_Text>().text = text;
    }

    public void SetChips(List<Upgrade> upgrades) {
        chipSlot1.transform.GetChild(0).gameObject.SetActive(false);
        chipSlot2.transform.GetChild(0).gameObject.SetActive(false);
        chipSlot3.transform.GetChild(0).gameObject.SetActive(false);
        if (upgrades.Count > 0) {
            chipSlot1.transform.GetChild(0).GetComponent<Image>().color = Buff.UpgradeToColor(upgrades[0]);
            chipSlot1.transform.GetChild(0).gameObject.SetActive(true);
        }
        if (upgrades.Count > 1) {
            chipSlot2.transform.GetChild(0).GetComponent<Image>().color = Buff.UpgradeToColor(upgrades[1]);
            chipSlot2.transform.GetChild(0).gameObject.SetActive(true);
        }
        if (upgrades.Count > 2) {
            chipSlot3.transform.GetChild(0).GetComponent<Image>().color = Buff.UpgradeToColor(upgrades[2]);
            chipSlot3.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
