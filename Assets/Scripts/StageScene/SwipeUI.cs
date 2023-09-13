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

    [SerializeField] private GameObject _stage1ThumbImage;
    [SerializeField] private GameObject _stage2ThumbImage;
    [SerializeField] private GameObject _stage3ThumbImage;

	private int lockedStage;
    private int selectedStage;

    public Scrollbar scrollbar;

    const int SIZE = 3;                         // �̹��� ����
    float[] pos = new float[SIZE];              // ������
    float distance;                             // ������ ������ �Ÿ�
    float targetPos;                            // ��ǥ ������
    bool isDrag;                                // �巡�������� �Ǻ�

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
        // �Ÿ��� ���� 0~1�� pos ����
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
        Debug.Log("selectedStage" + selectedStage);
        StageManager.Instance.StartGame(selectedStage);
    }
}
