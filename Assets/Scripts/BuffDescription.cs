using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuffDescription : MonoBehaviour
{
    [SerializeField]
    private GameObject descText;

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
}
