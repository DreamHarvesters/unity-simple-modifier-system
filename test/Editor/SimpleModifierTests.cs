using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using NSubstitute;


namespace DH.ModifierSystem
{
    public class SimpleModifierTests
    {
        [Test]
        public void ModifiableModificationMade_Pass()
        {
            IModifiable modifiable = Substitute.For<IModifiable>();
            Modifier<IModifiable> modifier = Substitute.For<Modifier<IModifiable>>();

            bool isModifiableModified = false;
            modifiable.
                      When(spyModifiable => spyModifiable.OnModificationApplied(modifier)).
                      Do(spyModifiable => isModifiableModified = true);

            modifier.
                    When(spyModifier => spyModifier.Modify(modifiable)).
                    Do(spyModifier => modifiable.OnModificationApplied(modifier));


            modifier.Modify(modifiable);

            Assert.IsTrue(isModifiableModified);
        }
    }
}
