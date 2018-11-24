﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class SkillCooldownBurf : IBurf, ISkillModificationCommand
    {
        public SkillCooldownBurf(double burfRatio)
        {
            CooldownRatio = burfRatio;
        }

        public double CooldownRatio
        {
            get; private set;
        }

        public bool IsPositiveBurf
        {
            get
            {
                return CooldownRatio >= 1.0;
            }
        }

        public bool IsPersistent
        {
            get
            {
                return false;
            }
        }

        public string Description
        {
            get
            {
                return string.Format("모든 프로그래밍 쿨타임을 {0}배 감소 적용됩니다.", CooldownRatio);
            }
        }

        public string IconName
        {
            get
            {
                return "Cooldown";
            }
        }

        public int RemainingTurn
        {
            get; set;
        }

        public void Modify(ActiveSkill activeSkill)
        {
            if (activeSkill.Information.Type != SkillType.None)
            {
                activeSkill.AdditionlCooldownRatio += CooldownRatio;;

                CommonLogger.LogFormat("SkillCooldownBurf::Modify => 스킬 '{0}'에 znfxkdla 버프를 받음. 쿨타임이 {1} 감소함. 현재 : {2}", activeSkill.Information.Name, CooldownRatio, activeSkill.AdditionlCooldownRatio);
            }
        }

        public void Unmodify(ActiveSkill activeSkill)
        {
            if (activeSkill.Information.Type != SkillType.None)
            {
                activeSkill.AdditionalDamageRatio -= CooldownRatio;

                CommonLogger.LogFormat("SkillCooldownBurf::Unmodify => 스킬 '{0}'의 쿨타임 버프가 해제됨. 쿨타임이 {1} 증가함. 현재 : {2}", activeSkill.Information.Name, CooldownRatio, activeSkill.AdditionlCooldownRatio);
            }
        }
    }
}