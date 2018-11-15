﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    class FastCode : PassiveSkill, ICooldownConvertible
    {
        private static SkillBasicInformation information = new SkillBasicInformation()
        {
            Name = "FastCode",
            Type = SkillType.Python,
            AcquisitionLevel = 0,
            MaximumLevel = 10,
            IconName = "Python",
            RequiredUpgradeCost = 2,
            DescriptionFunc = level => string.Format("Python으로 간단한 코드를 아주 빠르게 작성할 수 있습니다. 쿨타임이 {0}% 감소합니다.", level)
        };

        public FastCode() : base(information.Clone(), Enumerable.Empty<PassiveSkill>())
        {

        }

        public double CalculateAppliedCooldown(double baseCooldown)
        {
            return baseCooldown * (1 - information.AcquisitionLevel / 100);
        }

        public override void LevelUP()
        {
            information.AcquisitionLevel++;
        }
    }
}
