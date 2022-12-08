using _Scripts.DungeonGenerator;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(AbstractDungeonGenerator), true)]
    public class RandomDungeonGeneratorEditor : UnityEditor.Editor
    {
        private AbstractDungeonGenerator _generator;

        private void Awake()
        {
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Create Dungeon")) _generator.GenerateDungeon();
        }
    }
}