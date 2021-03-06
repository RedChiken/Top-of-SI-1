﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Model
{
    public class StaticRendering : ProjectSingleDeburfSkill, ISoundProducible
    {
        private const int defaultCooldown = 4;

        private static ProjectSkillInformation information = new ProjectSkillInformation
        {
            Type = ProjectSkillType.SingleDeburf,
            Technique = RequiredTechType.Graphic,
            Name = "StaticRendering",
            MaximumLevel = 1,
            Animation = "Shout"
        };

        private static IEnumerable<IBurf> deburfs = new List<IBurf>
        {
            new MovableBurf(false) { RemainingTurn = defaultCooldown }
        };

        public StaticRendering() 
            : base(new List<IBurf>(deburfs.Select(deburf => deburf.Clone())), information, defaultCooldown)
        {

        }

        public AudioClip EffectSound
        {
            get
            {
                return ResourceLoadUtility.LoadEffectClip("monster2");
            }
        }
    }
}
