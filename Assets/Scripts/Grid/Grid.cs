using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Grid : MonoBehaviour, IPointerEnterHandler,IPointerClickHandler
{
    //是否该位置上为空
    bool isEmpty = false;
    // 是否该位置上的单位进行了移动
    bool isAction;
    //是否需要展示出来grid
    bool isShow;



    public bool IsEmpty { get => isEmpty; set => isEmpty = value; }
    public bool IsAction { get => isAction; set => isAction = value; }
    public bool IsShow
    {
        get { return isShow; }
        set
        {
            isShow = value;
            if (isShow)
            {
                this.gameObject.SetActive(true);
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //TODO:目前需求是获取此格子上的信息
        Debug.Log(this.isEmpty);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //TODO:必须要在玩家选了攻击或者选了技能的情况适用
        //if(...)
        Debug.Log("Enter the Grid");
    }
}
