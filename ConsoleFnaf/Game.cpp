#include "Game.h"
#include <iostream>
#include <string>

Game::Game()
{
	IsRunning = true;
	Run();
}

Game::~Game()
{

}

void Game::Run()
{
	while (IsRunning)
	{
		Update();
	}
}

void Game::Update()
{
	std::string input;

	std::cout << "What will you do?" << std::endl;
	std::cout << "1. Check Camera" << std::endl;
	std::cout << "2. Check Left Door" << std::endl;
	std::cout << "3. Check Right Door" << std::endl;
	std::cout << "4. Do nothing (skip turn)" << std::endl;
	std::cout << "-------------------------" << std::endl;

	std::cin >> input;

	switch(std::stoi(input))
	{
	case 1:
		level.DisplayMap();
		break;
	case 2:
		break;
	case 3:
		break;
	case 4:
		break;
	default:
		return;
	}
}
