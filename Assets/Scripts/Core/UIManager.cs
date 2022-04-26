using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public int page;
    public CardManager cardManager;
    public GameObject[] cardSlots;
    public Dropdown attackDropDown;
    public Dropdown costDropDown;
    public Dropdown defenseDropDown;
    public Dropdown elementDropDown;
    public Text pageText;
    public Image elementImage;
    public GameObject SelectedCardPanel;
    public GameObject SelectedCard;
    public Button AddToDeckButton;

    public Toggle psionClassToggle;
    public Toggle evokerClassToggle;
    public Toggle enchanterClassToggle;
    public Toggle theurgeClassToggle;
    public Toggle druidClassToggle;
    public Toggle artificerClassToggle;

    public enum CardClass
    {
        Psion,
        Evoker,
        Enchanter,
        Diviner,
        Druid,
        Artificer
    }

    public CardClass cardClass;

    [SerializeField] private bool isFiltered;
    [SerializeField] private int totalNumbers;
    [SerializeField] private int currentSearchAttack;
    [SerializeField] private int currentSearchDefense;
    [SerializeField] private int currentSearchCost;
    [SerializeField] private int currentSearchElement;
    [SerializeField] private string currentSearchClass;
    [SerializeField] private string filter;
    [SerializeField] private string filterValue;
    [SerializeField] private int filterIntValue;
    [SerializeField] private string filterParameter;
    [SerializeField] private string filterPar;
    [SerializeField] private int SelectedCardIndex = 0;

    public void Start() 
    {
        DisplayCards();
    }

    private void Update()
    {
        TurnPage();
    
        UpdatePage();

        if (!isFiltered)
        {
            totalNumbers = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            DeselectCard();
        }

        // psionClassToggle.onValueChanged.AddListener((bool on) => {
        //     if (on) {
        //         filterPar = "Psion";
        //         SearchForClass(filterPar);
        //     }
        //     else
        //     {
        //         filterPar = "Psion";
        //         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //     }
        //     Debug.Log("FilterPar Set: " + filterPar);
        // });

        // evokerClassToggle.onValueChanged.AddListener((bool on) => {
        //     if (on) {
        //         filterPar = "Evoker";
        //         SearchForClass(filterPar);
        //     }
        //     else
        //     {
        //         filterPar = "Evoker";
        //         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //     }
        //     Debug.Log("FilterPar Set: " + filterPar);
        // });

        // if (psionClassToggle.isOn) {
        //     isFiltered = false;
        //     filterParameter = "";
        //     UpdatePage();
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // }
    }

    private void UpdatePage()
    {
        if (!isFiltered)
        {
            pageText.text = (page + 1).ToString() + "/" + (Mathf.Ceil(cardSlots.Length/8) + 1).ToString();
        } 
        else
        {
            // pageText.text = "Filtered";
            pageText.text = (page + 1).ToString() + "/" + (Mathf.Ceil(totalNumbers/8) + 1).ToString();
        }
    }

    public void SearchByAttack(int attackIndex)
    {
        ClearCostDropDown();
        ClearDefenseDropDown();
        ClearElementDropDown();
        isFiltered = true;
        totalNumbers = 0;
        page = 0;
        int attack = attackIndex - 1;
        filter = "attack";
        filterIntValue = attack;
        currentSearchAttack = attack;
        if (attackIndex == 0)
        {
            isFiltered = false;
            DisplayCards();
        }
        else
        {
            List<CardDefinition> filteredCards = new List<CardDefinition>();
            filteredCards = ReturnCardFilteredByAttack(attack);
            DisplayFilteredCards(filteredCards);
        }
    }

    public void SearchForClass(string caste)
    {
        isFiltered = true;
        totalNumbers = 0;
        page = 0;
        filter = "class";
        filterValue = caste;
        filterParameter = caste;
        ClearAllDropDowns();

        List<CardDefinition> filteredCards = new List<CardDefinition>();
        filteredCards = ReturnCardFilteredByClass(caste);
        DisplayFilteredCards(filteredCards);
    }

    public void SearchByClass(string caste)
    {
        // if (isFiltered && caste == filterParameter)
        // {
        //     // filterParameter = "";
        //     // if (psionClassToggle.isOn && caste == "Psion") {
        //     // if (isFiltered && caste == "Psion" && filterPar == "Psion") {
        //     // if (psionClassToggle.isOn && caste == "Psion") {
        //     //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //     // }
        //     isFiltered = false;
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // }
        // else if(caste != "" && filterPar != caste)
        if(caste != "" && filterPar != caste)
        {
            Debug.Log("FilterPar: " + filterPar + " Caste: " + caste);
            isFiltered = true;
            totalNumbers = 0;
            page = 0;
            filter = "class";
            filterValue = caste;
            filterPar = caste;
            filterParameter = caste;
            ClearAllDropDowns();

            List<CardDefinition> filteredCards = new List<CardDefinition>();
            filteredCards = ReturnCardFilteredByClass(caste);
            DisplayFilteredCards(filteredCards);
        }
        else if (filterPar == caste)
        {
            Debug.Log("FilterPar: " + filterPar + " Caste: " + caste);
            isFiltered = false;
            filterPar = "";
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    public void SearchByCost(int costIndex)
    {
        ClearAttackDropDown();
        ClearDefenseDropDown();
        ClearElementDropDown();
        isFiltered = true;
        totalNumbers = 0;
        page = 0;
        int cost = costIndex - 1;
        currentSearchCost = cost;
        filter = "cost";
        filterIntValue = cost;
        if (costIndex == 0)
        {
            isFiltered = false;
            DisplayCards();
        }
        else
        {
            List<CardDefinition> filteredCards = new List<CardDefinition>();
            filteredCards = ReturnCardFilteredByCost(cost);
            DisplayFilteredCards(filteredCards);
        }
    }

    public void SearchByDefense(int defenseIndex)
    {
        ClearAttackDropDown();
        ClearCostDropDown();
        ClearElementDropDown();
        isFiltered = true;
        totalNumbers = 0;
        page = 0;
        int defense = defenseIndex - 1;
        currentSearchDefense = defense;
        filter = "defense";
        filterIntValue = defense;
        if (defenseIndex == 0)
        {
            isFiltered = false;
            DisplayCards();
        }
        else
        {
            List<CardDefinition> filteredCards = new List<CardDefinition>();
            filteredCards = ReturnCardFilteredByDefense(defense);
            DisplayFilteredCards(filteredCards);
        }
    }

    public void SearchByElement(int cardElementIndex)
    {
        ClearAttackDropDown();
        ClearCostDropDown();
        ClearDefenseDropDown();
        isFiltered = true;
        totalNumbers = 0;
        page = 0;
        filter = "element";
        if (cardElementIndex == 0)
        {
            isFiltered = false;
            totalNumbers = 0;
            ChangeElementIcon(cardElementIndex);
            DisplayCards();
        }
        else
        {
            string[] elements = new string[4] {"Wind", "Water", "Fire", "Earth"};
            ChangeElementIcon(cardElementIndex);List<CardDefinition> filteredCards = new List<CardDefinition>();
            filterValue = elements[cardElementIndex - 1];
            filteredCards = ReturnCardFilteredByElement(elements[cardElementIndex - 1]);
            DisplayFilteredCards(filteredCards);
        }
    }

    public List<CardDefinition> ReturnCardFilteredByAttack(int attack)
    {
        List<CardDefinition> cardList = new List<CardDefinition>();
        for (int i = 0; i < cardManager.cards.Count; i++)
        {
            CardDefinition card;

            if (cardManager.cards[i].attack == attack)
            {
                card = cardManager.cards[i];
                cardList.Add(card);
            }
        }
        return cardList;
    }

    public List<CardDefinition> ReturnCardFilteredByDefense(int defense)
    {
        List<CardDefinition> cardList = new List<CardDefinition>();
        for (int i = 0; i < cardManager.cards.Count; i++)
        {
            CardDefinition card;

            if (cardManager.cards[i].defense == defense)
            {
                card = cardManager.cards[i];
                cardList.Add(card);
            }
        }
        return cardList;
    }

    public List<CardDefinition> ReturnCardFilteredByCost(int cost)
    {
        List<CardDefinition> cardList = new List<CardDefinition>();
        for (int i = 0; i < cardManager.cards.Count; i++)
        {
            CardDefinition card;

            if (cardManager.cards[i].cost == cost)
            {
                card = cardManager.cards[i];
                cardList.Add(card);
            }
        }
        return cardList;
    }

    public List<CardDefinition> ReturnCardFilteredByClass(string caste)
    {
        List<CardDefinition> cardList = new List<CardDefinition>();
        for (int i = 0; i < cardManager.cards.Count; i++)
        {
            CardDefinition card;

            if (cardManager.cards[i].cardClass.ToString() == caste)
            {
                card = cardManager.cards[i];
                cardList.Add(card);
            }
        }
        return cardList;
    }

    public List<CardDefinition> ReturnCardFilteredByElement(string element)
    {
        List<CardDefinition> cardList = new List<CardDefinition>();
        for (int i = 0; i < cardManager.cards.Count; i++)
        {
            CardDefinition card;

            if (cardManager.cards[i].cardElement.ToString() == element)
            {
                card = cardManager.cards[i];
                cardList.Add(card);
            }
        }
        return cardList;
    }

    public void InitialCardsTabs()
    {
        page = 0;
        isFiltered = false;
        DisplayCards();
    }

    private void DisplayCards()
    {        
        for(int i = 0; i < cardManager.cards.Count; i++)
        {
            if (i >= page * 8 && i < (page + 1) * 8) 
            {
                DisplaySingleCard(i);
            }
            else
            {
                cardSlots[i].gameObject.SetActive(false);
            }
        }
    }

    private void DisplaySingleCard(int i)
    {
        totalNumbers++;

        cardSlots[i].gameObject.SetActive(true);
        cardSlots[i].transform.Find("CardArtwork").GetComponent<Image>().sprite = cardManager.cards[i].cardArtwork;
        cardSlots[i].transform.Find("CardArtwork").GetChild(0).GetChild(0).GetComponent<Text>().text = cardManager.cards[i].attack.ToString();
        cardSlots[i].transform.Find("CardArtwork").GetChild(1).GetChild(0).GetComponent<Text>().text = cardManager.cards[i].defense.ToString();
        cardSlots[i].transform.Find("CardArtwork").GetChild(2).GetChild(0).GetComponent<Text>().text = cardManager.cards[i].cost.ToString();
        cardSlots[i].transform.Find("CardArtwork").GetChild(3).GetChild(0).GetComponent<Text>().text = cardManager.cards[i].cardName;
        cardSlots[i].transform.Find("CardArtwork").GetChild(3).GetChild(1).GetComponent<Text>().text = cardManager.cards[i].cardBiography;
        cardSlots[i].transform.Find("CardArtwork").GetChild(4).GetComponent<Image>().sprite = cardManager.cards[i].cardElementArtwork;
        
        int caste = (int) cardManager.cards[i].cardClass;
        switch (caste)
        {
            case 0:
                cardSlots[i].transform.Find("CardArtwork").GetChild(5).GetComponent<Image>().sprite = cardManager.classIcons[0];
                break;
            case 1:
                cardSlots[i].transform.Find("CardArtwork").GetChild(5).GetComponent<Image>().sprite = cardManager.classIcons[1];
                break;
            case 2:
                cardSlots[i].transform.Find("CardArtwork").GetChild(5).GetComponent<Image>().sprite = cardManager.classIcons[2];
                break;
            case 3:
                cardSlots[i].transform.Find("CardArtwork").GetChild(5).GetComponent<Image>().sprite = cardManager.classIcons[3];
                break;
            case 4:
                cardSlots[i].transform.Find("CardArtwork").GetChild(5).GetComponent<Image>().sprite = cardManager.classIcons[4];
                break;
            case 5:
                cardSlots[i].transform.Find("CardArtwork").GetChild(5).GetComponent<Image>().sprite = cardManager.classIcons[5];
                break;
            default:
                break;
        }
    }

    private void DisplayFilteredCards(List<CardDefinition> filteredCards)
    {  
        for (int i = 0; i < cardSlots.Length; i++)
        {
            cardSlots[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < filteredCards.Count; i++)
        {
            if (i >= page * 8 && i < (page + 1) * 8) 
            {        
                totalNumbers++;

                cardSlots[i].gameObject.SetActive(true);
                cardSlots[i].transform.Find("CardArtwork").GetComponent<Image>().sprite = filteredCards[i].cardArtwork;
                cardSlots[i].transform.Find("CardArtwork").GetChild(0).GetChild(0).GetComponent<Text>().text = filteredCards[i].attack.ToString();
                cardSlots[i].transform.Find("CardArtwork").GetChild(1).GetChild(0).GetComponent<Text>().text = filteredCards[i].defense.ToString();
                cardSlots[i].transform.Find("CardArtwork").GetChild(2).GetChild(0).GetComponent<Text>().text = filteredCards[i].cost.ToString();
                cardSlots[i].transform.Find("CardArtwork").GetChild(3).GetChild(0).GetComponent<Text>().text = filteredCards[i].cardName;
                cardSlots[i].transform.Find("CardArtwork").GetChild(3).GetChild(1).GetComponent<Text>().text = filteredCards[i].cardBiography;
                cardSlots[i].transform.Find("CardArtwork").GetChild(4).GetComponent<Image>().sprite = filteredCards[i].cardElementArtwork;

                int caste = (int) filteredCards[i].cardClass;
                switch (caste)
                {
                    case 0:
                        cardSlots[i].transform.Find("CardArtwork").GetChild(5).GetComponent<Image>().sprite = cardManager.classIcons[0];
                        break;
                    case 1:
                        cardSlots[i].transform.Find("CardArtwork").GetChild(5).GetComponent<Image>().sprite = cardManager.classIcons[1];
                        break;
                    case 2:
                        cardSlots[i].transform.Find("CardArtwork").GetChild(5).GetComponent<Image>().sprite = cardManager.classIcons[2];
                        break;
                    case 3:
                        cardSlots[i].transform.Find("CardArtwork").GetChild(5).GetComponent<Image>().sprite = cardManager.classIcons[3];
                        break;
                    case 4:
                        cardSlots[i].transform.Find("CardArtwork").GetChild(5).GetComponent<Image>().sprite = cardManager.classIcons[4];
                        break;
                    case 5:
                        cardSlots[i].transform.Find("CardArtwork").GetChild(5).GetComponent<Image>().sprite = cardManager.classIcons[5];
                        break;
                    default:
                        break;
                }
            }
        }
        
    }

    public void DisplaySelectedCard()
    {
        SelectedCardPanel.gameObject.SetActive(true);
        SelectedCard.gameObject.SetActive(true);
        AddToDeckButton.gameObject.SetActive(true);
        SelectedCard.transform.Find("CardArtwork").GetComponent<Image>().sprite = cardManager.cards[SelectedCardIndex].cardArtwork;
        SelectedCard.transform.Find("CardArtwork").GetChild(0).GetChild(0).GetComponent<Text>().text = cardManager.cards[SelectedCardIndex].attack.ToString();
        SelectedCard.transform.Find("CardArtwork").GetChild(1).GetChild(0).GetComponent<Text>().text = cardManager.cards[SelectedCardIndex].defense.ToString();
        SelectedCard.transform.Find("CardArtwork").GetChild(2).GetChild(0).GetComponent<Text>().text = cardManager.cards[SelectedCardIndex].cost.ToString();
        SelectedCard.transform.Find("CardArtwork").GetChild(3).GetChild(0).GetComponent<Text>().text = cardManager.cards[SelectedCardIndex].cardName;
        SelectedCard.transform.Find("CardArtwork").GetChild(3).GetChild(1).GetComponent<Text>().text = cardManager.cards[SelectedCardIndex].cardBiography;
        // SelectedCard.transform.Find("CardArtwork").GetChild(3).GetChild(1).GetComponent<Text>().text = cardManager.cards[SelectedCardIndex].class;
        SelectedCard.transform.Find("CardArtwork").GetChild(4).GetComponent<Image>().sprite = cardManager.cards[SelectedCardIndex].cardElementArtwork;
    }

    public void DeselectCard()
    {
        SelectedCardPanel.gameObject.SetActive(false);
        SelectedCard.gameObject.SetActive(false);
        AddToDeckButton.gameObject.SetActive(true);
    }

    private void TurnPage()
    {
        // Next Page
        if (!isFiltered)
        {

            // Next Page
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) 
            {
                if (page >= Mathf.FloorToInt(cardManager.cards.Count - 1) / 8)
                {
                    page = 0;
                } 
                else
                {
                    page++;
                }
                DisplayCards();
            }

            // Previous Page
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) 
            {
                if (page <= 0)
                {
                    page = Mathf.FloorToInt((cardManager.cards.Count - 1) / 8);
                } 
                else
                {
                    page--;
                }
                DisplayCards();
            }
        } 
        else
        {
            // Next Page
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) 
            {
                if (page >= Mathf.FloorToInt(totalNumbers - 1) / 8)
                {
                    page = 0;
                } 
                else
                {
                    page++;
                }
                DisplayByFilter();
            }

            // Previous Page
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) 
            {
                if (page <= 0)
                {
                    page = Mathf.FloorToInt((totalNumbers - 1) / 8);
                } 
                else
                {
                    page--;
                }
                DisplayByFilter();
            }
        }
    }

    private void DisplayByFilter()
    {
        List<CardDefinition> cards = new List<CardDefinition>();

        if (filter == "class") 
        {
            cards = ReturnCardFilteredByClass(filterValue);
        }
        else if (filter == "attack")
        {
            cards = ReturnCardFilteredByAttack(filterIntValue);
        }
        else if (filter == "cost")
        {
            cards = ReturnCardFilteredByCost(filterIntValue);
        }
        else if (filter == "defense")
        {
            cards = ReturnCardFilteredByDefense(filterIntValue);
        }
        else if (filter == "element")
        {
            cards = ReturnCardFilteredByElement(filterValue);
        }

        for (int i = 0; i < cardSlots.Length; i++)
        {
            cardSlots[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < cards.Count; i++) 
        {
            
            if (i >= page * 8 && i < (page + 1) * 8) 
            {        
                if (totalNumbers < cards.Count) 
                {
                    totalNumbers++;
                }
                
                cardSlots[i].gameObject.SetActive(true);
                cardSlots[i].transform.Find("CardArtwork").GetComponent<Image>().sprite = cards[i].cardArtwork;
                cardSlots[i].transform.Find("CardArtwork").GetChild(0).GetChild(0).GetComponent<Text>().text = cards[i].attack.ToString();
                cardSlots[i].transform.Find("CardArtwork").GetChild(1).GetChild(0).GetComponent<Text>().text = cards[i].defense.ToString();
                cardSlots[i].transform.Find("CardArtwork").GetChild(2).GetChild(0).GetComponent<Text>().text = cards[i].cost.ToString();
                cardSlots[i].transform.Find("CardArtwork").GetChild(3).GetChild(0).GetComponent<Text>().text = cards[i].cardName;
                cardSlots[i].transform.Find("CardArtwork").GetChild(3).GetChild(1).GetComponent<Text>().text = cards[i].cardBiography;
                // cardSlots[i].transform.Find("CardArtwork").GetChild(3).GetChild(1).GetComponent<Text>().text = cards[i].class;
                cardSlots[i].transform.Find("CardArtwork").GetChild(4).GetComponent<Image>().sprite = cards[i].cardElementArtwork;
            }
        }
    }

    private void ChangeElementIcon(int i)
    {
        elementImage.sprite = cardManager.elementIcons[i];
    }

    private void ClearAttackDropDown()
    {
        attackDropDown.value = 0;
    }

    private void ClearCostDropDown()
    {
        costDropDown.value = 0;
    }

    private void ClearDefenseDropDown()
    {
        defenseDropDown.value = 0;
    }

    private void ClearElementDropDown()
    {
        elementDropDown.value = 0;
    }

    private void ClearAllDropDowns()
    {
        ClearAttackDropDown();
        ClearCostDropDown();
        ClearDefenseDropDown();
        ClearElementDropDown();
    }

}
