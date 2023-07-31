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
    //サンプルからあった背景の色を変えるためのリスト
    private readonly Color[] colors = new Color[] {
            Color.cyan,
            Color.green,
        };

    //inspecterから貼り付けるための変数
    [SerializeField]
    public Text title;
    [SerializeField]
    public Image background;

    //それぞれのアイテムのインデックス番号を保持する変数。
    private int itemIndex = -1;

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
        //アイテムにインデックス番号が無ければreturnで何もせずに戻る。
        if (this.itemIndex == -1) return;
        //itemIndexでリストの中のどの要素を取得するか決める。
        onClick(this.itemIndex);
    }

    //クリックした際のメソッド
    public void onClick(int index)
    {
        //GetComponentで渡す用の変数
        Text text;
        ScrollView scrollView;

        //必要なゲームオブジェクトを親や子オブジェクトから名前で探している。
        GameObject obj = transform.root.Find("Dialog").gameObject;
        GameObject textObj = obj.transform.Find("Text").gameObject;
        text = textObj.GetComponent<Text>();

        GameObject chatRoomList = transform.parent.parent.gameObject;
        scrollView = chatRoomList.GetComponent<ScrollView>();

        //ゲームオブジェクトから持ってきた値をdataに代入。
        List<ChatListResult> chatListResultList = scrollView.list;
        var data = chatListResultList[index];

        text.text = string.Format("ID:{0}\nNAME:{1}\nオーナーID:{2}", data.id, data.chat_room_name, data.owner_id);
        obj.SetActive(true);
        Debug.Log(index + "番が押されました");
    }

    //スクロールされるたびに実行されるメソッド。
    public void onUpdateItem(int index)
    {
        Debug.Log("onUpdateItem�J�n:" + index);
        //ゲームオブジェクトの値を入れるための変数。
        ScrollView scrollView;
        GameObject obj = transform.parent.parent.gameObject;
        scrollView = obj.GetComponent<ScrollView>();
        List<ChatListResult> chatListResultList = scrollView.list;
        //持ってきたリストの要素数が指定したインデックス番号より大きければ
        if (chatListResultList.Count > index)
        {
            //最終選択番号を更新する。
            this.itemIndex = index;

            var data = chatListResultList[index];

            background.color = colors[Mathf.Abs(index) % colors.Length];
            //テキストにidとルーム名を代入する。
            title.text = string.Format("{0}:{1}", data.id, data.chat_room_name);
        }
        Debug.Log("onUpdateItem�I��:" + index);
    }
}
