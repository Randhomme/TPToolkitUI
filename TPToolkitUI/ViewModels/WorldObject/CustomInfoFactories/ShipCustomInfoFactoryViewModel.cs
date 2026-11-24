using CommunityToolkit.Mvvm.ComponentModel;
using TPToolkitLib.Enums;
using TPToolkitLib.TPSettings;
using TPToolkitLib.WorldObject.Definitions.CustomInfoFactories;
using TPToolkitLib.WorldObject.Enums;
using TPToolkitUI.CustomAttributes;

namespace TPToolkitUI.ViewModels.WorldObject.CustomInfoFactories
{
    public partial class ShipCustomInfoFactoryViewModel : CustomInfoDefinitionViewModel<ShipCustomInfoFactory>
    {
        public string ShipBarIconTexture
        {
            get => Model.ShipBarIconTexture;
            set => SetAndValidateProperty(Model.ShipBarIconTexture, value, Model, (m, s) => m.ShipBarIconTexture = s);
        }

        [Float(MinValue = 0)]
        public string SelectedIndicatorPercentageOfRadius
        {
            get => Model.SelectedIndicatorPercentageOfRadius.ToString("F6");
            set => SetAndValidateProperty(Model.SelectedIndicatorPercentageOfRadius.ToString(), value, Model, (m, s) => m.SelectedIndicatorPercentageOfRadius = float.Parse(s));
        }

        [Float(MinValue = 0)]
        public string DistanceToStartSpherePicking
        {
            get => Model.DistanceToStartSpherePicking.ToString("F6");
            set => SetAndValidateProperty(Model.DistanceToStartSpherePicking.ToString(), value, Model, (m, s) => m.DistanceToStartSpherePicking = float.Parse(s));
        }

        [ObservableProperty]
        public partial TPGameHeaderStrings SelectedDisplayableShipnameStringIDGameHeader { get; set; }

        public IEnumerable<KeyValuePair<string, string>> AvailableDisplayableShipnameStringIDS { get => SelectedDisplayableShipnameStringIDGameHeader.Strings; }

        public string DisplayableShipnameStringID
        {
            get => Model.DisplayableShipnameStringID;
            set => SetAndValidateProperty(Model.DisplayableShipnameStringID, value, Model, (m, s) => m.DisplayableShipnameStringID = s);
        }

        public Race ShipRace
        {
            get => Model.ShipRace;
            set => SetAndValidateProperty(Model.ShipRace, value, Model, (m, r) => m.ShipRace = r);
        }

        public bool IsTender
        {
            get => Model.IsTender;
            set => SetAndValidateProperty(Model.IsTender, value, Model, (m, b) => m.IsTender = b);
        }

        [Int(MinValue = 0)]
        public string NumberOfLifeboats
        {
            get => Model.NumberOfLifeboats.ToString();
            set => SetAndValidateProperty(Model.NumberOfLifeboats.ToString(), value, Model, (m, s) => m.NumberOfLifeboats = int.Parse(s));
        }

        public bool IsLifeboat
        {
            get => Model.IsLifeboat;
            set => SetAndValidateProperty(Model.IsLifeboat, value, Model, (m, b) => m.IsLifeboat = b);
        }

        public bool IsCloakable
        {
            get => Model.IsCloakable;
            set => SetAndValidateProperty(Model.IsCloakable, value, Model, (m, b) => m.IsCloakable = b);
        }

        [Int]
        public string ShipSize
        {
            get => Model.ShipSize.ToString();
            set => SetAndValidateProperty(Model.ShipSize.ToString(), value, Model, (m, s) => m.ShipSize = int.Parse(s));
        }

        [Int]
        public string CoreDamageSectionMaxHitPoints
        {
            get => Model.CoreDamageSectionMaxHitPoints.ToString();
            set => SetAndValidateProperty(Model.CoreDamageSectionMaxHitPoints.ToString(), value, Model, (m, s) => m.CoreDamageSectionMaxHitPoints = int.Parse(s));
        }

        public string ExplosionEffectName
        {
            get => Model.ExplosionEffectName;
            set => SetAndValidateProperty(Model.ExplosionEffectName, value, Model, (m, s) => m.ExplosionEffectName = s);
        }

