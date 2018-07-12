using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DH.ModifierSystem.Demo2_MobaSkillsWithSettings
{
    public class Skill
    {
        private Modifier<Character>[] modifiers;

        public Skill(Modifier<Character>[] modifiers)
        {
            this.modifiers = modifiers;
        }

        public void Activate(Character character)
        {
            foreach(var modifier  in modifiers)
            {
                modifier.Modify(character);
            }
        }
    }
}
