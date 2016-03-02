namespace FixieSpecs.Tests
{
    using Fixie;
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.AutoFakeItEasy;
    using Ploeh.AutoFixture.Kernel;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Fixture = Ploeh.AutoFixture.Fixture;

    /// <summary>
    /// A <see cref="ParameterSource"/> that creates parameter values using AutoFîxture.
    /// </summary>
    public class AutoFixtureParameterSource : ParameterSource
    {
        /// <inheritdoc/>
        public IEnumerable<object[]> GetParameters(MethodInfo method)
        {
            // Produces a randomly-populated object for each
            // parameter declared on the test method, using
            // a Fixture that has our customizations.

            IFixture fixture = new Fixture().Customize(new AutoFakeItEasyCustomization());

            yield return GetParameterData(method.GetParameters(), fixture);
        }

        object[] GetParameterData(ParameterInfo[] parameters, IFixture fixture)
        {
            return parameters
                .Select(p => new SpecimenContext(fixture).Resolve(p.ParameterType))
                .ToArray();
        }
    }
}