        public EngineType EngineType
        {
            get => Model.EngineType;
            set => SetAndValidateProperty(Model.EngineType, value, Model, (m, et) => m.EngineType = et);
        }

        [ObservableProperty]
        public partial bool HasEngineSoundNameEmergency { get; set; }

        public string EngineSoundNameEmergency
        {
            get => Model.EngineSoundNameEmergency;
            set => SetAndValidateProperty(Model.EngineSoundNameEmergency, value, Model, (m, s) => m.EngineSoundNameEmergency = s);
        }

        [ObservableProperty]
        public partial bool HasEngineSoundNameFull { get; set; }

        public string EngineSoundNameFull
        {
            get => Model.EngineSoundNameFull;
            set => SetAndValidateProperty(Model.EngineSoundNameFull, value, Model, (m, s) => m.EngineSoundNameFull = s);
        }

        [ObservableProperty]
        public partial bool HasEngineSoundNameHalf { get; set; }

        public string EngineSoundNameHalf
        {
            get => Model.EngineSoundNameHalf;
            set => SetAndValidateProperty(Model.EngineSoundNameHalf, value, Model, (m, s) => m.EngineSoundNameHalf = s);
        }

        [Int]
        public string VictoryPointCost
        {
            get => Model.VictoryPointCost.ToString();
            set => SetAndValidateProperty(Model.VictoryPointCost.ToString(), value, Model, (m, s) => m.VictoryPointCost = int.Parse(s));
        }

        public bool IsAvailableInMultiplayer
        {
            get => Model.IsAvailableInMultiplayer;
            set => SetAndValidateProperty(Model.IsAvailableInMultiplayer, value, Model, (m, b) => m.IsAvailableInMultiplayer = b);
        }

        [ObservableProperty]
        public partial TPGameHeaderStrings SelectedAvailableUniqueShipNameID00GameHeader { get; set; }
        [ObservableProperty]
        public partial TPGameHeaderStrings SelectedAvailableUniqueShipNameID01GameHeader { get; set; }
        [ObservableProperty]
        public partial TPGameHeaderStrings SelectedAvailableUniqueShipNameID02GameHeader { get; set; }
        [ObservableProperty]
        public partial TPGameHeaderStrings SelectedAvailableUniqueShipNameID03GameHeader { get; set; }
        [ObservableProperty]
        public partial TPGameHeaderStrings SelectedAvailableUniqueShipNameID04GameHeader { get; set; }
        [ObservableProperty]
        public partial TPGameHeaderStrings SelectedAvailableUniqueShipNameID05GameHeader { get; set; }
        [ObservableProperty]
        public partial TPGameHeaderStrings SelectedAvailableUniqueShipNameID06GameHeader { get; set; }
        [ObservableProperty]
        public partial TPGameHeaderStrings SelectedAvailableUniqueShipNameID07GameHeader { get; set; }
        [ObservableProperty]
        public partial TPGameHeaderStrings SelectedAvailableUniqueShipNameID08GameHeader { get; set; }
        [ObservableProperty]
        public partial TPGameHeaderStrings SelectedAvailableUniqueShipNameID09GameHeader { get; set; }
        [ObservableProperty]
        public partial TPGameHeaderStrings SelectedAvailableUniqueShipNameID10GameHeader { get; set; }
        [ObservableProperty]
        public partial TPGameHeaderStrings SelectedAvailableUniqueShipNameID11GameHeader { get; set; }

