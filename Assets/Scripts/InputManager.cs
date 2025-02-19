using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InputListener
{
    void OnSubmit();
    void OnReject();
    void OnThird();
}

public class InputManager : MonoBehaviour
{
    //singleton
    public static InputManager instance;

    private List<InputListener> listeners = new List<InputListener>();

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void RegisterListener(InputListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(InputListener listener)
    {
        listeners.Remove(listener);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Left Click");
            foreach(InputListener listener in listeners)
            {
                listener.OnSubmit();
            }
        }

        if(Input.GetMouseButtonDown(1))
        {
            //Debug.Log("Right Click");
            foreach(InputListener listener in listeners)
            {
                listener.OnReject();
            }
        }

        if(Input.GetMouseButtonDown(2) || Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("Third Click");
            foreach(InputListener listener in listeners)
            {
                listener.OnThird();
            }
        }
    }
}
