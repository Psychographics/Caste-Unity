using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ThisCard : MonoBehaviour
{
    public List<PlayingCard> thisCard = new List<PlayingCard>();
    public int thisId;
    
    // Card Definition
    // int Id, string CardName, Sprite CardArtwork, string CardBiography,
    // string[] CardEffects, string CardElement, Sprite CardElementArtwork, CardClass CardClass,
    // string CardStatus, string CardType, AudioSource CardVoiceClip, int Cost, int Attack, int Defense

    public int id;
    public string cardName;
    public Image cardArtwork;
    public Sprite cardArtworkSprite;
    [TextArea(1, 3)]
    public string cardBiography;
    public string[] cardEffects;
    public string cardElement;
    public Image cardElementArtwork;
    public Sprite cardElementArtworkSprite;
    public string cardStatus;
    public string cardType;
    public AudioSource cardVoiceClip;
    // public int cost;
    // public int attack;
    // public int defense;
    public Image cardClassArtwork;
    public Sprite cardClassArtworkSprite;
    public Image cardBackArtwork;
    public Sprite cardBackArtworkSprite;

    public TextMeshProUGUI cardNameText;
    public TextMeshProUGUI cardBiographyText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI defenseText;
    
    public static bool staticCardBack;

    // Start is called before the first frame update
    void Start()
    {
        thisCard[0] = CardDatabase.cardList[thisId];
    }

    // Update is called once per frame
    void Update()
    {
        id = thisCard[0].id;
        cardNameText.text = thisCard[0].cardName;
        if (thisCard[0].cardArtwork) {
            cardArtworkSprite = thisCard[0].cardArtwork;
        }
        cardArtwork.GetComponent<Image>().sprite = cardArtworkSprite;
        cardBiographyText.text = thisCard[0].cardBiography;
        cardEffects = thisCard[0].cardEffects;
        cardElement = thisCard[0].cardElement;
        if (thisCard[0].cardElementArtwork) {
            cardElementArtworkSprite = thisCard[0].cardElementArtwork;
        }
        cardElementArtwork.GetComponent<Image>().sprite = cardElementArtworkSprite;
        cardStatus = thisCard[0].cardStatus;
        cardType = thisCard[0].cardType;
        cardVoiceClip = thisCard[0].cardVoiceClip;
        costText.text = "" + thisCard[0].cost;
        attackText.text = "" + thisCard[0].attack;
        defenseText.text = "" + thisCard[0].defense;
        if (thisCard[0].cardClassArtwork) {
            cardClassArtworkSprite = thisCard[0].cardClassArtwork;
        }
        cardClassArtwork.GetComponent<Image>().sprite  = cardClassArtworkSprite;
        // cardBackArtwork.GetComponent<Image>().sprite  = thisCard[0].cardBackArtwork;
    }
}