        public IEnumerable<KeyValuePair<string, string>> AvailableAvailableUniqueShipNameIDS00 { get => SelectedAvailableUniqueShipNameID00GameHeader.Strings; }
        public IEnumerable<KeyValuePair<string, string>> AvailableAvailableUniqueShipNameIDS01 { get => SelectedAvailableUniqueShipNameID01GameHeader.Strings; }
        public IEnumerable<KeyValuePair<string, string>> AvailableAvailableUniqueShipNameIDS02 { get => SelectedAvailableUniqueShipNameID02GameHeader.Strings; }
        public IEnumerable<KeyValuePair<string, string>> AvailableAvailableUniqueShipNameIDS03 { get => SelectedAvailableUniqueShipNameID03GameHeader.Strings; }
        public IEnumerable<KeyValuePair<string, string>> AvailableAvailableUniqueShipNameIDS04 { get => SelectedAvailableUniqueShipNameID04GameHeader.Strings; }
        public IEnumerable<KeyValuePair<string, string>> AvailableAvailableUniqueShipNameIDS05 { get => SelectedAvailableUniqueShipNameID05GameHeader.Strings; }
        public IEnumerable<KeyValuePair<string, string>> AvailableAvailableUniqueShipNameIDS06 { get => SelectedAvailableUniqueShipNameID06GameHeader.Strings; }
        public IEnumerable<KeyValuePair<string, string>> AvailableAvailableUniqueShipNameIDS07 { get => SelectedAvailableUniqueShipNameID07GameHeader.Strings; }
        public IEnumerable<KeyValuePair<string, string>> AvailableAvailableUniqueShipNameIDS08 { get => SelectedAvailableUniqueShipNameID08GameHeader.Strings; }
        public IEnumerable<KeyValuePair<string, string>> AvailableAvailableUniqueShipNameIDS09 { get => SelectedAvailableUniqueShipNameID09GameHeader.Strings; }
        public IEnumerable<KeyValuePair<string, string>> AvailableAvailableUniqueShipNameIDS10 { get => SelectedAvailableUniqueShipNameID10GameHeader.Strings; }
        public IEnumerable<KeyValuePair<string, string>> AvailableAvailableUniqueShipNameIDS11 { get => SelectedAvailableUniqueShipNameID11GameHeader.Strings; }

        public string AvailableUniqueShipNameID00
        {
            get => Model.AvailableUniqueShipNameID00;
            set => SetAndValidateProperty(Model.AvailableUniqueShipNameID00, value, Model, (m, s) => m.AvailableUniqueShipNameID00 = s);
        }
        public string AvailableUniqueShipNameID01
        {
            get => Model.AvailableUniqueShipNameID01;
            set => SetAndValidateProperty(Model.AvailableUniqueShipNameID01, value, Model, (m, s) => m.AvailableUniqueShipNameID01 = s);
        }
        public string AvailableUniqueShipNameID02
        {
            get => Model.AvailableUniqueShipNameID02;
            set => SetAndValidateProperty(Model.AvailableUniqueShipNameID02, value, Model, (m, s) => m.AvailableUniqueShipNameID02 = s);
        }
        public string AvailableUniqueShipNameID03
        {
            get => Model.AvailableUniqueShipNameID03;
            set => SetAndValidateProperty(Model.AvailableUniqueShipNameID03, value, Model, (m, s) => m.AvailableUniqueShipNameID03 = s);
        }
        public string AvailableUniqueShipNameID04
        {
            get => Model.AvailableUniqueShipNameID04;
            set => SetAndValidateProperty(Model.AvailableUniqueShipNameID04, value, Model, (m, s) => m.AvailableUniqueShipNameID04 = s);
        }
        public string AvailableUniqueShipNameID05
        {
            get => Model.AvailableUniqueShipNameID05;
            set => SetAndValidateProperty(Model.AvailableUniqueShipNameID05, value, Model, (m, s) => m.AvailableUniqueShipNameID05 = s);
        }
        public string AvailableUniqueShipNameID06
        {
            get => Model.AvailableUniqueShipNameID06;
            set => SetAndValidateProperty(Model.AvailableUniqueShipNameID06, value, Model, (m, s) => m.AvailableUniqueShipNameID06 = s);
        }
        public string AvailableUniqueShipNameID07
        {
            get => Model.AvailableUniqueShipNameID07;
            set => SetAndValidateProperty(Model.AvailableUniqueShipNameID07, value, Model, (m, s) => m.AvailableUniqueShipNameID07 = s);
        }
        public string AvailableUniqueShipNameID08
        {
            get => Model.AvailableUniqueShipNameID08;
            set => SetAndValidateProperty(Model.AvailableUniqueShipNameID08, value, Model, (m, s) => m.AvailableUniqueShipNameID08 = s);
        }
        public string AvailableUniqueShipNameID09
        {
            get => Model.AvailableUniqueShipNameID09;
            set => SetAndValidateProperty(Model.AvailableUniqueShipNameID09, value, Model, (m, s) => m.AvailableUniqueShipNameID09 = s);
        }
        public string AvailableUniqueShipNameID10
        {
            get => Model.AvailableUniqueShipNameID10;
            set => SetAndValidateProperty(Model.AvailableUniqueShipNameID10, value, Model, (m, s) => m.AvailableUniqueShipNameID10 = s);
        }
        public string AvailableUniqueShipNameID11
        {
            get => Model.AvailableUniqueShipNameID11;
            set => SetAndValidateProperty(Model.AvailableUniqueShipNameID11, value, Model, (m, s) => m.AvailableUniqueShipNameID11 = s);
        }

