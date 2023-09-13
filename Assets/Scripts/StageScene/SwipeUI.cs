using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using TMPro;
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
		// 기존
		//UpdateInput();

		//// 아래에 배치된 스테이지 레벨 텍스트 제어
		//UpdateStageLevelText();

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

    // 기존
	//private void SetScrollBarValue(int index)
	//{
	//	currentPage = index;
	//	if (index >= MaxPage) index = MaxPage - 1;
	//	scrollBar.value = scrollPageValues[index];
	//}

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
	// 기존
	//   private void UpdateInput()
	//   {
	//       // 현재 Swipe를 진행중이면 터치 불가능
	//       if (isSwipeMode == true) return;

	//       #if UNITY_EDITOR
	//       // 마우스 왼쪽 버튼을 눌렀을 때 1회
	//       if (Input.GetMouseButtonDown(0))
	//       {
	//           // 터치 시작 지점 (Swipe 방향 구분)
	//           startTouchX = Input.mousePosition.x;
	//       }
	//       else if (Input.GetMouseButtonUp(0))
	//       {
	//           // 터치 종료 지점 (Swipe 방향 구분)
	//           endTouchX = Input.mousePosition.x;

	//           UpdateSwipe();
	//       }
	//       #endif

	//       #if UNITY_ANDROID
	//       if ( Input.touchCount == 1)
	//       {
	//           Touch touch = Input.GetTouch(0);

	//           if (touch.phase == TouchPhase.Began)
	//           {
	//               // 터치 시작 지범 (Swipe 방향 구분)
	//               startTouchX = touch.position.x;
	//           }
	//           else if (touch.phase == TouchPhase.Ended)
	//           {
	//               // 터치 종료 지점 (Swipe 방향 구분)
	//               endTouchX = touch.position.x;

	//               UpdateSwipe();
	//           }
	//       }
	//       #endif

	//}

	//private void UpdateSwipe()
	//{
	//    // 너무 작은 거리를 움직였을 때는 Swipe X
	//    if (Mathf.Abs(startTouchX-endTouchX) < swipeDistance)
	//    {
	//        // 원래 Satge이미지로 Swipe해서 돌아간다
	//        StartCoroutine(OnSwipeOneStep(currentPage));
	//        return;
	//    }

	//    // Swipe 방향
	//    bool isLeft = startTouchX < endTouchX ? true : false;

	//    // 이동 방향이 왼쪽일 때
	//    if (isLeft == true)
	//    {
	//        // 현재 스테이지가 왼쪽 끝이면 종료
	//        if (currentPage == 0) return;

	//        // 왼쪽으로 이동을 위해 현재 페이지를 1 감소
	//        currentPage--;
	//    }
	//    // 이동 방향이 오른쪽일 때
	//    else
	//    {
	//        // 현재 스테이지가 오른쪽 끝이면 종료
	//        if (currentPage == maxPage - 1) return;

	//        // 오른쪽으로 이동을 위해 현재 페이지를 1 증가
	//        currentPage++;
	//    }

	//    // currentIndex번째 페이지로 Swipe해서 이동
	//    StartCoroutine(OnSwipeOneStep(currentPage));
	//}

	//private IEnumerator OnSwipeOneStep(int index)
	//{
	//    float start = scrollBar.value;
	//    float current = 0;
	//    float percent = 0;

	//    isSwipeMode = true;

	//    while ( percent < 1 )
	//    {
	//        current += Time.deltaTime;
	//        percent = current / swipeTime;

	//        scrollBar.value = Mathf.Lerp(start, scrollPageValues[index], percent);

	//        yield return null;
	//    }

	//    isSwipeMode = false;
	//}

	//private void UpdateStageLevelText()
	//{
	//    // 스테이지 레벨 텍스트 출력
	//    for (int i = 0; i < scrollPageValues.Length; ++ i)
	//    {
	//        //페이지의 절반을 넘어가면 현재 텍스트를 바꾸도록
	//        if (scrollBar.value < scrollPageValues[i] + (valueDistance / 2) && scrollBar.value > scrollPageValues[i] - (valueDistance / 2))
	//        {
	//            int star = StageManager.Instance.GetStarNum(i + 1);
	//            UISwipeStageThumbnail.Instance.SetStageStarImage(star);

	//            bool isLocked = (i + 1) > lockedStage;
	//            UISwipeStageThumbnail.Instance.SetStageLevelText(((StageText)i).ToString(), isLocked);
	//        }
	//    }

	//}

	public void StartGame()
    {
        StageManager.Instance.StartGame(currentPage + 1);
    }

	
}
