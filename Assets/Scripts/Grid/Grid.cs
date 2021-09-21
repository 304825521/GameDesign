using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Grid : MonoBehaviour
{
    //是否该位置上为空
    bool isEmpty = false;
    // 是否该位置上的单位进行了移动
    bool isAction;
    //是否需要展示出来grid
    bool isShow;
    //动画组件
    public UIDynamic UIDynamic;
    //是否可以开始鼠标经过的逻辑
    bool canOver = false;

    public bool CanOver { get => canOver; set => canOver = value; }
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

    

    private void OnMouseEnter()
	{
        //TODO:将来写攻击逻辑的时候加回去
        //if (CanOver == false) return;   
        UIDynamic.Play("AttackGrid");
	}

    private void OnMouseExit()
    {
        //if (CanOver == false) return;
        UIDynamic.SetTrigger("Normal");
    }

    private void OnMouseDown()
    {
        //TODO:当点下去后执行各自操作或许，需要一个变量确定
        //当前是攻击，道具还是技能攻击的鼠标点击
    }


    //TODO：只是为了测试，后面删除
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CanOver = true;
        }
    }


}
