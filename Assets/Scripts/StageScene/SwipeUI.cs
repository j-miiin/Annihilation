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

    //[SerializeField]
    //private Scrollbar scrollBar;                // Scrollbar의 위치를 바탕으로 현재 페이지 체크
    //[SerializeField]
    //private float swipeTime = 0.2f;             // StageImage가 Swipe 되는 시간
    //[SerializeField]
    //private float swipeDistance = 30.0f;        // StageImage가 Swipe 되기 위해 움직여야하는 최소 거리

    [SerializeField] private GameObject _stage1ThumbImage;
    [SerializeField] private GameObject _stage2ThumbImage;
    [SerializeField] private GameObject _stage3ThumbImage;

	//public float[] scrollPageValues;           // 각 페이지의 위치 값 [0.0 - 1.0]
	//private float valueDistance = 0;            // 각 페이지 사이의 거리
	//private int currentPage = 1;                // 현재 페이지
	//private int maxPage = 0;                    // 최대 페이지
	//private float startTouchX;                  // 터치 시작 위치
	//private float endTouchX;                    // 터치 종료 위치
	//private bool isSwipeMode = false;           // 현재 Swipe가 되고 있는지 체크
	private int lockedStage;

    public Scrollbar scrollbar;

    const int SIZE = 3;                         // 이미지 개수
    float[] pos = new float[SIZE];              // 페이지
    float distance;                             // 페이지 사이의 거리
    float targetPos;                            // 목표 페이지
    bool isDrag;                                // 드래그중인지 판별

	private int currentPage = 1;                // 현재 페이지
	public float[] scrollPageValues;            // 각 페이지의 위치 값 [0.0 - 1.0]
	private int maxPage = 0;                    // 최대 페이지
	private float valueDistance = 0;            // 각 페이지 사이의 거리

	enum StageText
	{
		EASY = 0,
		NORMAL,
		HARD
	}

	private void Awake()
	{
		// 기존
		// 스크롤 되는 페이지에 각 value 값을 저장하는 배열 메모리 담당
		scrollPageValues = new float[transform.childCount];

		// 스크롤 되는 페이지 사이의 거리
		valueDistance = 1f / (scrollPageValues.Length - 1f);

		// 스크롤 되는 페이지의 각 value 위치 설정 [0 <= value <= 1]
		for (int i = 0; i < scrollPageValues.Length; ++i)
		{
			scrollPageValues[i] = valueDistance * i + 0.1f;
		}

		//// 최대 페이지의 수
		maxPage = transform.childCount;

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

        // 최초 시작할 때 마지막으로 해금한 스테이지를 볼 수 있도록 설정
        lockedStage = StageManager.Instance.GetLockedStage();

        SetScrollBarValue(lockedStage - 1); 
        SetStageThumbImage();
        int star = StageManager.Instance.GetStarNum(lockedStage);
        UISwipeStageThumbnail.Instance.SetStageStarImage(star);
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

				int star = StageManager.Instance.GetStarNum(i + 1);
				UISwipeStageThumbnail.Instance.SetStageStarImage(star);

				bool isLocked = (i + 1) > lockedStage;
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

    private void SetScrollBarValue(int index)
    {
        currentPage = index;
        if (index >= maxPage) index = maxPage - 1;
        scrollbar.value = scrollPageValues[index];
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
        StageManager.Instance.StartGame(currentPage + 1);
    }
}
