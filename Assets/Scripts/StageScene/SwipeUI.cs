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
    // ��� �������� ����� �̹���
    public const string STAGE2_LOCKED_THUMB_IMAGE = "Image/MapImage/NStageMap_locked";
    public const string STAGE3_LOCKED_THUMB_IMAGE = "Image/MapImage/HStageMap_locked";

    //[SerializeField]
    //private Scrollbar scrollBar;                // Scrollbar�� ��ġ�� �������� ���� ������ üũ
    //[SerializeField]
    //private float swipeTime = 0.2f;             // StageImage�� Swipe �Ǵ� �ð�
    //[SerializeField]
    //private float swipeDistance = 30.0f;        // StageImage�� Swipe �Ǳ� ���� ���������ϴ� �ּ� �Ÿ�

    [SerializeField] private GameObject _stage1ThumbImage;
    [SerializeField] private GameObject _stage2ThumbImage;
    [SerializeField] private GameObject _stage3ThumbImage;

	//public float[] scrollPageValues;           // �� �������� ��ġ �� [0.0 - 1.0]
	//private float valueDistance = 0;            // �� ������ ������ �Ÿ�
	//private int currentPage = 1;                // ���� ������
	//private int maxPage = 0;                    // �ִ� ������
	//private float startTouchX;                  // ��ġ ���� ��ġ
	//private float endTouchX;                    // ��ġ ���� ��ġ
	//private bool isSwipeMode = false;           // ���� Swipe�� �ǰ� �ִ��� üũ
	private int lockedStage;

    public Scrollbar scrollbar;

    const int SIZE = 3;                         // �̹��� ����
    float[] pos = new float[SIZE];              // ������
    float distance;                             // ������ ������ �Ÿ�
    float targetPos;                            // ��ǥ ������
    bool isDrag;                                // �巡�������� �Ǻ�

	private int currentPage = 1;                // ���� ������
	public float[] scrollPageValues;            // �� �������� ��ġ �� [0.0 - 1.0]
	private int maxPage = 0;                    // �ִ� ������
	private float valueDistance = 0;            // �� ������ ������ �Ÿ�

	enum StageText
	{
		EASY = 0,
		NORMAL,
		HARD
	}

	private void Awake()
	{
		// ����
		// ��ũ�� �Ǵ� �������� �� value ���� �����ϴ� �迭 �޸� ���
		scrollPageValues = new float[transform.childCount];

		// ��ũ�� �Ǵ� ������ ������ �Ÿ�
		valueDistance = 1f / (scrollPageValues.Length - 1f);

		// ��ũ�� �Ǵ� �������� �� value ��ġ ���� [0 <= value <= 1]
		for (int i = 0; i < scrollPageValues.Length; ++i)
		{
			scrollPageValues[i] = valueDistance * i + 0.1f;
		}

		//// �ִ� �������� ��
		maxPage = transform.childCount;

		SetBtn();
    }

	private void Start()
	{
        // �Ÿ��� ���� 0~1�� pos ����
        distance = 1f / (SIZE - 1);
        for (int i = 0; i < SIZE; i++)
        {
            pos[i] = distance * i;
        }

        // ���� ������ �� ���������� �ر��� ���������� �� �� �ֵ��� ����
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

	// �ر��� �������� ���θ� �����ֱ� ���� �������� Image�� set 
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
