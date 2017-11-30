#pragma once


//#pragma comment(lib, "XInput.lib") 
#pragma comment(lib, "XINPUT9_1_0.LIB") 

#include<Windows.h>
#include<Xinput.h>

class Controller
{
private:
	int number;
	bool connected;


public:
	Controller(int);
	Controller();

	void setNumber(int);

	XINPUT_STATE state;

	bool checkIfConnected();
	int getControllerNumber();

	bool checkInput(WORD);
	
	void updateThumbsticks();
	void updateTriggers();
	void updateButtons();

	//Input flags and float values
	bool inputA;
	bool inputB;
	bool inputX;
	bool inputY;

	bool inputStart;
	bool inputBack;

	bool inputLeftStick;
	bool inputRightStick;

	bool inputDpadRight;
	bool inputDpadLeft;
	bool inputDpadUp;
	bool inputDpadDown;

	bool inputRB;
	bool inputLB;

	float rightTrigger;
	float leftTrigger;
	
	float leftStickX;
	float leftStickY;

	float rightStickX;
	float rightStickY;

	static int controllerCount;
};