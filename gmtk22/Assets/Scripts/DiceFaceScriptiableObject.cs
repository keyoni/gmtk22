using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New DiceFace", menuName= "ScriptableObject/DiceFace")]
public class DiceFaceScriptiableObject : ScriptableObject
{
  public Sprite faceSprite;
  public String value;
  public int numValue;
  public int mergeNum;
}
