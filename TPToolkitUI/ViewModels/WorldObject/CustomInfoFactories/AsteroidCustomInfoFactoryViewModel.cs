using CommunityToolkit.Mvvm.ComponentModel;
using TPToolkitLib.WorldObject;
using TPToolkitLib.WorldObject.Definitions.CustomInfoFactories;
using TPToolkitUI.CustomAttributes;

namespace TPToolkitUI.ViewModels.WorldObject.CustomInfoFactories
{
    public partial class AsteroidCustomInfoFactoryViewModel : CustomInfoDefinitionViewModel<AsteroidCustomInfoFactory>
    {

        [Int]
        public string MaxHitPoints
        {
            get => Model.MaxHitPoints.ToString();
            set => SetAndValidateProperty(Model.MaxHitPoints.ToString(), value, Model, (m, s) => Model.MaxHitPoints = int.Parse(s));
        }

        [ObservableProperty]
        public partial bool HasWorldObjectToCreateUponDeath0 { get; set; }

        public WorldObjectType? WorldObjectToCreateUponDeath0
        {
            get => Model.WorldObjectToCreateUponDeath0;
            set => SetAndValidateProperty(Model.WorldObjectToCreateUponDeath0, value, Model, (m, wot) => m.WorldObjectToCreateUponDeath0 = wot);
        }

        [ObservableProperty]
        public partial bool HasWorldObjectToCreateUponDeath1 { get; set; }

        public WorldObjectType? WorldObjectToCreateUponDeath1
        {
            get => Model.WorldObjectToCreateUponDeath1;
            set => SetAndValidateProperty(Model.WorldObjectToCreateUponDeath1, value, Model, (m, wot) => m.WorldObjectToCreateUponDeath1 = wot);
        }

        [ObservableProperty]
        public partial bool HasWorldObjectToCreateUponDeath2 { get; set; }

        public WorldObjectType? WorldObjectToCreateUponDeath2
        {
            get => Model.WorldObjectToCreateUponDeath2;
            set => SetAndValidateProperty(Model.WorldObjectToCreateUponDeath2, value, Model, (m, wot) => m.WorldObjectToCreateUponDeath2 = wot);
        }

        [ObservableProperty]
        public partial bool HasWorldObjectToCreateUponDeath3 { get; set; }

        public WorldObjectType? WorldObjectToCreateUponDeath3
        {
            get => Model.WorldObjectToCreateUponDeath3;
            set => SetAndValidateProperty(Model.WorldObjectToCreateUponDeath3, value, Model, (m, wot) => m.WorldObjectToCreateUponDeath3 = wot);
        }

        [ObservableProperty]
        public partial bool HasWorldObjectToCreateUponDeath4 { get; set; }

        public WorldObjectType? WorldObjectToCreateUponDeath4
        {
            get => Model.WorldObjectToCreateUponDeath4;
            set => SetAndValidateProperty(Model.WorldObjectToCreateUponDeath4, value, Model, (m, wot) => m.WorldObjectToCreateUponDeath4 = wot);
        }

        [ObservableProperty]
        public partial bool HasWorldObjectToCreateUponDeath5 { get; set; }

        public WorldObjectType? WorldObjectToCreateUponDeath5
        {
            get => Model.WorldObjectToCreateUponDeath5;
            set => SetAndValidateProperty(Model.WorldObjectToCreateUponDeath5, value, Model, (m, wot) => m.WorldObjectToCreateUponDeath5 = wot);
        }

        [ObservableProperty]
        public partial bool HasWorldObjectToCreateUponDeath6 { get; set; }

        public WorldObjectType? WorldObjectToCreateUponDeath6
        {
            get => Model.WorldObjectToCreateUponDeath6;
            set => SetAndValidateProperty(Model.WorldObjectToCreateUponDeath6, value, Model, (m, wot) => m.WorldObjectToCreateUponDeath6 = wot);
        }

        [ObservableProperty]
        public partial bool HasWorldObjectToCreateUponDeath7 { get; set; }

        public WorldObjectType? WorldObjectToCreateUponDeath7
        {
            get => Model.WorldObjectToCreateUponDeath7;
            set => SetAndValidateProperty(Model.WorldObjectToCreateUponDeath7, value, Model, (m, wot) => m.WorldObjectToCreateUponDeath7 = wot);
        }

        [ObservableProperty]
        public partial bool HasWorldObjectToCreateUponDeath8 { get; set; }

        public WorldObjectType? WorldObjectToCreateUponDeath8
        {
            get => Model.WorldObjectToCreateUponDeath8;
            set => SetAndValidateProperty(Model.WorldObjectToCreateUponDeath8, value, Model, (m, wot) => m.WorldObjectToCreateUponDeath8 = wot);
        }

