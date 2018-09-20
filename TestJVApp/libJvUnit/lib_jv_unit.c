
#include "libJvUnit.h"

int Colc(int*);

int Colc(int *a)
{
	return a + 10;
}

int main(int a)
{
	Colc(&a);

	return 1;
}

