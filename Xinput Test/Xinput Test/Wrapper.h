#pragma once
//Scott Cooper 100580683
//Lucas Harvey 100585553
//Kenneth Ho 100583602

extern "C"
{

_declspec(dllexport)  void createControllers(int amount);
_declspec(dllexport)  void updateControllers();
_declspec(dllexport)  bool getButton(int player, int button);
_declspec(dllexport)  bool getDpad(int player, int button);
_declspec(dllexport)  float getThumbstick(int player, int axis);
_declspec(dllexport)  float getTrigger(int player, int trigger);
_declspec(dllexport)  void removeControllers();

}