using CommunityToolkit.Mvvm.ComponentModel;
using TPToolkitLib.Enums;
using TPToolkitLib.Tools;
using TPToolkitLib.TPSettings;
using TPToolkitLib.WorldObject.Definitions.CustomInfoFactories;
using TPToolkitLib.WorldObject.Enums;
using TPToolkitUI.CustomAttributes;

namespace TPToolkitUI.ViewModels.WorldObject.CustomInfoFactories
{
    public partial class CrewCustomInfoFactoryViewModel : CustomInfoDefinitionViewModel<CrewCustomInfoFactory>
    {
        public Race CrewRace
        {
            get => Model.CrewRace;
            set => SetAndValidateProperty(Model.CrewRace, value, Model, (m, r) => m.CrewRace = r);
        }

        [Int]
        public string PointValue
        {
            get => Model.PointValue.ToString();
            set => SetAndValidateProperty(Model.PointValue.ToString(), value, Model, (m, s) => m.PointValue = int.Parse(s));
        }

        [ObservableProperty]
        public partial TPGameHeaderStrings SelectedCrewNameStringIDGameHeader { get; set; }

        public string CrewNameStringID
        {
            get => Model.CrewNameStringID;
            set => SetAndValidateProperty(Model.CrewNameStringID, value, Model, (m, s) => m.CrewNameStringID = s);
        }

        public bool LeadershipSkillActive
        {
            get => Model.LeadershipSkillActive;
            set => SetAndValidateProperty(Model.LeadershipSkillActive, value, Model, (m, b) => m.LeadershipSkillActive = b);
        }

        [Int]
        public string LeadershipSkillAbilityValue
        {
            get => Model.LeadershipSkillAbilityValue.ToString();
            set => SetAndValidateProperty(Model.LeadershipSkillAbilityValue.ToString(), value, Model, (m, s) => m.LeadershipSkillAbilityValue = int.Parse(s));
        }

        public bool NavigationSkillActive
        {
            get => Model.NavigationSkillActive;
            set => SetAndValidateProperty(Model.NavigationSkillActive, value, Model, (m, b) => m.NavigationSkillActive = b);
        }

        [Int]
        public string NavigationSkillAbilityValue
        {
            get => Model.NavigationSkillAbilityValue.ToString();
            set => SetAndValidateProperty(Model.NavigationSkillAbilityValue.ToString(), value, Model, (m, s) => m.NavigationSkillAbilityValue = int.Parse(s));
        }

        public bool SpottingSkillActive
        {
            get => Model.SpottingSkillActive;
            set => SetAndValidateProperty(Model.SpottingSkillActive, value, Model, (m, b) => m.SpottingSkillActive = b);
        }

        [Int]
        public string SpottingSkillAbilityValue
        {
            get => Model.SpottingSkillAbilityValue.ToString();
            set => SetAndValidateProperty(Model.SpottingSkillAbilityValue.ToString(), value, Model, (m, s) => m.SpottingSkillAbilityValue = int.Parse(s));
        }

        public bool EngineeringSkillActive
        {
            get => Model.EngineeringSkillActive;
            set => SetAndValidateProperty(Model.EngineeringSkillActive, value, Model, (m, b) => m.EngineeringSkillActive = b);
        }

        [Int]
        public string EngineeringSkillAbilityValue
        {
            get => Model.EngineeringSkillAbilityValue.ToString();
            set => SetAndValidateProperty(Model.EngineeringSkillAbilityValue.ToString(), value, Model, (m, s) => m.EngineeringSkillAbilityValue = int.Parse(s));
        }

        public bool RiggingSkillActive
        {
            get => Model.RiggingSkillActive;
            set => SetAndValidateProperty(Model.RiggingSkillActive, value, Model, (m, b) => m.RiggingSkillActive = b);
        }

        [Int]
        public string RiggingSkillAbilityValue
        {
            get => Model.RiggingSkillAbilityValue.ToString();
            set => SetAndValidateProperty(Model.RiggingSkillAbilityValue.ToString(), value, Model, (m, s) => m.RiggingSkillAbilityValue = int.Parse(s));
        }

        public bool CombatSkillActive
        {
            get => Model.CombatSkillActive;
            set => SetAndValidateProperty(Model.CombatSkillActive, value, Model, (m, b) => m.CombatSkillActive = b);
        }

        [Int]
        public string CombatSkillAbilityValue
        {
            get => Model.CombatSkillAbilityValue.ToString();
            set => SetAndValidateProperty(Model.CombatSkillAbilityValue.ToString(), value, Model, (m, s) => m.CombatSkillAbilityValue = int.Parse(s));
        }

        public bool GunnerySkillActive
        {
            get => Model.GunnerySkillActive;
            set => SetAndValidateProperty(Model.GunnerySkillActive, value, Model, (m, b) => m.GunnerySkillActive = b);
        }

        [Int]
        public string GunnerySkillAbilityValue
        {
            get => Model.GunnerySkillAbilityValue.ToString();
            set => SetAndValidateProperty(Model.GunnerySkillAbilityValue.ToString(), value, Model, (m, s) => m.GunnerySkillAbilityValue = int.Parse(s));
        }

        public string TalkingHeadTexture
        {
            get => Model.TalkingHeadTexture;
            set => SetAndValidateProperty(Model.TalkingHeadTexture, value, Model, (m, s) => m.TalkingHeadTexture = s);
        }

        public Species Species
        {
            get => Model.Species;
            set => SetAndValidateProperty(Model.Species, value, Model, (m, s) => m.Species = s);
        }

        public IEnumerable<KeyValuePair<string, string>> AvailableCrewNameStringIDS { get => SelectedCrewNameStringIDGameHeader.Strings; }

        public CrewCustomInfoFactoryViewModel(CrewCustomInfoFactory model) : base(model)
        {
            SelectedCrewNameStringIDGameHeader = AppSettings.TPGameHeaderStrings.FirstOrDefault((tpghs) => tpghs.Strings.ContainsKey(model.CrewNameStringID));
        }

        partial void OnSelectedCrewNameStringIDGameHeaderChanged(TPGameHeaderStrings oldValue, TPGameHeaderStrings newValue)
        {
            if (oldValue != null)
            {
                OnPropertyChanged(nameof(AvailableCrewNameStringIDS));
                CrewNameStringID = newValue.Strings.Keys.FirstOrDefault();
            }
        }
    }
}