        [Int(MinValue = 0)]
        public string MaxNumberOfGunners
        {
            get => Model.MaxNumberOfGunners.ToString();
            set => SetAndValidateProperty(Model.MaxNumberOfGunners.ToString(), value, Model, (m, s) => m.MaxNumberOfGunners = int.Parse(s));
        }

        [Int(MinValue = 0)]
        public string MaxNumberOfCaptains
        {
            get => Model.MaxNumberOfCaptains.ToString();
            set => SetAndValidateProperty(Model.MaxNumberOfCaptains.ToString(), value, Model, (m, s) => m.MaxNumberOfCaptains = int.Parse(s));
        }

        [Int(MinValue = 0)]
        public string MaxNumberOfFirstMates
        {
            get => Model.MaxNumberOfFirstMates.ToString();
            set => SetAndValidateProperty(Model.MaxNumberOfFirstMates.ToString(), value, Model, (m, s) => m.MaxNumberOfFirstMates = int.Parse(s));
        }

        [Int(MinValue = 0)]
        public string MaxNumberOfNavigators
        {
            get => Model.MaxNumberOfNavigators.ToString();
            set => SetAndValidateProperty(Model.MaxNumberOfNavigators.ToString(), value, Model, (m, s) => m.MaxNumberOfNavigators = int.Parse(s));
        }

        [Int(MinValue = 0)]
        public string MaxNumberOfEngineers
        {
            get => Model.MaxNumberOfEngineers.ToString();
            set => SetAndValidateProperty(Model.MaxNumberOfEngineers.ToString(), value, Model, (m, s) => m.MaxNumberOfEngineers = int.Parse(s));
        }

        [Int(MinValue = 0)]
        public string MaxNumberOfRiggers
        {
            get => Model.MaxNumberOfRiggers.ToString();
            set => SetAndValidateProperty(Model.MaxNumberOfRiggers.ToString(), value, Model, (m, s) => m.MaxNumberOfRiggers = int.Parse(s));
        }

        [Int(MinValue = 0)]
        public string MaxNumberOfFighters
        {
            get => Model.MaxNumberOfFighters.ToString();
            set => SetAndValidateProperty(Model.MaxNumberOfFighters.ToString(), value, Model, (m, s) => m.MaxNumberOfFighters = int.Parse(s));
        }

        [Int(MinValue = 0)]
        public string MaxNumberOfLookouts
        {
            get => Model.MaxNumberOfLookouts.ToString();
            set => SetAndValidateProperty(Model.MaxNumberOfLookouts.ToString(), value, Model, (m, s) => m.MaxNumberOfLookouts = int.Parse(s));
        }

        public string RepairEffectName
        {
            get => Model.RepairEffectName;
            set => SetAndValidateProperty(Model.RepairEffectName, value, Model, (m, s) => m.RepairEffectName = s);
        }

