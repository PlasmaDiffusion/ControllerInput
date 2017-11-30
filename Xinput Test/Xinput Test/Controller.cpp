#include "Controller.h"

Controller::Controller(int playerNumber)
{
	number = playerNumber;
}

int Controller::controllerCount = 0;

Controller::Controller()
{
	number = 0;

	
	inputA = false;
	inputB = false;
	inputX = false;
	inputY = false;

	inputStart = false;
	inputBack = false;

	inputLeftStick = false;
	inputRightStick = false;

	inputDpadRight = false;
	inputDpadLeft = false;
	inputDpadUp = false;
	inputDpadDown = false;

	inputRB = false;
	inputLB = false;

	rightTrigger = 0.0f;
	leftTrigger = 0.0f;

	leftStickX = 0.0f;
	leftStickY = 0.0f;

	rightStickX = 0.0f;
	rightStickY = 0.0f;

	controllerCount++;
}

void Controller::setNumber(int value)
{
	number = value;
}

//Check if connected and also update the state
bool Controller::checkIfConnected()
{
	
	ZeroMemory(&state, sizeof(XINPUT_STATE));

	DWORD id = number;
	if (XInputGetState(id, &state) == ERROR_SUCCESS)
	{
		return true;
	}
	else
		return false;
}


int Controller::getControllerNumber()
{
	return number;
}

bool Controller::checkInput(WORD input)
{
//wButtons is a bitmask
return  ((state.Gamepad.wButtons & input) !=0);
}

void Controller::updateThumbsticks()
{
	leftStickX = (float)state.Gamepad.sThumbLX / 32767;
	leftStickY = (float)state.Gamepad.sThumbLY / 32767;

	rightStickX = (float)state.Gamepad.sThumbRX / 32767;
	rightStickY = (float)state.Gamepad.sThumbRY / 32767;
}

void Controller::updateTriggers()
{
	rightTrigger = (float)state.Gamepad.bRightTrigger / 255;
	leftTrigger = (float)state.Gamepad.bLeftTrigger / 255;
}

void Controller::updateButtons()
{
	inputA = checkInput(XINPUT_GAMEPAD_A);
	inputB = checkInput(XINPUT_GAMEPAD_B);
	inputY = checkInput(XINPUT_GAMEPAD_Y);
	inputX = checkInput(XINPUT_GAMEPAD_X);
	state.dwPacketNumber;
	inputStart = checkInput(XINPUT_GAMEPAD_START);
	inputBack = checkInput(XINPUT_GAMEPAD_BACK);

	inputLeftStick = checkInput(XINPUT_GAMEPAD_LEFT_THUMB);
	inputRightStick = checkInput(XINPUT_GAMEPAD_RIGHT_THUMB);

	inputDpadDown = checkInput(XINPUT_GAMEPAD_DPAD_DOWN);
	inputDpadUp = checkInput(XINPUT_GAMEPAD_DPAD_UP);
	inputDpadRight = checkInput(XINPUT_GAMEPAD_DPAD_RIGHT);
	inputDpadLeft = checkInput(XINPUT_GAMEPAD_DPAD_LEFT);

	inputRB = checkInput(XINPUT_GAMEPAD_START);
	inputLB = checkInput(XINPUT_GAMEPAD_START);
}