using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuralData : ScriptableObject 
{
    public string title = "Mural Title";
    public string description = "Mural Descriptiom";
    public string artist = "Mural Artist";
    public Texture[] images;
    public LocationInfo location;
}
