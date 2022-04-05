using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define{
    public enum State
    {
        Idle,
        Move,
        Attack,
        Die,
    }

    public enum AttackType
    {
        NORMAL_ATTACK,
        QSkill,
        WSkill,
        ESkill,
        RSkill,
    }

    public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        Game,
    }

    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,
    }

    public enum UIEvent
    {
        Click,
        Drag,
    }
}