        [ObservableProperty]
        public partial bool HasWorldObjectToCreateUponDeath9 { get; set; }

        public WorldObjectType? WorldObjectToCreateUponDeath9
        {
            get => Model.WorldObjectToCreateUponDeath9;
            set => SetAndValidateProperty(Model.WorldObjectToCreateUponDeath9, value, Model, (m, wot) => m.WorldObjectToCreateUponDeath9 = wot);
        }

        public string ExplosionEffect
        {
            get => Model.ExplosionEffect;
            set => SetAndValidateProperty(Model.ExplosionEffect, value, Model, (m, s) => m.ExplosionEffect = s);
        }

        public bool ReportSpotting
        {
            get => Model.ReportSpotting;
            set => SetAndValidateProperty(Model.ReportSpotting, value, Model, (m, b) => m.ReportSpotting = b);
        }

        public AsteroidCustomInfoFactoryViewModel(AsteroidCustomInfoFactory model) : base(model)
        {
        }

        partial void OnHasWorldObjectToCreateUponDeath0Changed(bool value)
        {
            if (value)
            {
                if (WorldObjectToCreateUponDeath0 == null)
                    WorldObjectToCreateUponDeath0 = AppSettings.Asteroids.FirstOrDefault();
            }
            else
                WorldObjectToCreateUponDeath0 = null;
        }

        partial void OnHasWorldObjectToCreateUponDeath1Changed(bool value)
        {
            if (value)
            {
                if (WorldObjectToCreateUponDeath1 == null)
                    WorldObjectToCreateUponDeath1 = AppSettings.Asteroids.FirstOrDefault();
            }
            else
                WorldObjectToCreateUponDeath1 = null;
        }
        partial void OnHasWorldObjectToCreateUponDeath2Changed(bool value)
        {
            if (value)
            {
                if (WorldObjectToCreateUponDeath2 == null)
                    WorldObjectToCreateUponDeath2 = AppSettings.Asteroids.FirstOrDefault();
            }
            else
                WorldObjectToCreateUponDeath2 = null;
        }
        partial void OnHasWorldObjectToCreateUponDeath3Changed(bool value)
        {
            if (value)
            {
                if (WorldObjectToCreateUponDeath3 == null)
                    WorldObjectToCreateUponDeath3 = AppSettings.Asteroids.FirstOrDefault();
            }
            else
                WorldObjectToCreateUponDeath3 = null;
        }
        partial void OnHasWorldObjectToCreateUponDeath4Changed(bool value)
        {
            if (value)
            {
                if (WorldObjectToCreateUponDeath4 == null)
                    WorldObjectToCreateUponDeath4 = AppSettings.Asteroids.FirstOrDefault();
            }
            else
                WorldObjectToCreateUponDeath4 = null;
        }
        partial void OnHasWorldObjectToCreateUponDeath5Changed(bool value)
        {
            if (value)
            {
                if (WorldObjectToCreateUponDeath5 == null)
                    WorldObjectToCreateUponDeath5 = AppSettings.Asteroids.FirstOrDefault();
            }
            else
                WorldObjectToCreateUponDeath5 = null;
        }
        partial void OnHasWorldObjectToCreateUponDeath6Changed(bool value)
        {
            if (value)
            {
                if (WorldObjectToCreateUponDeath6 == null)
                    WorldObjectToCreateUponDeath6 = AppSettings.Asteroids.FirstOrDefault();
            }
            else
                WorldObjectToCreateUponDeath6 = null;
        }
        partial void OnHasWorldObjectToCreateUponDeath7Changed(bool value)
        {
            if (value)
            {
                if (WorldObjectToCreateUponDeath7 == null)
                    WorldObjectToCreateUponDeath7 = AppSettings.Asteroids.FirstOrDefault();
            }
            else
                WorldObjectToCreateUponDeath7 = null;
        }
        partial void OnHasWorldObjectToCreateUponDeath8Changed(bool value)
        {
            if (value)
            {
                if (WorldObjectToCreateUponDeath8 == null)
                    WorldObjectToCreateUponDeath8 = AppSettings.Asteroids.FirstOrDefault();
            }
            else
                WorldObjectToCreateUponDeath8 = null;
        }
        partial void OnHasWorldObjectToCreateUponDeath9Changed(bool value)
        {
            if (value)
            {
                if (WorldObjectToCreateUponDeath9 == null)
                    WorldObjectToCreateUponDeath9 = AppSettings.Asteroids.FirstOrDefault();
            }
            else
                WorldObjectToCreateUponDeath9 = null;
        }
    }
}
