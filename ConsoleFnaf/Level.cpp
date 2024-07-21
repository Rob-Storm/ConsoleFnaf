#include "Level.h"
#include <fstream>

Level::Level()
{
	std::ifstream t("map.txt");
	std::string str((std::istreambuf_iterator<char>(t)), std::istreambuf_iterator<char>());
	map = str;
}

void Level::DisplayMap()
{
	std::cout << map << std::endl;
}
