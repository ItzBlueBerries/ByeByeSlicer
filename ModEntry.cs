using MelonLoader;

namespace ByeByeSlicer
{
    public class ModEntry : MelonMod
    {
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            int slicerZoneCount = 0;
            int slicerZonePrefabCount = 0;
            int slicerControllerCount = 0;
            int slicerSectionControllerCount = 0;

            foreach (SlicerZone component in UnityEngine.Object.FindObjectsOfType<SlicerZone>())
            {
                if (component.gameObject.name.Contains("Prefab_Slicer_Zone"))
                {
                    component.gameObject.SetActive(false);
                    slicerZonePrefabCount++;
                }
                if (component.enabled)
                {
                    component.enabled = false;
                    slicerZoneCount++;
                }
            }

            foreach (ButcherGangController component in UnityEngine.Object.FindObjectsOfType<ButcherGangController>())
            {
                if (component.enabled && component.gameObject.name == "Slicer")
                {
                    component.gameObject.SetActive(false);
                    component.enabled = false;
                    slicerControllerCount++;
                }
            }

            foreach (SectionButcherGangController component in UnityEngine.Object.FindObjectsOfType<SectionButcherGangController>())
            {
                if (component.enabled && component.gameObject.name == "SectionButcherGangSlicerController")
                {
                    component.gameObject.SetActive(false);
                    component.enabled = false;
                    slicerSectionControllerCount++;
                }
            }

            if (slicerZoneCount > 0 || slicerZonePrefabCount > 0 || slicerControllerCount > 0 || slicerSectionControllerCount > 0)
            {
                MelonLogger.Msg(
                    $"Attempted to disable Slicer in {sceneName}. The results..\n" +
                    $"SlicerZone Components : {slicerZoneCount}\n" +
                    $"SlicerZone Prefabs : {slicerZonePrefabCount}\n" +
                    $"Slicer Controllers : {slicerControllerCount}\n" +
                    $"Slicer Section Controllers : {slicerSectionControllerCount}"
                );
            }
        }
    }
}