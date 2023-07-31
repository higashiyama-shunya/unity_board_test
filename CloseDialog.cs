using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDialog : MonoBehaviour
{
    public bool isOpen => gameObject.activeSelf;

    public void Close()
    {
        if (!isOpen) return;
        gameObject.SetActive(false);
    }
}
