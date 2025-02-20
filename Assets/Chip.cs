using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chip : MonoBehaviour
{
    private Material m_Material;
    // Start is called before the first frame update
    void Start()
    {
        m_Material = GetComponent<Image>().material;
    }

    // Update is called once per frame
    void Update()
    {
        //vector between the chip and the mouse
        Vector2 direction = (Vector2)Input.mousePosition - (((Vector2)transform.position + new Vector2(8.9f, 5f)) * (Screen.height / 10f));
        Debug.Log(((Vector2)transform.position + new Vector2(8.9f, 5f)) * (Screen.height / 10f));
        m_Material.SetVector("_Direction", direction);
    }
}
