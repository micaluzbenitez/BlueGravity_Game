using UnityEditor;
using UnityEngine;
using BlueGravity.Inventory;

[CustomEditor(typeof(Item))]
public class ItemEditor : Editor
{
    Item item;

    private void OnEnable()
    {
        item = target as Item;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (item.icon == null) return;

        Texture2D texture = AssetPreview.GetAssetPreview(item.icon);
        GUILayout.Label("", GUILayout.Height(80), GUILayout.Width(80));
        GUI.DrawTexture(new Rect(20, 110, 50, 50), texture);
    }
}