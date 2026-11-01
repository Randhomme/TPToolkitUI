using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.IO;
using TPToolkitLib.MeshScene.Classes;
using TPToolkitLib.Tools;
using TPToolkitUI.Services;
using TPToolkitUI.Utils;
using TPToolkitUI.ViewModels.MeshScene;

namespace TPToolkitUI.ViewModels
{
    public partial class MeshSceneViewModel : ObservableObject
    {
        private readonly IDialogService dialogService;
        private IList<MsbNode> msbNodesToBeAdded = [];
        private IList<MsbMesh> msbMeshesToBeAdded = [];
        private IList<MsbBone> msbBonesToBeAdded = [];
        private IList<MsbAnimation> msbAnimationsToBeAdded = [];

        public ObservableCollection<MsbNodeViewModel> Nodes { get; } = [];
        public ObservableCollection<MsbMeshViewModel> Meshes { get; } = [];
        public ObservableCollection<MsbBoneViewModel> Bones { get; } = [];
        public ObservableCollection<MsbAnimationViewModel> Animations { get; } = [];
        private readonly CompositeObservableCollection<MsbElementViewModel> msbElements;

        public AppSettings Settings { get; }

        public MeshSceneViewModel(IDialogService dialogService, AppSettings settings)
        {
            this.dialogService = dialogService;
            Settings = settings;
            msbElements = new(Nodes, Meshes, Bones);
        }

        [RelayCommand]
        private void OnAddMsbNode()
        {
            var elementName = dialogService.PromptMsbElementName(Nodes, Meshes, Bones, Animations);
            if (elementName != null)
                Nodes.Add(new(new(), Nodes, Meshes, Bones, Animations, msbElements) { Name = elementName });
        }

        [RelayCommand]
        private void OnAddMsbMesh()
        {
            Meshes.Add(new(new(), Nodes, Meshes, Bones, Animations, msbElements) { Name = TPGameTool.Meshes.FirstOrDefault() });
        }

        [RelayCommand]
        private void OnAddMsbBone()
        {
            var elementName = dialogService.PromptMsbElementName(Nodes, Meshes, Bones, Animations);
            if (elementName != null)
                Bones.Add(new(new(), Nodes, Meshes, Bones, Animations, msbElements) { Name = elementName });
        }

        [RelayCommand]
        private void OnAddMsbAnimation()
        {
            var elementName = dialogService.PromptMsbElementName(Nodes, Meshes, Bones, Animations);
            if (elementName != null)
                Animations.Add(new(new(), Nodes, Meshes, Bones, Animations) { Name = elementName });
        }

        private string GenerateName(string prefix, params IEnumerable<IMsbNamedElement>[] collections)
        {
            string newPrefix = prefix;
            int i = newPrefix.Length - 1;
            while (i >= 0 && char.IsDigit(newPrefix[i]))
            {
                i--;
            }

            if (i < newPrefix.Length - 1)
            {
                newPrefix = newPrefix.Substring(0, i + 1);
            }
            var c = 0;
            bool shouldKeppSameName = true;
            foreach (var collection in collections)
            {
                foreach (var namedMapObject in collection)
                {
                    if (namedMapObject.Name.StartsWith(newPrefix))
                    {
                        if (namedMapObject.Name.Equals(prefix))
                            shouldKeppSameName = false;
                        var s = namedMapObject.Name.Substring(newPrefix.Length);
                        if (int.TryParse(s, out int j))
                        {
                            if (j > c) c = j;
                        }
                    }
                }
            }
            return shouldKeppSameName ? prefix : newPrefix + (c + 1);
        }

        private MsbScene GenerateMsbSceneForExport(string msbSceneName)
        {
            var msbScene = new MsbScene() { Name = msbSceneName };
            for (int i = 0; i < Nodes.Count; i++)
                msbScene.MsbNodes.Add(Nodes[i].Model);
            for (int i = 0; i < Meshes.Count; i++)
                msbScene.MsbMeshes.Add(Meshes[i].Model);
            for (int i = 0; i < Bones.Count; i++)
                msbScene.MsbBones.Add(Bones[i].Model);
            for (int i = 0; i < Animations.Count; i++)
                msbScene.MsbAnimations.Add(Animations[i].Model);
            msbScene.RootMsbElement = FindRootElement(msbScene);
            return msbScene;
        }

        private MsbElement? FindRootElement(MsbScene msbScene)
        {
            for (int i = 0; i < msbScene.MsbNodes.Count; i++)
            {
                var e = msbScene.MsbNodes[i];
                if (e.Parent == null)
                    return e;
            }
            for (int i = 0; i < msbScene.MsbMeshes.Count; i++)
            {
                var e = msbScene.MsbMeshes[i];
                if (e.Parent == null)
                    return e;
            }
            return null;
        }

        public void ImportMeshScene(string[] msbFilePaths, IProgress<string> progress, IProgress<string> logs)
        {
            progress.Report("Importing mesh scene ...");
            try
            {
                var newMsbScene = MsbTool.MeshSceneFromMsbs(msbFilePaths);
                msbNodesToBeAdded = newMsbScene.MsbNodes;
                msbMeshesToBeAdded = newMsbScene.MsbMeshes;
                msbBonesToBeAdded = newMsbScene.MsbBones;
                msbAnimationsToBeAdded = newMsbScene.MsbAnimations;
                progress.Report("Mesh scene successfully imported !");
            }
            catch (Exception ex)
            {
                logs.Report(ex.Message);
                progress.Report("Fail to import mesh scene");
            }
        }

        public void ExportMeshScene(string msbFilePath, IProgress<string> progress, IProgress<string> logs)
        {
            progress.Report("Importing mesh scene ...");
            try
            {
                MsbTool.MeshSceneToMsb(GenerateMsbSceneForExport(Path.GetFileName(msbFilePath)), msbFilePath);
                progress.Report("Mesh scene successfully exported !");
            }
            catch (Exception ex)
            {
                logs.Report(ex.Message);
                progress.Report("Fail to export mesh scene");
            }
        }

        public void ClearMeshScene()
        {
            Nodes.Clear();
            Meshes.Clear();
            Bones.Clear();
            Animations.Clear();
        }

        public void UpdateCollections()
        {
            for (int i = 0; i < msbNodesToBeAdded.Count; i++)
            {
                var msbNode = msbNodesToBeAdded[i];
                Nodes.Add(new(msbNode, Nodes, Meshes, Bones, Animations, msbElements) { Name = GenerateName(msbNode.Name, Nodes, Meshes, Bones, Animations) });
            }
            for (int i = 0; i < msbMeshesToBeAdded.Count; i++)
                Meshes.Add(new(msbMeshesToBeAdded[i], Nodes, Meshes, Bones, Animations, msbElements));
            for (int i = 0; i < msbBonesToBeAdded.Count; i++)
            {
                var msbBone = msbBonesToBeAdded[i];
                Bones.Add(new(msbBone, Nodes, Meshes, Bones, Animations, msbElements) { Name = GenerateName(msbBone.Name, Nodes, Meshes, Bones, Animations) });
            }
            for (int i = 0; i < msbAnimationsToBeAdded.Count; i++)
            {
                var msbAnimation = msbAnimationsToBeAdded[i];
                Animations.Add(new(msbAnimation, Nodes, Meshes, Bones, Animations) { Name = GenerateName(msbAnimation.Name, Nodes, Meshes, Bones, Animations) });
            }
            msbNodesToBeAdded.Clear();
            msbMeshesToBeAdded.Clear();
            msbBonesToBeAdded.Clear();
            msbAnimationsToBeAdded.Clear();
        }
    }
}
