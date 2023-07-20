#if UNITY_EDITOR
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace WoH.AbsoluteDivExample
{
    [CustomEditor(typeof(AbsoluteDiv))]
    [CanEditMultipleObjects]
    public class AbsoluteDivEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUILayout.Space();
            if (GUILayout.Button("Copy absolute div tag to buffer"))
            {
                OnButtonCopyClick();
            }
        }

        private void OnButtonCopyClick()
        {
            var sb = new StringBuilder();
            foreach (var singleTarget in targets.OrderBy(t => (t as AbsoluteDiv).transform.GetSiblingIndex()))
            {
                sb.AppendLine((singleTarget as AbsoluteDiv).BuildTag());
            }
            GUIUtility.systemCopyBuffer = sb.ToString().Replace("\r", string.Empty);            
        }
    }
}
#endif