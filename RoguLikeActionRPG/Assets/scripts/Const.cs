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

        public static int MAX_ENEMY_NUM = 4;    //�G�̍ő�o����
        public static int SPAWN_TIME = 2;   //�G�̃X�|�[������
        public static int BOSS_APPEARANCE_CON = 10;//�{�X�̏o������

        public static int SPAWN_SLIME = 10;//�L���O�X���C���|�����ۂ̃X���C���̏o����
        public static float ATTACK_DELAY_TIME = 1;//�G�̍U���\�����쎞��

        public static float PLAYER_INVICIBLE_TIME = 2;

        public static int STAGE1_TIME = 60;
        public static int STAGE2_TIME = 90;
        public static int STAGE3_TIME = 120;
    }
}