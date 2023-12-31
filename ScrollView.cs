using Mosframe;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScrollView : MonoBehaviour
{

    public List<ChatListResult> list = new List<ChatListResult>();

    // Start is called before the first frame update
    void Start()
    {
        //ゲームオブジェクト取得。
        DynamicScrollView dynamicScrollView;
        GameObject obj = transform.parent.gameObject;
        dynamicScrollView = obj.GetComponent<DynamicScrollView>();

        for (int i = 1; i < 23; i++)
        {
            list.Add(new ChatListResult() { id = i, chat_room_name = "room" + i, owner_id = i });
        }
        //取得したゲームオブジェクトを使ってtotalItemCountを用意したリストの要素数に変える。
        dynamicScrollView.totalItemCount = list.Count;
        Debug.Log("listcount:" + list.Count + "\ntotalItemCount" + dynamicScrollView.totalItemCount);
    }
}
