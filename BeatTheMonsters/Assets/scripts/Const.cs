using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Const
{
    public static class CO
    {
        //Path
        public static string ENEMY_PREFAB_PATH = "Prefab/Enemy/";
        public static string BOSS_PREFAB_PATH = "Prefab/Enemy/Boss/";
        public static string ENEMY_STATUS_PATH = "StatusData/Enemy/";

        public static int MAX_ENEMY_NUM = 4;    //敵の最大出現数
        public static int SPAWN_TIME = 2;   //敵のスポーン時間
        public static int BOSS_APPEARANCE_CON = 10;//ボスの出現条件

        public static int SPAWN_SLIME = 4;//キングスライム倒した際のスライムの出現数
        public static float ATTACK_DELAY_TIME = 1;//敵の攻撃予備動作時間

        public static float PLAYER_INVICIBLE_TIME = 2;

        public static int STAGE1_TIME = 60;
        public static int STAGE2_TIME = 90;
        public static int STAGE3_TIME = 120;
    }
}