﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class BossSkill_RequirementChanged : AbstractSkill
{
    public override void Do(ref Animator anim)
    {
        anim.Play("Shout");
        cool = 0;
    }

    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
    }
}
