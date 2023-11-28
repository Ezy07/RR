using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject Cam;
    public CharacterController SelectPlayer; // ������ ĳ���� ��Ʈ�ѷ�
    public float Speed;  // �̵��ӵ�
    private float Gravity; // �߷�
    private Vector3 MoveDir; // ĳ������ �����̴� ����.
    private CharacterController characterController;

    public GameObject weapon; //����

    // Start is called before the first frame update
    void Start()
    {
        // �⺻��
        Speed = 20.0f;
        Gravity = 10.0f;
        MoveDir = Vector3.zero;
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; //���콺 Ŀ�� ���

        //���� Ȱ��ȭ
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

        // ĳ���Ͱ� �ٴڿ� �پ� �ִ� ��츸 �۵��մϴ�.
        if (SelectPlayer.isGrounded)
        {
            // Ű���忡 ���� X, Z �� �̵������� ���� �����մϴ�.
            MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            // ������Ʈ�� �ٶ󺸴� �չ������� �̵������� ������ �����մϴ�.
            MoveDir = SelectPlayer.transform.TransformDirection(MoveDir);
            // �ӵ��� ���ؼ� �����մϴ�.
            MoveDir *= Speed;
        }
        else
        {
            // �߷��� ������ �޾� �Ʒ������� �ϰ��մϴ�.
            // �� �� �ٴڿ� ���� ������ -y���� ��� �������� ��ġ �߷°��ӵ� ���� ��ó�� �ۿ��մϴ�.
            MoveDir.y -= Gravity * Time.deltaTime;
        }
        // ���� ĳ������ �̵��� ���⼭ ����մϴ�.
        SelectPlayer.Move(MoveDir * Time.deltaTime);
    }

    void SetWeaponActive(bool isActive)
    {
        weapon.SetActive(isActive);
    }
}