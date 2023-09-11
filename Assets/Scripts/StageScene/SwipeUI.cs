using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SwipeUI : MonoBehaviour
{
    // ��� �������� ����� �̹���
    public const string STAGE2_LOCKED_THUMB_IMAGE = "Image/MapImage/NStageMap_locked";
    public const string STAGE3_LOCKED_THUMB_IMAGE = "Image/MapImage/HStageMap_locked";

    [SerializeField]
    private Scrollbar scrollBar;                // Scrollbar�� ��ġ�� �������� ���� ������ üũ
    [SerializeField]
    private float swipeTime = 0.2f;             // StageImage�� Swipe �Ǵ� �ð�
    [SerializeField]
    private float swipeDistance = 30.0f;        // StageImage�� Swipe �Ǳ� ���� ���������ϴ� �ּ� �Ÿ�

    [SerializeField] private GameObject _stage1ThumbImage;
    [SerializeField] private GameObject _stage2ThumbImage;
    [SerializeField] private GameObject _stage3ThumbImage;

    [SerializeField] private GameObject _star1EmptyImage;
    [SerializeField] private GameObject _star2EmptyImage;
    [SerializeField] private GameObject _star3EmptyImage;
    [SerializeField] private GameObject _star1FilledImage;
    [SerializeField] private GameObject _star2FilledImage;
    [SerializeField] private GameObject _star3FilledImage;

    [SerializeField] private TMP_Text _stageLevelText;

    public float[] scrollPageValues;           // �� �������� ��ġ �� [0.0 - 1.0]
    private float valueDistance = 0;            // �� ������ ������ �Ÿ�
    private int currentPage = 0;                // ���� ������
    private int maxPage = 0;                    // �ִ� ������
    private float startTouchX;                  // ��ġ ���� ��ġ
    private float endTouchX;                    // ��ġ ���� ��ġ
    private bool isSwipeMode = false;           // ���� Swipe�� �ǰ� �ִ��� üũ
    private int lockedStage;

	enum StageText
	{
		EASY = 0,
		NORMAL,
		HARD
	}

	private void Awake()
	{
		// ��ũ�� �Ǵ� �������� �� value ���� �����ϴ� �迭 �޸� ���
        scrollPageValues = new float[transform.childCount];

        // ��ũ�� �Ǵ� ������ ������ �Ÿ�
        valueDistance = 1f / (scrollPageValues.Length - 1f);

        // ��ũ�� �Ǵ� �������� �� value ��ġ ���� [0 <= value <= 1]
        for (int i = 0; i < scrollPageValues.Length; ++i)
        {
            scrollPageValues[i] = valueDistance * i;
        }

        // �ִ� �������� ��
        maxPage = transform.childCount;

        SetBtn();
    }

	private void Start()
	{
        // ���� ������ �� ���������� �ر��� ���������� ���� ���������� �� �� �ֵ��� ����
        // ù �����̶�� 1���������� ���� ����
        lockedStage = StageManager.Instance.GetLockedStage();

        SetScrollBarValue(lockedStage - 1); 
        SetStageThumbImage();
    }

	private void Update()
	{
        UpdateInput();

        // �Ʒ��� ��ġ�� �������� ���� �ؽ�Ʈ ����
        UpdateStageLevelText();
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
        if (index > scrollPageValues.Length) index = scrollPageValues.Length - 1;
        scrollBar.value = scrollPageValues[index];
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

    private void UpdateInput()
    {
        // ���� Swipe�� �������̸� ��ġ �Ұ���
        if (isSwipeMode == true) return;

        #if UNITY_EDITOR
        // ���콺 ���� ��ư�� ������ �� 1ȸ
        if (Input.GetMouseButtonDown(0))
        {
            // ��ġ ���� ���� (Swipe ���� ����)
            startTouchX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // ��ġ ���� ���� (Swipe ���� ����)
            endTouchX = Input.mousePosition.x;

            UpdateSwipe();
        }
        #endif

        #if UNITY_ANDROID
        if ( Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // ��ġ ���� ���� (Swipe ���� ����)
                startTouchX = touch.position.x;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                // ��ġ ���� ���� (Swipe ���� ����)
                endTouchX = touch.position.x;

                UpdateSwipe();
            }
        }
        #endif

	}

    private void UpdateSwipe()
    {
        // �ʹ� ���� �Ÿ��� �������� ���� Swipe X
        if (Mathf.Abs(startTouchX-endTouchX) < swipeDistance)
        {
            // ���� Satge�̹����� Swipe�ؼ� ���ư���
            StartCoroutine(OnSwipeOneStep(currentPage));
            return;
        }

        // Swipe ����
        bool isLeft = startTouchX < endTouchX ? true : false;

        // �̵� ������ ������ ��
        if (isLeft == true)
        {
            // ���� ���������� ���� ���̸� ����
            if (currentPage == 0) return;

            // �������� �̵��� ���� ���� �������� 1 ����
            currentPage --;
        }
        // �̵� ������ �������� ��
        else
        {
            // ���� ���������� ������ ���̸� ����
            if (currentPage == maxPage - 1) return;

            // ���������� �̵��� ���� ���� �������� 1 ����
            currentPage ++;
        }

        // currentIndex��° �������� Swipe�ؼ� �̵�
        StartCoroutine(OnSwipeOneStep(currentPage));
    }

    private IEnumerator OnSwipeOneStep(int index)
    {
        float start = scrollBar.value;
        float current = 0;
        float percent = 0;

        isSwipeMode = true;

        while ( percent < 1 )
        {
            current += Time.deltaTime;
            percent = current / swipeTime;

            scrollBar.value = Mathf.Lerp(start, scrollPageValues[index], percent);

            yield return null;
        }

        isSwipeMode = false;
    }

    private void UpdateStageLevelText()
    {
        // �������� ���� �ؽ�Ʈ ���
        for (int i = 0; i < scrollPageValues.Length; ++ i)
        {
            //�������� ������ �Ѿ�� ���� �ؽ�Ʈ�� �ٲٵ���
            if (scrollBar.value < scrollPageValues[i] + (valueDistance / 2) && scrollBar.value > scrollPageValues[i] - (valueDistance / 2))
            {
                _stageLevelText.text = ((StageText)i).ToString(); //stageText[i];
                if (i + 1 > lockedStage)
                {
                    _stageLevelText.color = Color.grey;
                    _star1FilledImage.SetActive(false);
                    _star2FilledImage.SetActive(false);
                    _star3FilledImage.SetActive(false);
                }
                else
                {
                    _stageLevelText.color = Color.white;
                    int star = StageManager.Instance.GetEasyStar();
                    _star1FilledImage.SetActive((star >= 1));
                    _star2FilledImage.SetActive((star >= 2));
                    _star3FilledImage.SetActive((star >= 3));
                }
            }
        }
    }

    public void StartGame()
    {
        StageManager.Instance.StartGame(currentPage + 1);
    }
}
