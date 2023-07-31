using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDialog : MonoBehaviour
{
    //ゲームオブジェクトが開いているか判定する変数。開いていたらtrueになる。
    public bool isOpen => gameObject.activeSelf;

    public void Close()
    {
        if (!isOpen) return;
        gameObject.SetActive(false);
    }
}
