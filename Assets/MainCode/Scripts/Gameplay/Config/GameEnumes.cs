using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum TYPE_ITEM : int
{
    PRIMARYGUN,
    SECONDARYGUN,
    GRENADE,
    EQUIPMENT
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
    NONE
}

public enum TYPE_ACHIVEMENT
{
    NONE
}

public enum STATUS_ITEMSHOP
{
    BOUGHT,
    NOTBOUGHT,
    SELECT
}