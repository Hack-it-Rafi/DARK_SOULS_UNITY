using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

namespace SG
{
    public class TitleScreenManager : MonoBehaviour
    {
        public static TitleScreenManager instance;
        [Header("Menu Objects")]
        [SerializeField] GameObject titleScreenMainMenu;
        [SerializeField] GameObject titleScreenLoadMenu;

        [Header("Buttons")]
        [SerializeField] Button mainMenuNewGameButton;
        [SerializeField] Button mainMenuLoadGameButton;
        [SerializeField] Button loadMenuReturnButton;
        [SerializeField] Button deleteCharacterPopUpConfirmButton;

        [Header("Popup")]
        [SerializeField] GameObject noFreeCharacterSlotsPopup;
        [SerializeField] Button noFreeCharacterSlotsOkayButton;
        [SerializeField] GameObject deleteCharacterSlotPopup;

        [Header("Character Slots")]
        public CharacterSlot currentSelectedSlot = CharacterSlot.NO_SLOT;

        public string titleScreenInput;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void StartNetworkAsHost()
        {
            // Start the game as a host
            NetworkManager.Singleton.StartHost();

        }

        public void StartNewGame()
        {
            WorldSaveGameManager.instance.AttemptToCreateNewGame();

        }

        public void OpenLoadGameMenu()
        {
            titleScreenMainMenu.SetActive(false);
            titleScreenLoadMenu.SetActive(true);

            loadMenuReturnButton.Select();

            //Find the first load slot and auto select it

        }

        public void CloseLoadGameMenu()
        {
            titleScreenLoadMenu.SetActive(false);
            titleScreenMainMenu.SetActive(true);

            mainMenuLoadGameButton.Select();

        }

        public void DisplayNoFreeCharacterSlotsPopup()
        {
            noFreeCharacterSlotsPopup.SetActive(true);
            noFreeCharacterSlotsOkayButton.Select();
        }

        public void CloseNoFreeCharacterSlotsPopup()
        {
            noFreeCharacterSlotsPopup.SetActive(false);
            mainMenuNewGameButton.Select();
        }

        //Character Slot Functions

        public void SelectCharacterSlot(CharacterSlot characterSlot)
        {
            currentSelectedSlot = characterSlot;
        }

        public void SelectNoSlot()
        {
            currentSelectedSlot = CharacterSlot.NO_SLOT;
        }

        public void AttemptToDeleteCharacterSlot()
        {
            if (currentSelectedSlot != CharacterSlot.NO_SLOT)
            {
                deleteCharacterSlotPopup.SetActive(true);
                deleteCharacterPopUpConfirmButton.Select();
            }
        }

        public void DeleteCharacterSlot()
        {
            deleteCharacterSlotPopup.SetActive(false);
            WorldSaveGameManager.instance.DeleteGame(currentSelectedSlot);
            //Refresh the load menu
            titleScreenLoadMenu.SetActive(false);
            titleScreenMainMenu.SetActive(true);
            
            loadMenuReturnButton.Select();
            
        }

        public void CloseDeleteCharacterPopup()
        {
            deleteCharacterSlotPopup.SetActive(false);
            loadMenuReturnButton.Select();
        }
    }
}
