#include "Wrapper.h"
#include "Controller.h"

//Scott Cooper 100580683
//Lucas Harvey 100585553
//Kenneth Ho 100583602

//This is the plugin for controller input. It uses Xinput.

Controller *controllers;

/* Just main function for testing before exporting...
int main()
{

	Controller controller(0);

	bool connected;

	connected = controller.checkIfConnected();

	if (connected) cout << "Connected" << endl;
	else cout << "Not connected" << endl;



	while (1)
	{
		if(controller.checkIfConnected())
		{

		controller.updateThumbsticks();
		controller.updateButtons();
		controller.updateTriggers();

		if (controller.checkInput(XINPUT_GAMEPAD_LEFT_THUMB))
			cout << "A" << endl;

		}
	}
}*/

void createControllers(int amount)
{
	controllers = new Controller[amount];

	Controller::controllerCount = amount;

	for (unsigned int i = 0; i < amount; i++)
	{
		controllers[i].setNumber(i);
		controllers[i].checkIfConnected();

	}
}

//Make sure the controller is still conected, and update inputs
void updateControllers()
{
	//Failsafe from crashing
	if (!controllers) return;

	for (unsigned int i = 0; i < Controller::controllerCount; i++)
	{
		
		if (controllers[i].checkIfConnected())
		{
			controllers[i].updateThumbsticks();
			controllers[i].updateButtons();
			controllers[i].updateTriggers();
		}
	}
}

bool getButton(int player, int button)
{
	if (!controllers) return false;

	bool returnVal;

	switch (button)
	{
	case 0:
		returnVal =  controllers[player].inputA;
		break;
	case 1:
		returnVal = controllers[player].inputB;
		break;
	case 2:
		returnVal = controllers[player].inputY;
		break;
	case 3:
		returnVal = controllers[player].inputX;
		break;
	case 4:
		returnVal = controllers[player].inputRB;
		break;
	case 5:
		returnVal = controllers[player].inputLB;
		break;
	case 6:
		returnVal = controllers[player].inputStart;
		break;
	case 7:
		returnVal = controllers[player].inputBack;
		break;
	case 8:
		returnVal = controllers[player].inputRightStick;
		break;
	case 9:
		returnVal = controllers[player].inputLeftStick;
		break;
	default: returnVal = false;
		break;
	}
	return returnVal;
}

bool getDpad(int player, int button)
{
	if (!controllers) return 0.0f;

	float returnVal;

	switch (button)
	{
	case 0:
		returnVal =  controllers[player].inputDpadUp;
		break;
	case 1:
		returnVal =  controllers[player].inputDpadDown;
		break;
	case 2:
		returnVal = controllers[player].inputDpadRight;
		break;
	case 3:
		returnVal = controllers[player].inputDpadLeft;
		break;	
	default: returnVal = false;
		break;
	}

	return returnVal;

}

float getThumbstick(int player, int axis)
{
	if (!controllers) return 0.0f;

	float returnVal;

	switch (axis)
	{
	case 0:
		returnVal =  controllers[player].leftStickX;
		break;
	case 1:
		returnVal = controllers[player].leftStickY;
		break;
	case 2:
		returnVal = controllers[player].rightStickX;
		break;
	case 3:
		returnVal = controllers[player].rightStickY;
		break;
	default: returnVal = 0.0f;
		break;
	}

	return returnVal;
}

float getTrigger(int player, int trigger)
{
	if (!controllers) return 0.0f;

	float returnVal = 0.0f;

	if (trigger == 0)
		returnVal = controllers[player].leftTrigger;
	else if (trigger == 1) returnVal = controllers[player].rightTrigger;


	return returnVal;
}

void removeControllers()
{
	delete[] controllers;
	controllers = NULL;
}