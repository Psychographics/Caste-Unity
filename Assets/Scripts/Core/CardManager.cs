using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public List<CardDefinition> cards = new List<CardDefinition>();
    public List<Sprite> elementIcons = new List<Sprite>();
    public List<Sprite> classIcons = new List<Sprite>();
    public List<Sprite> selectedClassIcons = new List<Sprite>();
}
