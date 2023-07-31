using Mosframe;
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

    public void OnClick()
    {
        Dialog dialog;
        GameObject obj = transform.root.Find("Dialog").gameObject;
        obj.SetActive(true);
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
            var data = chatListResultList[index];

            background.color = this.colors[Mathf.Abs(index) % colors.Length];

            title.text = string.Format("{0}:{1}", data.id, data.chat_room_name);
        }
        Debug.Log("onUpdateItem�I��:" + index);

    }

}
