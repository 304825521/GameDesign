using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using FS2.UI;
using FS2;

namespace Fs2.Battle{
    public class BattleManager : MonoSingleton<BattleManager>
    {
        //1. 需要有跟UI面板链接的工具
        //2. 战斗相关的数据在这里声明

        UIBattle UIBattle;

        private void OnEnable()
        {
            Init(); 
        }

        public void Init()
        {
            UIBattle = Game.UI.Open<UIBattle>();
            if (UIBattle == null)
            {
                Debug.Log("UIBattle没有加载");
                return;
            }
        }
    }

}