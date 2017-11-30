#include "Wrapper.h"
#include "Controller.h"


Controller *controllers;

/*
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

	for (unsigned int i = 0; i < amount; i++)
	{
		controllers[i].setNumber(i);
		controllers[i].checkIfConnected();
	}
}

//Make sure the controller is still conected, and update inputs
void updateControllers()
{
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
	switch (button)
	{
	case 0:
		return  controllers[player].inputA;
		break;
	case 1:
		return  controllers[player].inputB;
		break;
	case 2:
		return  controllers[player].inputY;
		break;
	case 3:
		return  controllers[player].inputX;
		break;
	case 4:
		return  controllers[player].inputRB;
		break;
	case 5:
		return  controllers[player].inputLB;
		break;
	case 6:
		return  controllers[player].inputStart;
		break;
	case 7:
		return  controllers[player].inputBack;
		break;
	case 8:
		return  controllers[player].inputRightStick;
		break;
	case 9:
		return  controllers[player].inputLeftStick;
		break;
	default: return false;
	}

}

bool getDpad(int player, int button)
{
	switch (button)
	{
	case 0:
		return  controllers[player].inputDpadUp;
		break;
	case 1:
		return  controllers[player].inputDpadDown;
		break;
	case 2:
		return  controllers[player].inputDpadRight;
		break;
	case 3:
		return  controllers[player].inputDpadLeft;
		break;	
	default: return false;
	}


}

float getThumbstick(int player, int axis)
{
	switch (axis)
	{
	case 0:
		return  controllers[player].leftStickX;
		break;
	case 1:
		return  controllers[player].leftStickY;
		break;
	case 2:
		return  controllers[player].rightStickX;
		break;
	case 3:
		return  controllers[player].rightStickY;
		break;
	default: return 0.0f;
	}
}

float getTrigger(int player, int trigger)
{
	if (trigger == 0)
		return controllers[player].leftTrigger;
	else if (trigger == 1) return controllers[player].rightTrigger;
	else return 0.0f;
}

void removeControllers()
{
	delete[] controllers;
}