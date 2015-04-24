// TestCpp.cpp : コンソール アプリケーションのエントリ ポイントを定義します。
//

#include "stdafx.h"
#include <stdio.h>

int _tmain(int argc, _TCHAR* argv [])
{
	int i = 1;
	for (int j = 0; j <= 30; j++){
		printf("%s\n", i);
		i *= 2;
	}
	return 0;
}

