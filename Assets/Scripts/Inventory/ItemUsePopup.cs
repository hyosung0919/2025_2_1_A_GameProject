using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemUsePopup : MonoBehaviour
{
    public static ItemUsePopup Instance;                //싱글톤

    public GameObject popupPanel;                       //UI 팝업 패널
    public Text itemNameText;                           //아이템 이름 텍스트
    public Image itemIconImage;                         //아이템 아이콘 이미지
    public Button useButton;                            //사용 버튼
    public Button closeButton;                          //닫기 버튼

    private ItemData currentItem;                       //아이템 데이터 정보 (현재 클릭한)
    private InventorySlot currentSlot;                  //클릭한 슬롯 정보

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        popupPanel.SetActive(false);
        useButton.onClick.AddListener(UseItem);
        closeButton.onClick.AddListener(ClosePopup);
    }


    public void ShowPopup(ItemData item, InventorySlot slot)                //팝업 셋팅 함수
    {
        currentItem = item;                                                 //클릭한 아이템 데이터를 가져 온다.
        currentSlot = slot;                                                 //슬롯 정보도 가져온다.

        itemNameText.text = item.itemName;
        itemIconImage.sprite = item.itemIcon;

        useButton.interactable = item.isUsable;

        popupPanel.SetActive(true);
    }

    void ClosePopup()
    {
        popupPanel.SetActive(false);
    }

    void UseItem()                                                                           //아이템 사용 함수
    {
        if (currentItem.isUsable)                                                            //아이템  사용이 가능하려면
        {
            PlayerStats player = FindAnyObjectByType<PlayerStats>();

            if (currentItem.healAmount > 0)                                                  //힐 수치가 있을 경우 힐 한다.
            {
                player.Heal(currentItem.healAmount);
                Debug.Log(currentItem.itemIcon + " 사용 : 체력 회복 " + currentItem.healAmount);
            }
            else if(currentItem.healAmount < 0)
            {
                player.TakeDamage(currentItem.healAmount);
                Debug.Log(currentItem.itemIcon + " 사용 : 체력 감소 " + currentItem.healAmount);
            }
            currentSlot.RemoveAmount(1);
        }
        ClosePopup();
    }
}
