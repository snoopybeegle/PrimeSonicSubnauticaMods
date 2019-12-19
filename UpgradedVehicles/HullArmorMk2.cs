namespace UpgradedVehicles
{
    using System.Collections.Generic;
    using SMLHelper.V2.Crafting;

    internal class HullArmorMk2 : VehicleUpgradeModule
    {
        private const int ArmorCount = 2;
        public HullArmorMk2()
            : base(classId: "HullArmorMk2",
                friendlyName: "Hull Reinforcement Mk II",
                description: "A better hull upgrade. Equivalent to 2 regular Hull Reinforcements")
        {
            OnFinishedPatching += () =>
            {
                VehicleUpgrader.CommonUpgradeModules.Add(this.TechType);
                VehicleUpgrader.ArmorPlatingModules.Add(this.TechType, ArmorCount);
            };
        }

        public override CraftTree.Type FabricatorType => CraftTree.Type.Workbench;
        public override string[] StepsToFabricatorTab => new[] { "SeamothMenu" };

        protected override TechData GetBlueprintRecipe()
        {
            return new TechData()
            {
                craftAmount = 1,
                Ingredients = new List<Ingredient>
                {
                    new Ingredient(TechType.VehicleArmorPlating, ArmorCount),
                    new Ingredient(TechType.Titanium, ArmorCount)
                }
            };
        }
    }
}