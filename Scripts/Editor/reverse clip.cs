using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class AnimationClipReverser
{
    [MenuItem("Assets/Reverse Animation Clip")]
    static void ReverseSelectedClip()
    {
        AnimationClip originalClip = Selection.activeObject as AnimationClip;
        if (originalClip == null)
        {
            Debug.LogError("Please select an AnimationClip.");
            return;
        }

        AnimationClip reversedClip = new AnimationClip();
        EditorCurveBinding[] curveBindings = AnimationUtility.GetCurveBindings(originalClip);

        float clipLength = originalClip.length;

        foreach (var binding in curveBindings)
        {
            AnimationCurve originalCurve = AnimationUtility.GetEditorCurve(originalClip, binding);
            Keyframe[] reversedKeys = new Keyframe[originalCurve.keys.Length];

            for (int i = 0; i < originalCurve.keys.Length; i++)
            {
                Keyframe k = originalCurve.keys[i];
                reversedKeys[i] = new Keyframe(clipLength - k.time, k.value, -k.outTangent, -k.inTangent);
            }

            System.Array.Sort(reversedKeys, (a, b) => a.time.CompareTo(b.time));
            AnimationCurve reversedCurve = new AnimationCurve(reversedKeys);
            reversedClip.SetCurve(binding.path, binding.type, binding.propertyName, reversedCurve);
        }

        string path = AssetDatabase.GetAssetPath(originalClip);
        string newPath = path.Replace(".anim", "_Reversed.anim");
        AssetDatabase.CreateAsset(reversedClip, newPath);
        AssetDatabase.SaveAssets();

        Debug.Log("Reversed clip created at: " + newPath);
    }
}
