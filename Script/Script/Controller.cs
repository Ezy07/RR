using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject Cam;
    public CharacterController SelectPlayer; // 제어할 캐릭터 컨트롤러
    public float Speed;  // 이동속도
    private float Gravity; // 중력
    private Vector3 MoveDir; // 캐릭터의 움직이는 방향.
    private CharacterController characterController;

    public GameObject weapon; //무기

    // Start is called before the first frame update
    void Start()
    {
        // 기본값
        Speed = 20.0f;
        Gravity = 10.0f;
        MoveDir = Vector3.zero;
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; //마우스 커서 잠금

        //무기 활성화
        SetWeaponActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (SelectPlayer == null) return;

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            var offset = Cam.transform.forward;
            offset.y = 0;
            transform.LookAt(SelectPlayer.transform.position + offset);
        }
        if (SelectPlayer == null) return;

        // 캐릭터가 바닥에 붙어 있는 경우만 작동합니다.
        if (SelectPlayer.isGrounded)
        {
            // 키보드에 따른 X, Z 축 이동방향을 새로 결정합니다.
            MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            // 오브젝트가 바라보는 앞방향으로 이동방향을 돌려서 조정합니다.
            MoveDir = SelectPlayer.transform.TransformDirection(MoveDir);
            // 속도를 곱해서 적용합니다.
            MoveDir *= Speed;
        }
        else
        {
            // 중력의 영향을 받아 아래쪽으로 하강합니다.
            // 이 때 바닥에 닿을 떄까지 -y값이 계속 더해져서 마치 중력가속돠 붙은 것처럼 작용합니다.
            MoveDir.y -= Gravity * Time.deltaTime;
        }
        // 실제 캐릭터의 이동은 여기서 담당합니다.
        SelectPlayer.Move(MoveDir * Time.deltaTime);
    }

    void SetWeaponActive(bool isActive)
    {
        weapon.SetActive(isActive);
    }
}