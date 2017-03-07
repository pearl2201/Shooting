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
    PAUSE, PLAY, END, START, SETUP
}


public enum PLAYER_STATE
{
    SHOOT, CHARGE, FREE
}

public enum ENEMY_PHAZE
{
    WAIT, RUN, FINISH
}