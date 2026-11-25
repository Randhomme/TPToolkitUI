using TPToolkitLib.WorldObject.Definitions.CustomInfoFactories.Classes;
using TPToolkitUI.CustomAttributes;
using TPToolkitUI.Utils;

namespace TPToolkitUI.ViewModels.WorldObject
{
    public class DamagePotentialViewModel : CustomObservableValidator
    {
        private readonly DamagePotential model;

        [Float]
        public string ChanceOfCriticalDamageWood
        {
            get => model.ChanceOfCriticalDamageWood.ToString("F6");
            set => SetAndValidateProperty(model.ChanceOfCriticalDamageWood.ToString(), value, model, (m, s) => m.ChanceOfCriticalDamageWood = float.Parse(s));
        }

        [Float]
        public string ChanceOfFireWood
        {
            get => model.ChanceOfFireWood.ToString("F6");
            set => SetAndValidateProperty(model.ChanceOfFireWood.ToString(), value, model, (m, s) => m.ChanceOfFireWood = float.Parse(s));
        }

        [Float]
        public string InitialFireStrengthWood
        {
            get => model.InitialFireStrengthWood.ToString("F6");
            set => SetAndValidateProperty(model.InitialFireStrengthWood.ToString(), value, model, (m, s) => m.InitialFireStrengthWood = float.Parse(s));
        }

        [Float]
        public string DamageLowerBoundWood
        {
            get => model.DamageLowerBoundWood.ToString("F6");
            set => SetAndValidateProperty(model.DamageLowerBoundWood.ToString(), value, model, (m, s) => m.DamageLowerBoundWood = float.Parse(s));
        }

        [Float]
        public string DamageUpperBoundWood
        {
            get => model.DamageUpperBoundWood.ToString("F6");
            set => SetAndValidateProperty(model.DamageUpperBoundWood.ToString(), value, model, (m, s) => m.DamageUpperBoundWood = float.Parse(s));
        }

        [Float]
        public string ChanceOfCriticalDamageReinforced
        {
            get => model.ChanceOfCriticalDamageReinforced.ToString("F6");
            set => SetAndValidateProperty(model.ChanceOfCriticalDamageReinforced.ToString(), value, model, (m, s) => m.ChanceOfCriticalDamageReinforced = float.Parse(s));
        }

        [Float]
        public string ChanceOfFireReinforced
        {
            get => model.ChanceOfFireReinforced.ToString("F6");
            set => SetAndValidateProperty(model.ChanceOfFireReinforced.ToString(), value, model, (m, s) => m.ChanceOfFireReinforced = float.Parse(s));
        }

        [Float]
        public string InitialFireStrengthReinforced
        {
            get => model.InitialFireStrengthReinforced.ToString("F6");
            set => SetAndValidateProperty(model.InitialFireStrengthReinforced.ToString(), value, model, (m, s) => m.InitialFireStrengthReinforced = float.Parse(s));
        }

        [Float]
        public string DamageLowerBoundReinforced
        {
            get => model.DamageLowerBoundReinforced.ToString("F6");
            set => SetAndValidateProperty(model.DamageLowerBoundReinforced.ToString(), value, model, (m, s) => m.DamageLowerBoundReinforced = float.Parse(s));
        }

        [Float]
        public string DamageUpperBoundReinforced
        {
            get => model.DamageUpperBoundReinforced.ToString("F6");
            set => SetAndValidateProperty(model.DamageUpperBoundReinforced.ToString(), value, model, (m, s) => m.DamageUpperBoundReinforced = float.Parse(s));
        }

        [Float]
        public string ChanceOfCriticalDamageIron
        {
            get => model.ChanceOfCriticalDamageIron.ToString("F6");
            set => SetAndValidateProperty(model.ChanceOfCriticalDamageIron.ToString(), value, model, (m, s) => m.ChanceOfCriticalDamageIron = float.Parse(s));
        }

        [Float]
        public string ChanceOfFireIron
        {
            get => model.ChanceOfFireIron.ToString("F6");
            set => SetAndValidateProperty(model.ChanceOfFireIron.ToString(), value, model, (m, s) => m.ChanceOfFireIron = float.Parse(s));
        }

        [Float]
        public string InitialFireStrengthIron
        {
            get => model.InitialFireStrengthIron.ToString("F6");
            set => SetAndValidateProperty(model.InitialFireStrengthIron.ToString(), value, model, (m, s) => m.InitialFireStrengthIron = float.Parse(s));
        }

        [Float]
        public string DamageLowerBoundIron
        {
            get => model.DamageLowerBoundIron.ToString("F6");
            set => SetAndValidateProperty(model.DamageLowerBoundIron.ToString(), value, model, (m, s) => m.DamageLowerBoundIron = float.Parse(s));
        }