        public ShipCustomInfoFactoryViewModel(ShipCustomInfoFactory model) : base(model)
        {
            SelectedDisplayableShipnameStringIDGameHeader = AppSettings.TPGameHeaderStrings.FirstOrDefault((tpghs) => tpghs.Strings.ContainsKey(model.DisplayableShipnameStringID));
            SelectedAvailableUniqueShipNameID00GameHeader = AppSettings.TPGameHeaderStrings.FirstOrDefault((tpghs) => tpghs.Strings.ContainsKey(model.AvailableUniqueShipNameID00));
            SelectedAvailableUniqueShipNameID01GameHeader = AppSettings.TPGameHeaderStrings.FirstOrDefault((tpghs) => tpghs.Strings.ContainsKey(model.AvailableUniqueShipNameID01));
            SelectedAvailableUniqueShipNameID02GameHeader = AppSettings.TPGameHeaderStrings.FirstOrDefault((tpghs) => tpghs.Strings.ContainsKey(model.AvailableUniqueShipNameID02));
            SelectedAvailableUniqueShipNameID03GameHeader = AppSettings.TPGameHeaderStrings.FirstOrDefault((tpghs) => tpghs.Strings.ContainsKey(model.AvailableUniqueShipNameID03));
            SelectedAvailableUniqueShipNameID04GameHeader = AppSettings.TPGameHeaderStrings.FirstOrDefault((tpghs) => tpghs.Strings.ContainsKey(model.AvailableUniqueShipNameID04));
            SelectedAvailableUniqueShipNameID05GameHeader = AppSettings.TPGameHeaderStrings.FirstOrDefault((tpghs) => tpghs.Strings.ContainsKey(model.AvailableUniqueShipNameID05));
            SelectedAvailableUniqueShipNameID06GameHeader = AppSettings.TPGameHeaderStrings.FirstOrDefault((tpghs) => tpghs.Strings.ContainsKey(model.AvailableUniqueShipNameID06));
            SelectedAvailableUniqueShipNameID07GameHeader = AppSettings.TPGameHeaderStrings.FirstOrDefault((tpghs) => tpghs.Strings.ContainsKey(model.AvailableUniqueShipNameID07));
            SelectedAvailableUniqueShipNameID08GameHeader = AppSettings.TPGameHeaderStrings.FirstOrDefault((tpghs) => tpghs.Strings.ContainsKey(model.AvailableUniqueShipNameID08));
            SelectedAvailableUniqueShipNameID09GameHeader = AppSettings.TPGameHeaderStrings.FirstOrDefault((tpghs) => tpghs.Strings.ContainsKey(model.AvailableUniqueShipNameID09));
            SelectedAvailableUniqueShipNameID10GameHeader = AppSettings.TPGameHeaderStrings.FirstOrDefault((tpghs) => tpghs.Strings.ContainsKey(model.AvailableUniqueShipNameID10));
            SelectedAvailableUniqueShipNameID11GameHeader = AppSettings.TPGameHeaderStrings.FirstOrDefault((tpghs) => tpghs.Strings.ContainsKey(model.AvailableUniqueShipNameID11));
        }

        partial void OnSelectedDisplayableShipnameStringIDGameHeaderChanged(TPGameHeaderStrings oldValue, TPGameHeaderStrings newValue)
        {
            if (oldValue != null)
            {
                OnPropertyChanged(nameof(AvailableDisplayableShipnameStringIDS));
                DisplayableShipnameStringID = newValue.Strings.Keys.FirstOrDefault();
            }
        }

