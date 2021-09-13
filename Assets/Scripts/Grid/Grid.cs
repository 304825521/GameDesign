using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Grid : MonoBehaviour
{
    //是否该位置上为空
    bool isEmpty = false;
    // 是否该位置上的单位进行了移动
    bool isAction;
    //是否需要展示出来grid
    bool isShow;

    //#region 物体声明

    //public Sprite RedGrid;


    //#endregion


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

            }
            else
            {

            }
        }
    }
}
