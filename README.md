![header](https://capsule-render.vercel.app/api?type=waving&color=gradient&customColorList=5&height=300&section=header&text=ANNIHILATION&fontSize=90&fontColor=2D2727)

## 목차

| [🌏 프로젝트 미리 보기 🌏](#프로젝트-미리-보기) |
| :---: |
| [🌌 기능별 코드 보기 🌌](#기능별-코드) |
| [✏ DEVELOP ✏](#develop) |
| [🪐 만든 사람들 🪐](#만든-사람들) |


<br>

* * *

<br>

## [🎮 YouTube](https://www.youtube.com/watch?v=XfUPwbHzX4o)
## [🤍 Team Notion](https://teamsparta.notion.site/08-814d16993a734e0b97c716e95ebf4c0e)

<br>

* * *

<br>

## 프로젝트 미리 보기

[⭐ 목차로 돌아가기 ⭐](#목차)

![슬라이드1](https://github.com/j-miiin/Annihilation/assets/62470991/556ba664-bf91-41d4-9713-e73ecbbc91b3)

<br>

![슬라이드2](https://github.com/j-miiin/Annihilation/assets/62470991/40621a92-53ac-4cf9-85bb-eedd05d8b573)

<br>

![슬라이드3](https://github.com/j-miiin/Annihilation/assets/62470991/a2c9257e-38fb-4eca-9760-32d2ebd4d152)

<br>

![슬라이드4](https://github.com/j-miiin/Annihilation/assets/62470991/95ff5b43-89b6-41eb-a80e-b8d3eca678e4)

<br>

![슬라이드5](https://github.com/j-miiin/Annihilation/assets/62470991/60a56c5d-0b83-44b9-b225-c945b58277c9)

<br>

![슬라이드6](https://github.com/j-miiin/Annihilation/assets/62470991/6c07bc0a-9a90-41e8-b60d-b76f5a9b7851)

<br>

![슬라이드7](https://github.com/j-miiin/Annihilation/assets/62470991/8a51c299-797d-405e-a010-efae0c68cd98)

[팀 에잇 Figma](https://www.figma.com/file/5wuzlMoXoiYIYIwdnDJm7J/%EC%97%90%EC%9E%87-%EB%B2%BD%EB%8F%8C%EA%B9%A8%EA%B8%B0?type=design&node-id=0-1&mode=design&t=b6nY7qWHbxzs2zJe-0)

<br>

![슬라이드8](https://github.com/j-miiin/Annihilation/assets/62470991/94b12255-4242-4cc1-ade2-c73a131c0654)

<br>

![슬라이드12](https://github.com/j-miiin/Annihilation/assets/62470991/5f814495-e0f7-447a-9aff-dd35b42613ac)

<br>

![슬라이드9](https://github.com/j-miiin/Annihilation/assets/62470991/6d251d43-bde8-4f07-b2c1-de0b0610a3e7)

<br>

![슬라이드10](https://github.com/j-miiin/Annihilation/assets/62470991/c3593695-7151-4248-a470-85c8b1e23b5d)

<br>

![슬라이드11](https://github.com/j-miiin/Annihilation/assets/62470991/46e0f417-d25f-43b2-a0db-32888422f848)

<br>

* * *

<br>

## 기능별 코드

[⭐ 목차로 돌아가기 ⭐](#목차)

- StartScene

| Script | 기능 |
| :---: | :---: |
| UIStartSceneCanvas | [StageScene Load](https://github.com/j-miiin/Annihilation/blob/ad71eb852afb0f7580b9fc358adc50ae26060710/Assets/Scripts/StartScene/UIStartSceneCanvas.cs#L33-L36) |
| | [배경음악 조절](https://github.com/j-miiin/Annihilation/blob/ad71eb852afb0f7580b9fc358adc50ae26060710/Assets/Scripts/StartScene/UIStartSceneCanvas.cs#L26C5-L31) |

- StageScene

| Script | 기능 |
| :---: | :---: |
| StageManager | [스테이지 선택 - StageManager](https://github.com/j-miiin/Annihilation/blob/ad71eb852afb0f7580b9fc358adc50ae26060710/Assets/Scripts/StageScene/StageManager.cs#L33-L37) |
| SwipeUI | [스테이지 선택](https://github.com/j-miiin/Annihilation/blob/ad71eb852afb0f7580b9fc358adc50ae26060710/Assets/Scripts/StageScene/SwipeUI.cs#L117-L121) |
| StageManager | [Paddle 스킨 선택](https://github.com/j-miiin/Annihilation/blob/ad71eb852afb0f7580b9fc358adc50ae26060710/Assets/Scripts/StageScene/StageManager.cs#L56-L59) |
| SwipeUI | [스테이지 스크롤 UI](https://github.com/j-miiin/Annihilation/blob/ad71eb852afb0f7580b9fc358adc50ae26060710/Assets/Scripts/StageScene/SwipeUI.cs#L68-L85) |
| UISelectPaddleSkinPanel | [Paddle 스킨 선택창 UI](https://github.com/j-miiin/Annihilation/blob/ad71eb852afb0f7580b9fc358adc50ae26060710/Assets/Scripts/StageScene/UI/UISelectPaddleSkinPanel.cs#L6-L38) |

- GameScene

| Script | 기능 |
| :---: | :---: |
| Stage | [Stage Map Load](https://github.com/j-miiin/Annihilation/blob/ad71eb852afb0f7580b9fc358adc50ae26060710/Assets/Scripts/GameScene/Stage.cs#L48) |
| | [Stage - 게임 종료 로직](https://github.com/j-miiin/Annihilation/blob/ad71eb852afb0f7580b9fc358adc50ae26060710/Assets/Scripts/GameScene/Stage.cs#L71-L97) |
| Paddle | [Paddle - 공 충돌 처리](https://github.com/j-miiin/Annihilation/blob/cea49f90867e2453c749d5b44d583b10a070e679/Assets/Scripts/GameScene/Paddle/Paddle.cs#L64-L98) |
| Ball | [Ball - 충돌 처리](https://github.com/j-miiin/Annihilation/blob/cea49f90867e2453c749d5b44d583b10a070e679/Assets/Scripts/GameScene/Ball/Ball.cs#L34-L89) |
| Paddle | [Paddle - 아이템 충돌 처리](https://github.com/j-miiin/Annihilation/blob/ad71eb852afb0f7580b9fc358adc50ae26060710/Assets/Scripts/GameScene/Paddle/Paddle.cs#L99-L143) |
| Meteor | [Meteor - 충돌 처리](https://github.com/j-miiin/Annihilation/blob/ad71eb852afb0f7580b9fc358adc50ae26060710/Assets/Scripts/GameScene/MeteorClass/Meteor.cs#L44-L84) |
| Ball | [Ball - Skin 변경](https://github.com/j-miiin/Annihilation/blob/c478972b67b21d1a6f654e42da1d63a61b3e8bcd/Assets/Scripts/GameScene/Ball/Ball.cs#L21-L28) |
| Paddle | [Paddle - Skin 변경](https://github.com/j-miiin/Annihilation/blob/c478972b67b21d1a6f654e42da1d63a61b3e8bcd/Assets/Scripts/GameScene/Paddle/Paddle.cs#L62) |
| PaddleHealth | [Paddle 체력 관리](https://github.com/j-miiin/Annihilation/blob/c478972b67b21d1a6f654e42da1d63a61b3e8bcd/Assets/Scripts/GameScene/Paddle/PaddleHealth.cs#L92-L97) |
|  | [Paddle 체력 관리 - UI](https://github.com/j-miiin/Annihilation/blob/c478972b67b21d1a6f654e42da1d63a61b3e8bcd/Assets/Scripts/GameScene/Paddle/PaddleHealth.cs#L36-L54) |
|  GameManager | [게임 종료 패널 - 홈, 재시작, 다음 스테이지 버튼](https://github.com/j-miiin/Annihilation/blob/ad71eb852afb0f7580b9fc358adc50ae26060710/Assets/Scripts/GameScene/GameManager.cs#L90-L112) |
| UIGameOverPanel| [게임 종료 패널 - UI](https://github.com/j-miiin/Annihilation/blob/ad71eb852afb0f7580b9fc358adc50ae26060710/Assets/Scripts/GameScene/UI/UIGameOverPanel.cs#L39-L50) |
| UIScoreAndTimePanel | [점수, 시간 UI 표시](https://github.com/j-miiin/Annihilation/blob/ad71eb852afb0f7580b9fc358adc50ae26060710/Assets/Scripts/GameScene/UI/UIScoreAndTimePanel.cs#L11-L19) |

<br>

* * *

<br>

## DEVELOP

[⭐ 목차로 돌아가기 ⭐](#목차)

- 벽돌이 무한히 내려오는 스테이지
- 다양한 게임 모드 (시간 제한 / 무한 / 미션)
- 레벨 에디터 - 플레이어가 커스텀할 수 있는 맵
- 오디오 매니저 통합 - 게임 내의 모든 사운드를 관리할 수 있는 오디오 매니저
- 랭킹 시스템 
- 배경 선택 - 플레이어 취향대로 선택
- 스토리 결과 씬 - 게임하면서 얻은 별 개수에 따라 달라지는 스토리
<br>

* * *

<br>

## 만든 사람들

[⭐ 목차로 돌아가기 ⭐](#목차)

<a href="https://github.com/j-miiin/Annihilation/graphs/contributors">
  <img src="https://contrib.rocks/image?repo=j-miiin/Annihilation" />
</a>

<br><br>
