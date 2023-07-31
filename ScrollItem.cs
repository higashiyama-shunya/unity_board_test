using Mosframe;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using UnityEngine.UIElements;


public class ScrollItem : MonoBehaviour, IDynamicScrollViewItem
{
    private readonly Color[] colors = new Color[] {
            Color.cyan,
            Color.green,
        };

    [SerializeField]
    public Text title;
    [SerializeField]
    public Image background;

    private int itemIndex = -1;

    [SerializeField]
    DynamicVScrollView dynamicVScrollView;

    /*
    public void OnClick()
    {
        //サンプルの方ではif文ではじいている
        if (chatListResult == null) return;

        //オブジェクトを取得するための変数
        Text text;

        GameObject obj = transform.root.Find("Dialog").gameObject;
        obj.SetActive(true);
        GameObject textObj = obj.transform.Find("Text").gameObject;
        text = textObj.GetComponent<Text>();
        Debug.Log("ボタンが押されました");
        text.text = string.Format("ルームID:{0}\nルーム名:{1}\nオーナーID{2}", chatListResult.id, chatListResult.chat_room_name, chatListResult.owner_id);
    }
    */


    public void onClick()
    {
        //初期値を
        if (this.itemIndex == -1) return;
        onClick(this.itemIndex);
    }


    public void onClick(int index)
    {
        Text text;
        ScrollView scrollView;

        GameObject obj = transform.root.Find("Dialog").gameObject;
        GameObject textObj = obj.transform.Find("Text").gameObject;
        text = textObj.GetComponent<Text>();

        GameObject chatRoomList = transform.parent.parent.gameObject;
        scrollView = chatRoomList.GetComponent<ScrollView>();

        List<ChatListResult> chatListResultList = scrollView.list;
        var data = chatListResultList[index];

        text.text = string.Format("ID:{0}\nNAME:{1}\nオーナーID:{2}", data.id, data.chat_room_name, data.owner_id);
        obj.SetActive(true);
        Debug.Log(index + "番が押されました");
    }

    public void onUpdateItem(int index)
    {
        Debug.Log("onUpdateItem�J�n:" + index);
        ScrollView scrollView;
        GameObject obj = transform.parent.parent.gameObject;
        scrollView = obj.GetComponent<ScrollView>();
        List<ChatListResult> chatListResultList = scrollView.list;
        if (chatListResultList.Count > index)
        {
            //最終選択番号を更新する。
            this.itemIndex = index;

            var data = chatListResultList[index];

            background.color = colors[Mathf.Abs(index) % colors.Length];

            title.text = string.Format("{0}:{1}", data.id, data.chat_room_name);
        }
        Debug.Log("onUpdateItem�I��:" + index);
    }
}
