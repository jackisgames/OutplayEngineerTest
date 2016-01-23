using UnityEditor;
using UnityEngine;
namespace Problem4
{
    [CustomEditor(typeof(Main))]
    internal sealed class MainEditor:Editor
    {
        
        public override void OnInspectorGUI()
        {
           
            base.OnInspectorGUI();
            if (Application.isPlaying)
            {
                if (GUILayout.Button("spawn"))
                {
                    Main main = (Main)target;
                    main.AddPathDummy();
                }
            }
        }
    }
}
