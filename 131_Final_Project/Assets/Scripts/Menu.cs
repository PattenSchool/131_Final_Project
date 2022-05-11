using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private GameObject _canvas;

    // Start is called before the first frame update
    void Start()
    {
        _canvas = GameObject.FindGameObjectWithTag("Canvas");
        _canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (_canvas.activeSelf)
            {
                Cursor.lockState = CursorLockMode.Locked;
                _canvas.SetActive(false);
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                _canvas.SetActive(true);
            }
        }
    }
}
