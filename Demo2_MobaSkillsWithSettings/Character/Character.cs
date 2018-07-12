using System;
using UnityEngine;
using System.Collections;
using DH.ModifierSystem;
using UnityEngine.Analytics;

namespace DH.ModifierSystem.Demo2_MobaSkillsWithSettings
{
    public class Character : IModifiable
    {
        private CharacterData data;

        private Skill[] skills;

        public Character(CharacterData data)
        {
            this.data = data;
            
            SetupSkills();
        }
        
        public void SetRotationSpeed(float rotation)
        {
            data.RotationSpeed = rotation;
        }

        public void SetColor(Color newColor)
        {
            data.CharacterColor = newColor;
        }

        public void ActivateSkill(int skillId, Character target)
        {
            if(skillId >= skills.Length)
                throw new Exception("Skill id is not valid");
            
            skills[skillId].Activate(target);
        }

        public void OnModificationApplied(IModifier modifier)
        {
            Debug.Log(string.Format("Character modification applied: {0} ", modifier.ModifierType.FullName));
        }

        public void OnModificationReverted(IModifier modifier)
        {
            Debug.Log(string.Format("Character modification reverted: {0} ", modifier.ModifierType.FullName));
        }

        void SetupSkills()
        {
            int skillCount = data.Skills.Length;
            skills = new Skill[skillCount];
            for (int i = 0; i < skillCount; i++)
            {
                Modifier<Character>[] modifiers = new Modifier<Character>[data.Skills[i].Modifiers.Length];
                for (int j = 0; j < data.Skills[i].Modifiers.Length; j++)
                {
                    modifiers[j] = data.Skills[i].Modifiers[j].ModifierInstance;
                }
                
                skills[i] = new Skill(modifiers);
            }
        }
    }
}
