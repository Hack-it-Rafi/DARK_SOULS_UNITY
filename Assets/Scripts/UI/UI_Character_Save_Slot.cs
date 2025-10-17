using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SG
{
    public class UI_Character_Save_Slot : MonoBehaviour
    {
        SaveFileDataWriter saveFileDataWriter;

        [Header("Game Slot")]
        public CharacterSlot characterSlot;

        [Header("Character Info")]
        public TextMeshProUGUI characterName;
        public TextMeshProUGUI timePlayed;
        

        private void OnEnable()
        {
            LoadSaveSlots();
        }

        private void LoadSaveSlots()
        {
            saveFileDataWriter = new SaveFileDataWriter();
            saveFileDataWriter.saveDataDirectoryPath = Application.persistentDataPath;

            if (characterSlot == CharacterSlot.CharacterSlot_01)
            {
                saveFileDataWriter.saveFileName = WorldSaveGameManager.instance.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(characterSlot);
                
                if (saveFileDataWriter.CheckToSeeIfSaveFileExists())
                {
                    characterName.text = WorldSaveGameManager.instance.characterSlot01.characterName;
                    // timePlayed.text = WorldSaveGameManager.instance.characterSlot01.timePlayed;
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
            else if (characterSlot == CharacterSlot.CharacterSlot_02)
            {
                saveFileDataWriter.saveFileName = WorldSaveGameManager.instance.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(characterSlot);
                
                if (saveFileDataWriter.CheckToSeeIfSaveFileExists())
                {
                    characterName.text = WorldSaveGameManager.instance.characterSlot02.characterName;
                    // timePlayed.text = WorldSaveGameManager.instance.characterSlot01.timePlayed;
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
            else if (characterSlot == CharacterSlot.CharacterSlot_03)
            {
                saveFileDataWriter.saveFileName = WorldSaveGameManager.instance.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(characterSlot);
                
                if (saveFileDataWriter.CheckToSeeIfSaveFileExists())
                {
                    characterName.text = WorldSaveGameManager.instance.characterSlot03.characterName;
                    // timePlayed.text = WorldSaveGameManager.instance.characterSlot01.timePlayed;
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
            else if (characterSlot == CharacterSlot.CharacterSlot_04)
            {
                saveFileDataWriter.saveFileName = WorldSaveGameManager.instance.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(characterSlot);
                
                if (saveFileDataWriter.CheckToSeeIfSaveFileExists())
                {
                    characterName.text = WorldSaveGameManager.instance.characterSlot04.characterName;
                    // timePlayed.text = WorldSaveGameManager.instance.characterSlot01.timePlayed;
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
            else if (characterSlot == CharacterSlot.CharacterSlot_05)
            {
                saveFileDataWriter.saveFileName = WorldSaveGameManager.instance.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(characterSlot);
                
                if (saveFileDataWriter.CheckToSeeIfSaveFileExists())
                {
                    characterName.text = WorldSaveGameManager.instance.characterSlot05.characterName;
                    // timePlayed.text = WorldSaveGameManager.instance.characterSlot01.timePlayed;
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
            else if (characterSlot == CharacterSlot.CharacterSlot_06)
            {
                saveFileDataWriter.saveFileName = WorldSaveGameManager.instance.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(characterSlot);
                
                if (saveFileDataWriter.CheckToSeeIfSaveFileExists())
                {
                    characterName.text = WorldSaveGameManager.instance.characterSlot06.characterName;
                    // timePlayed.text = WorldSaveGameManager.instance.characterSlot01.timePlayed;
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
            else if (characterSlot == CharacterSlot.CharacterSlot_07)
            {
                saveFileDataWriter.saveFileName = WorldSaveGameManager.instance.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(characterSlot);
                
                if (saveFileDataWriter.CheckToSeeIfSaveFileExists())
                {
                    characterName.text = WorldSaveGameManager.instance.characterSlot07.characterName;
                    // timePlayed.text = WorldSaveGameManager.instance.characterSlot01.timePlayed;
                }
                else
                {
                    gameObject.SetActive(false);
                }
            } 
            else if (characterSlot == CharacterSlot.CharacterSlot_08)
            {
                saveFileDataWriter.saveFileName = WorldSaveGameManager.instance.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(characterSlot);
                
                if (saveFileDataWriter.CheckToSeeIfSaveFileExists())
                {
                    characterName.text = WorldSaveGameManager.instance.characterSlot08.characterName;
                    // timePlayed.text = WorldSaveGameManager.instance.characterSlot01.timePlayed;
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
            else if (characterSlot == CharacterSlot.CharacterSlot_09)
            {
                saveFileDataWriter.saveFileName = WorldSaveGameManager.instance.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(characterSlot);
                
                if (saveFileDataWriter.CheckToSeeIfSaveFileExists())
                {
                    characterName.text = WorldSaveGameManager.instance.characterSlot09.characterName;
                    // timePlayed.text = WorldSaveGameManager.instance.characterSlot01.timePlayed;
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
            else if (characterSlot == CharacterSlot.CharacterSlot_10)
            {
                saveFileDataWriter.saveFileName = WorldSaveGameManager.instance.DecideCharacterFileNameBasedOnCharacterSlotBeingUsed(characterSlot);
                
                if (saveFileDataWriter.CheckToSeeIfSaveFileExists())
                {
                    characterName.text = WorldSaveGameManager.instance.characterSlot10.characterName;
                    // timePlayed.text = WorldSaveGameManager.instance.characterSlot01.timePlayed;
                }
                else
                {
                    gameObject.SetActive(false);
                }
            } 
            

        }

        public void LoadGameFromCharacterSlot()
        {
            WorldSaveGameManager.instance.currentCharacterSlotBeingUsed = characterSlot;
            WorldSaveGameManager.instance.LoadGame();
        }

        public void SelectCurrentSlot()
        {
            TitleScreenManager.instance.SelectCharacterSlot(characterSlot);
        }
    }
}
