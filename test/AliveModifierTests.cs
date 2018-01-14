using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using NSubstitute;
using System;

namespace DH.ModifierSystem
{
    public class AliveModifierTests
    {

        // A UnityTest behaves like a coroutine in PlayMode
        // and allows you to yield null to skip a frame in EditMode
        [UnityTest]
        public IEnumerator SimpleLifetimeTestPass()
        {
            DateTime modificationTime = DateTime.UtcNow;
            TimeSpan elapsedTime = new TimeSpan(0);
            float lifetime = 2;

            IModifiable modifiable = Substitute.For<IModifiable>();
            Modifier<IModifiable> simpleModifier = Substitute.For<Modifier<IModifiable>>();
            AliveModifier<IModifiable> aliveModifier = new AliveModifier<IModifiable>(simpleModifier, lifetime);

            //Setup When...Do for modifier
            simpleModifier.
                          When(modifier => modifier.Modify(modifiable)).
                          Do(modifier => modifiable.OnModificationApplied(simpleModifier));

            simpleModifier.
                          When(modifier => modifier.Revert(modifiable)).
                          Do(modifier => modifiable.OnModificationReverted(simpleModifier));

            //Setup When...Do for modifiable
            modifiable.
                      When(spyModifiable => spyModifiable.OnModificationApplied(simpleModifier)).
                      Do(spyModifiable => modificationTime = DateTime.UtcNow);

            modifiable.
                      When(spyModifiable => spyModifiable.OnModificationReverted(simpleModifier)).
                      Do(spyModifiable => elapsedTime = DateTime.UtcNow.Subtract(modificationTime));

            aliveModifier.Modify(modifiable);

            yield return new WaitForSeconds(lifetime + 1);

            float timeDiff = Mathf.Abs(lifetime - (float)elapsedTime.TotalSeconds);
            Assert.IsTrue(timeDiff < 0.1f);
        }

        [UnityTest]
        public IEnumerator ResetLifetimeTestPass()
        {
            DateTime modificationTime = DateTime.UtcNow;
            TimeSpan elapsedTime = new TimeSpan(0);
            float lifetime = 2;

            IModifiable modifiable = Substitute.For<IModifiable>();
            Modifier<IModifiable> simpleModifier = Substitute.For<Modifier<IModifiable>>();
            AliveModifier<IModifiable> aliveModifier = new AliveModifier<IModifiable>(simpleModifier, lifetime);

            //Setup When...Do for modifier
            simpleModifier.
                          When(modifier => modifier.Modify(modifiable)).
                          Do(modifier => modifiable.OnModificationApplied(simpleModifier));

            simpleModifier.
                          When(modifier => modifier.Revert(modifiable)).
                          Do(modifier => modifiable.OnModificationReverted(simpleModifier));

            //Setup When...Do for modifiable
            modifiable.
                      When(spyModifiable => spyModifiable.OnModificationApplied(simpleModifier)).
                      Do(spyModifiable => modificationTime = DateTime.UtcNow);

            modifiable.
                      When(spyModifiable => spyModifiable.OnModificationReverted(simpleModifier)).
                      Do(spyModifiable => elapsedTime = DateTime.UtcNow.Subtract(modificationTime));

            aliveModifier.Modify(modifiable);

            yield return new WaitForSeconds(lifetime - 1);

            aliveModifier.Reset();
            modificationTime = DateTime.UtcNow;

            yield return new WaitForSeconds(lifetime - 1);

            Assert.Zero(elapsedTime.Seconds);

            yield return new WaitForSeconds(lifetime);

            Assert.NotZero(elapsedTime.Seconds);

            Assert.Greater(elapsedTime.TotalSeconds, lifetime);
        }
    }
}