        partial void OnHasEngineSoundNameEmergencyChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(EngineSoundNameEmergency))
                    EngineSoundNameEmergency = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                EngineSoundNameEmergency = string.Empty;
        }

        partial void OnHasEngineSoundNameFullChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(EngineSoundNameFull))
                    EngineSoundNameFull = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                EngineSoundNameFull = string.Empty;
        }

        partial void OnHasEngineSoundNameHalfChanged(bool value)
        {
            if (value)
            {
                if (string.IsNullOrWhiteSpace(EngineSoundNameHalf))
                    EngineSoundNameHalf = AppSettings.SoundEffects.FirstOrDefault();
            }
            else
                EngineSoundNameHalf = string.Empty;
        }

        partial void OnSelectedAvailableUniqueShipNameID00GameHeaderChanged(TPGameHeaderStrings oldValue, TPGameHeaderStrings newValue)
        {
            if (oldValue != null)
            {
                OnPropertyChanged(nameof(AvailableAvailableUniqueShipNameIDS00));
                AvailableUniqueShipNameID00 = newValue.Strings.Keys.FirstOrDefault();
            }
        }

        partial void OnSelectedAvailableUniqueShipNameID01GameHeaderChanged(TPGameHeaderStrings oldValue, TPGameHeaderStrings newValue)
        {
            if (oldValue != null)
            {
                OnPropertyChanged(nameof(AvailableAvailableUniqueShipNameIDS01));
                AvailableUniqueShipNameID01 = newValue.Strings.Keys.FirstOrDefault();
            }
        }
        partial void OnSelectedAvailableUniqueShipNameID02GameHeaderChanged(TPGameHeaderStrings oldValue, TPGameHeaderStrings newValue)
        {
            if (oldValue != null)
            {
                OnPropertyChanged(nameof(AvailableAvailableUniqueShipNameIDS02));
                AvailableUniqueShipNameID02 = newValue.Strings.Keys.FirstOrDefault();
            }
        }
        partial void OnSelectedAvailableUniqueShipNameID03GameHeaderChanged(TPGameHeaderStrings oldValue, TPGameHeaderStrings newValue)
        {
            if (oldValue != null)
            {
                OnPropertyChanged(nameof(AvailableAvailableUniqueShipNameIDS03));
                AvailableUniqueShipNameID03 = newValue.Strings.Keys.FirstOrDefault();
            }
        }
        partial void OnSelectedAvailableUniqueShipNameID04GameHeaderChanged(TPGameHeaderStrings oldValue, TPGameHeaderStrings newValue)
        {
            if (oldValue != null)
            {
                OnPropertyChanged(nameof(AvailableAvailableUniqueShipNameIDS04));
                AvailableUniqueShipNameID04 = newValue.Strings.Keys.FirstOrDefault();
            }
        }
        partial void OnSelectedAvailableUniqueShipNameID05GameHeaderChanged(TPGameHeaderStrings oldValue, TPGameHeaderStrings newValue)
        {
            if (oldValue != null)
            {
                OnPropertyChanged(nameof(AvailableAvailableUniqueShipNameIDS05));
                AvailableUniqueShipNameID05 = newValue.Strings.Keys.FirstOrDefault();
            }
        }
        partial void OnSelectedAvailableUniqueShipNameID06GameHeaderChanged(TPGameHeaderStrings oldValue, TPGameHeaderStrings newValue)
        {
            if (oldValue != null)
            {
                OnPropertyChanged(nameof(AvailableAvailableUniqueShipNameIDS06));
                AvailableUniqueShipNameID06 = newValue.Strings.Keys.FirstOrDefault();
            }
        }
        partial void OnSelectedAvailableUniqueShipNameID07GameHeaderChanged(TPGameHeaderStrings oldValue, TPGameHeaderStrings newValue)
        {
            if (oldValue != null)
            {
                OnPropertyChanged(nameof(AvailableAvailableUniqueShipNameIDS07));
                AvailableUniqueShipNameID07 = newValue.Strings.Keys.FirstOrDefault();
            }
        }
        partial void OnSelectedAvailableUniqueShipNameID08GameHeaderChanged(TPGameHeaderStrings oldValue, TPGameHeaderStrings newValue)
        {
            if (oldValue != null)
            {
                OnPropertyChanged(nameof(AvailableAvailableUniqueShipNameIDS08));
                AvailableUniqueShipNameID08 = newValue.Strings.Keys.FirstOrDefault();
            }
        }
        partial void OnSelectedAvailableUniqueShipNameID09GameHeaderChanged(TPGameHeaderStrings oldValue, TPGameHeaderStrings newValue)
        {
            if (oldValue != null)
            {
                OnPropertyChanged(nameof(AvailableAvailableUniqueShipNameIDS09));
                AvailableUniqueShipNameID09 = newValue.Strings.Keys.FirstOrDefault();
            }
        }
        partial void OnSelectedAvailableUniqueShipNameID10GameHeaderChanged(TPGameHeaderStrings oldValue, TPGameHeaderStrings newValue)
        {
            if (oldValue != null)
            {
                OnPropertyChanged(nameof(AvailableAvailableUniqueShipNameIDS10));
                AvailableUniqueShipNameID10 = newValue.Strings.Keys.FirstOrDefault();
            }
        }
        partial void OnSelectedAvailableUniqueShipNameID11GameHeaderChanged(TPGameHeaderStrings oldValue, TPGameHeaderStrings newValue)
        {
            if (oldValue != null)
            {
                OnPropertyChanged(nameof(AvailableAvailableUniqueShipNameIDS11));
                AvailableUniqueShipNameID11 = newValue.Strings.Keys.FirstOrDefault();
            }
        }
    }
}
