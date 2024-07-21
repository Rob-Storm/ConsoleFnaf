#pragma once
#include "Level.h"

class Game
{
public:
	Game();
	~Game();
	void Run();
	bool IsRunning;
	Level level;

private:
	void Update();
};