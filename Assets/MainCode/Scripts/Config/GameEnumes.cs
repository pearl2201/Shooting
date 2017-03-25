using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum TYPE_ITEM : int
{
    PRIMARYGUN,
    SECONDARYGUN,
    GRENADE,
    EQUIPMENT,
    CHARACTER
}


public enum TYPE_AI : int
{
    STATIC,
    MOVING,
    MOVE_TO_SHOOT
}

public enum TYPE_COMPONENT_ENEMY
{
    HEADER,
    BODY
}

public enum TYPE_ENEMY : int
{
    MOVING = 0,

    STATIC_BOMB = 10,

    STATIC_DEF = 11,

    STATIC_HP = 12,

    STATIC_GOLD = 13,

    MOVE_SHOOT_FIXED_LINE = 20,
    MOVE_SHOOT_RAND_LINE = 21

}


public enum GAME_STATE
{
    PAUSE, PLAY, END, START, SETUP, TRANSFER, INTRO
}


public enum PLAYER_STATE
{
    SHOOT, CHARGE, FREE
}

public enum ENEMY_PHAZE
{
    WAIT, RUN, DYING, FINISH, PLAY
}

public enum TYPE_PLAYER_GUN
{
    PRIMARY_GUN,
    SECONDARY_GUN
}

public enum TYPE_ENEMY_ATTACK
{
    SHOOT,
    SHOOT_GRENADE,
    KNIFE
}

public enum TYPE_MAP_MISSION
{
    CLEAR_ENEMY,
    REACH_SCORE
}

public enum TYPE_IAP
{
    NO_ADS,
    COIN_PACK_1,
    COIN_PACK_2,
    COIN_PACK_3,
    UNLOCK_ALL_STAGE,
    INFINITE_ARMOR,
    INFINITE_GRENADE
}


public enum TYPE_DAILYQUEST
{
    USE_WEAPON_TO_KILL_20_ENEMY,
    BUY_NEW_WEAPON,
    WIN_HIT_RATE,
    KILL_ENEMY,
    SHOOT_COUNT,
    WIN_KILL_CIVILAN,
    SCORE,
    CHANGE_WEAPON,
    USE_SECONDARY_GUN,
    USE_GRENADE,
    USE_PRIMARY_GUN,
    UPGRADE_PRIMARY_GUN,
    BOUGHT_BULLET,
    BOUGHT_GRENADE,
    USE_WEAPON_XX_KILL_YY_ENEMY


}

public enum TYPE_ACHIVEMENT
{
    BATTLE_MASTER,
    LUCKY,
    BOMB_MAN,
    DOUBLE_KILL, // tam thoi loai
    RICH_MAN, 
    LORD_OF_WAR,
    BIG_ARMY,
    KILLER,
    PISTOL,
    PRIMARY_GUN_1,
    PRIMARY_GUN_2,
    PRIMARY_GUN_3


}

public enum STATUS_ITEMSHOP
{
    BOUGHT,
    NOTBOUGHT,
    SELECT
}

public enum TYPE_CHARACTER_SKILL
{
    NONE,
    HEAL_HP,
}

public enum TYPE_MONEY
{
    COIN,
    DIAMOND
}