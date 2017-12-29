using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using NSubstitute;

namespace DH.ModifierSystem
{
    public class ActiveModificationsTests
    {
        private IModifier modifier;
        private IModifiable modifiable;
        private ActiveModifications activeModifications;

        public void Init()
        {
            modifier = Substitute.For<IModifier>();
            modifiable = Substitute.For<IModifiable>();

            activeModifications = new ActiveModifications();
        }

        [Test]
        public void AddModification_Pass()
        {
            Init();

            activeModifications.Add(modifiable, modifier);

            IModifier[] modifiers = activeModifications.GetModifiersOn(modifiable);

            Assert.AreSame(modifier, modifiers[0]);
        }

        [Test]
        public void RemoveModification_Pass()
        {
            Init();

            activeModifications.Add(modifiable, modifier);

            Assert.AreEqual(1, activeModifications.GetModifiersOn(modifiable).Length);

            activeModifications.Remove(modifiable, modifier);

            Assert.IsEmpty(activeModifications.GetModifiersOn(modifiable));
        }

        [Test]
        public void RemoveRightModification_Pass()
        {
            Init();

            IModifier modifier2 = Substitute.For<IModifier>();

            activeModifications.Add(modifiable, modifier);
            activeModifications.Add(modifiable, modifier2);

            Assert.AreEqual(2, activeModifications.GetModifiersOn(modifiable).Length);

            activeModifications.Remove(modifiable, modifier);

            Assert.AreEqual(1, activeModifications.GetModifiersOn(modifiable).Length);
            Assert.AreSame(modifier2, activeModifications.GetModifiersOn(modifiable)[0]);
        }

        [Test]
        public void RemoveModificationsOnModifiable_Pass()
        {
            Init();

            IModifier modifier2 = Substitute.For<IModifier>();

            activeModifications.Add(modifiable, modifier);
            activeModifications.Add(modifiable, modifier2);

            Assert.AreEqual(2, activeModifications.GetModifiersOn(modifiable).Length);

            activeModifications.RemoveAll(modifiable);

            Assert.IsEmpty(activeModifications.GetModifiersOn(modifiable));
        }

        [Test]
        public void GetModifiersOn_Pass()
        {
            Init();

            IModifiable modifiable2 = Substitute.For<IModifiable>();
            IModifier modifier2 = Substitute.For<IModifier>();

            activeModifications.Add(modifiable, modifier);
            activeModifications.Add(modifiable2, modifier2);

            Assert.AreSame(modifier2, activeModifications.GetModifiersOn(modifiable2)[0]);
        }
    }
}