        [Float]
        public string DamageUpperBoundIron
        {
            get => model.DamageUpperBoundIron.ToString("F6");
            set => SetAndValidateProperty(model.DamageUpperBoundIron.ToString(), value, model, (m, s) => m.DamageUpperBoundIron = float.Parse(s));
        }

        [Float]
        public string ChanceOfCriticalDamageCloth
        {
            get => model.ChanceOfCriticalDamageCloth.ToString("F6");
            set => SetAndValidateProperty(model.ChanceOfCriticalDamageCloth.ToString(), value, model, (m, s) => m.ChanceOfCriticalDamageCloth = float.Parse(s));
        }

        [Float]
        public string ChanceOfFireCloth
        {
            get => model.ChanceOfFireCloth.ToString("F6");
            set => SetAndValidateProperty(model.ChanceOfFireCloth.ToString(), value, model, (m, s) => m.ChanceOfFireCloth = float.Parse(s));
        }

        [Float]
        public string InitialFireStrengthCloth
        {
            get => model.InitialFireStrengthCloth.ToString("F6");
            set => SetAndValidateProperty(model.InitialFireStrengthCloth.ToString(), value, model, (m, s) => m.InitialFireStrengthCloth = float.Parse(s));
        }

        [Float]
        public string DamageLowerBoundCloth
        {
            get => model.DamageLowerBoundCloth.ToString("F6");
            set => SetAndValidateProperty(model.DamageLowerBoundCloth.ToString(), value, model, (m, s) => m.DamageLowerBoundCloth = float.Parse(s));
        }

        [Float]
        public string DamageUpperBoundCloth
        {
            get => model.DamageUpperBoundCloth.ToString("F6");
            set => SetAndValidateProperty(model.DamageUpperBoundCloth.ToString(), value, model, (m, s) => m.DamageUpperBoundCloth = float.Parse(s));
        }

        [Float]
        public string ChanceOfCriticalDamageStone
        {
            get => model.ChanceOfCriticalDamageStone.ToString("F6");
            set => SetAndValidateProperty(model.ChanceOfCriticalDamageStone.ToString(), value, model, (m, s) => m.ChanceOfCriticalDamageStone = float.Parse(s));
        }

        [Float]
        public string ChanceOfFireStone
        {
            get => model.ChanceOfFireStone.ToString("F6");
            set => SetAndValidateProperty(model.ChanceOfFireStone.ToString(), value, model, (m, s) => m.ChanceOfFireStone = float.Parse(s));
        }

        [Float]
        public string InitialFireStrengthStone
        {
            get => model.InitialFireStrengthStone.ToString("F6");
            set => SetAndValidateProperty(model.InitialFireStrengthStone.ToString(), value, model, (m, s) => m.InitialFireStrengthStone = float.Parse(s));
        }

        [Float]
        public string DamageLowerBoundStone
        {
            get => model.DamageLowerBoundStone.ToString("F6");
            set => SetAndValidateProperty(model.DamageLowerBoundStone.ToString(), value, model, (m, s) => m.DamageLowerBoundStone = float.Parse(s));
        }

        [Float]
        public string DamageUpperBoundStone
        {
            get => model.DamageUpperBoundStone.ToString("F6");
            set => SetAndValidateProperty(model.DamageUpperBoundStone.ToString(), value, model, (m, s) => m.DamageUpperBoundStone = float.Parse(s));
        }

        [Float]
        public string ChanceOfCriticalDamageDragon
        {
            get => model.ChanceOfCriticalDamageDragon.ToString("F6");
            set => SetAndValidateProperty(model.ChanceOfCriticalDamageDragon.ToString(), value, model, (m, s) => m.ChanceOfCriticalDamageDragon = float.Parse(s));
        }

        [Float]
        public string ChanceOfFireDragon
        {
            get => model.ChanceOfFireDragon.ToString("F6");
            set => SetAndValidateProperty(model.ChanceOfFireDragon.ToString(), value, model, (m, s) => m.ChanceOfFireDragon = float.Parse(s));
        }

        [Float]
        public string InitialFireStrengthDragon
        {
            get => model.InitialFireStrengthDragon.ToString("F6");
            set => SetAndValidateProperty(model.InitialFireStrengthDragon.ToString(), value, model, (m, s) => m.InitialFireStrengthDragon = float.Parse(s));
        }

        [Float]
        public string DamageLowerBoundDragon
        {
            get => model.DamageLowerBoundDragon.ToString("F6");
            set => SetAndValidateProperty(model.DamageLowerBoundDragon.ToString(), value, model, (m, s) => m.DamageLowerBoundDragon = float.Parse(s));
        }

        [Float]
        public string DamageUpperBoundDragon
        {
            get => model.DamageUpperBoundDragon.ToString("F6");
            set => SetAndValidateProperty(model.DamageUpperBoundDragon.ToString(), value, model, (m, s) => m.DamageUpperBoundDragon = float.Parse(s));
        }

        public DamagePotentialViewModel(DamagePotential model)
        {
            this.model = model;
        }
    }
}
