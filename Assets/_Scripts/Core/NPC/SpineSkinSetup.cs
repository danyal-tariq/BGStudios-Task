using Spine;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;


	public class SpineSkinSetup : MonoBehaviour
	{

	public SkeletonDataAsset skeletonDataAsset;
    public SkeletonAnimation skeletonAnim;

    [SpineSkin] public string baseSkin = "skin-base";
    [SpineSkin] public string Shirt;
    [SpineSkin] public string Pant;
    [SpineSkin] public string Hair;
    [SpineSkin] public string Eyes;
    [SpineSkin] public string[] Accesories;

    private void Start()
    {
        print(Shirt);
        var skeletonData = skeletonAnim.skeleton.Data;
        Skin addedSkins = new Skin("multiSkin");

        addedSkins.AddSkin(skeletonData.FindSkin(baseSkin));
        addedSkins.AddSkin(skeletonData.FindSkin(Shirt));
        addedSkins.AddSkin(skeletonData.FindSkin(Pant));
        addedSkins.AddSkin(skeletonData.FindSkin(Hair));
        addedSkins.AddSkin(skeletonData.FindSkin(Eyes));
       
        skeletonAnim.skeleton.SetSkin(addedSkins);
        skeletonAnim.skeleton.SetSlotsToSetupPose();
    }

}
