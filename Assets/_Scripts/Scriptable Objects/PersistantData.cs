using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "PersistantData", menuName = "ScriptableObjects/Data")]
    public class PersistantData : ScriptableObject
    {
        public int cash;


        public void DeductCash(int amount)
        {
            cash -= amount;
            PlayerPrefs.SetInt("Cash", cash);
        }
    }
}