using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // 잠긴 스테이지 썸네일 이미지
    public const string STAGE2_LOCKED_THUMB_IMAGE = "Image/MapImage/NStageMap_locked";
    public const string STAGE3_LOCKED_THUMB_IMAGE = "Image/MapImage/HStageMap_locked";

    [SerializeField] private GameObject _stage1ThumbImage;
    [SerializeField] private GameObject _stage2ThumbImage;
    [SerializeField] private GameObject _stage3ThumbImage;

	private int lockedStage;
    private int selectedStage;

    public Scrollbar scrollbar;

    const int SIZE = 3;                         // 이미지 개수
    float[] pos = new float[SIZE];              // 페이지
    float distance;                             // 페이지 사이의 거리
    float targetPos;                            // 목표 페이지
    bool isDrag;                                // 드래그중인지 판별

	enum StageText
	{
		EASY = 0,
		NORMAL,
		HARD
	}

	private void Awake()
	{
		SetBtn();
    }

	private void Start()
	{
        // 거리에 따라 0~1인 pos 대입
        distance = 1f / (SIZE - 1);
        for (int i = 0; i < SIZE; i++)
        {
            pos[i] = distance * i;
        }

        lockedStage = StageManager.Instance.GetLockedStage();
        selectedStage = 1;
        SetStageThumbImage();
        UISwipeStageThumbnail.Instance.SetStageStarImage(StageManager.Instance.GetStarNum(1));
    }

	public void OnBeginDrag(PointerEventData eventData)
	{
        
	}

	public void OnDrag(PointerEventData eventData)
	{
        isDrag = true;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
        isDrag = false;
        
        for (int i = 0; i < SIZE; i++)
        {
            if (scrollbar.value < pos[i] + distance * 0.5f && scrollbar.value > pos[i] - distance * 0.5f)
            {
                targetPos = pos[i];
                selectedStage = i + 1;

                bool isLocked = (i + 1) <= lockedStage;
                int star = StageManager.Instance.GetStarNum(i + 1);
				UISwipeStageThumbnail.Instance.SetStageStarImage((isLocked) ? star : 0);
				UISwipeStageThumbnail.Instance.SetStageLevelText(((StageText)i).ToString(), isLocked);
			}
        }
	}

	private void Update()
	{
		if (!isDrag)
        {
            scrollbar.value = Mathf.Lerp(scrollbar.value, targetPos, 0.1f);
        }
	}

    private void SetBtn()
    {
        _stage1ThumbImage.GetComponent<Button>().onClick.AddListener(() => StartGame()); 
        _stage2ThumbImage.GetComponent<Button>().onClick.AddListener(() => StartGame());
        _stage3ThumbImage.GetComponent<Button>().onClick.AddListener(() => StartGame());
    }

	// 해금한 스테이지 여부를 보여주기 위해 스테이지 Image를 set 
	private void SetStageThumbImage()
    {
        if (lockedStage < 2)
        {
            _stage2ThumbImage.GetComponent<Image>().sprite
                = Resources.Load<Sprite>(STAGE2_LOCKED_THUMB_IMAGE);
        }
        if (lockedStage < 3)
        {
            _stage3ThumbImage.GetComponent<Image>().sprite
                = Resources.Load<Sprite>(STAGE3_LOCKED_THUMB_IMAGE);
        }
    }

	public void StartGame()
    {
        Debug.Log("selectedStage" + selectedStage);
        StageManager.Instance.StartGame(selectedStage);
    }
}
