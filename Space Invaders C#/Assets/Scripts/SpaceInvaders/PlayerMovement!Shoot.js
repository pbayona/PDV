#pragma strict

private var movement: Vector3 = Vector3.zero;
private var controller: CharacterController;
private var playerSpeed: int = 10;



function Start() {
    controller = GetComponent(CharacterController);
}

function Update() {

    movement = Vector3(Input.GetAxis("Horizontal"), 0, 0);

    movement = transform.TransformDirection(movement);  //From local to global coordinates

    movement *= playerSpeed;

    controller.Move(movement * Time.deltaTime);
}
