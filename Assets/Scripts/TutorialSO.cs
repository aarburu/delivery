using UnityEngine;

[CreateAssetMenu(menuName = "Tutorial", fileName = "TutorialData")]
public class TutorialSO : ScriptableObject
{
     [field:SerializeField] public string Text { get; set; }
}
