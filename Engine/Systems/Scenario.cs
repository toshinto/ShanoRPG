using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Engine.Objects;
using ScriptLib;

namespace Engine.Systems
{
    class Scenario : ScenarioCompiler
    {
        readonly Dictionary<string, Ability> abilityPrototypes = new Dictionary<string, Ability>();

        readonly Dictionary<string, ShanoMonster> creaturePrototypes = new Dictionary<string, ShanoMonster>();


        public Scenario(string fileDir)
            : base(fileDir) { }

        public Ability CreateAbility(string abilityName)
        {
            var t = abilityPrototypes[abilityName];
            var obj = Activator.CreateInstance(t.GetType()) as Ability;

            return obj;
        }

        public bool TryCompile()
        {
            var res = this.Compile();

            if (res.Success)
                loadTypes();

            if (!res.Success)
                throw new Exception();

            return res.Success;
        }

        /// <summary>
        /// Loads the generated Ability.dll assembly
        /// </summary>
        private void loadTypes()
        {
            var assembly = Assembly.LoadFile(getLocalDir(OutputFile));

            //abils
            loadAbilities(assembly);
        }

        private void loadAbilities(Assembly a)
        {
            createPrototypes(a, abilityPrototypes);
        }

        private void createPrototypes<T>(Assembly a, Dictionary<string, T> protoDict)
            where T : class
        {
            var declaredTypes = a.GetTypes()
                .Where(t => typeof(T).IsAssignableFrom(t));

            foreach (var t in declaredTypes)
            {
                var prototype = Activator.CreateInstance(t) as T;
                protoDict.Add(t.ToString(), prototype);
            }
        }
    }
}
