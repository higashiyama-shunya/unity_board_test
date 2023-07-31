using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDialog : MonoBehaviour
{
    //�Q�[���I�u�W�F�N�g���J���Ă��邩���肷��ϐ��B�J���Ă�����true�ɂȂ�B
    public bool isOpen => gameObject.activeSelf;

    public void Close()
    {
        if (!isOpen) return;
        gameObject.SetActive(false);
    }
}
