// 220719 _ 황형준 _ 하노이 탑
#include <iostream>
#include <vector>
using namespace std;

int movecount;
class MoveHis
{
public:
	int start;
	int dest;
	MoveHis(int start, int dest) : start(start), dest(dest) {}
};
vector<MoveHis> v;
void MoveFunc(int start, int dest, int block)
{
	int layover = ((start + 1) % 3) + 1;

	if (layover == dest)
	{
		layover = ((dest + 1) % 3) + 1;
	}
	if (block == 1)
	{
		v.push_back(MoveHis(start, dest));
		movecount++;
	}
	else if (block <= 20)
	{ 
		MoveFunc(start, layover, block - 1);
		v.push_back(MoveHis(start, dest));  
		movecount++;
		MoveFunc(layover, dest, block - 1);
	}
}
int main()
{
	int N;
	cin >> N;

	movecount = 0;
	MoveFunc(1, 3, N);
	cout <<  movecount << " 번 이동해쑴" <<  endl;
	cout << endl;
	vector <MoveHis>::iterator iter;  
	for (iter = v.begin(); iter != v.end(); iter++) 
	{
		cout  << (iter->start) << "   " << (iter->dest) << endl;
	}
}

//// 220719 _ 황형준 _ 러시안 룰렛
//#include <cstdio>
//#include <iostream>
//#include <vector>
//using namespace std;
//
//int main()
//{
//
//    int n = 0;
//    int d = 0;
//    cin >> n;
//    cin >> d;
//    int count = d;
//    int end = 0;
//    int elem = 0;
//    vector<int> alive;
//    vector<int> dead;
//    for (int i = 1; i <= n; ++i)
//    {
//        alive.push_back(i);
//    }
//
//    while (true)
//    {
//        if (count > alive.size())
//        {
//            count = count - alive.size();
//            if (count > alive.size())
//                count = count - alive.size();
//        }
//        if (count == 0)
//        {
//            elem = alive[0];
//        }
//        else
//        {
//            elem = alive[count - 1];
//        }
//        dead.push_back(elem);
//
//        alive.erase(remove(alive.begin(), alive.end(), elem));
//        if (alive.size() == 1)
//        {
//            elem = alive[0];
//            dead.push_back(elem);
//            break;
//        }
//        count += d - 1;
//    }
//    vector<int>::iterator iter;
//    for (iter = dead.begin(); iter != dead.end(); ++iter)
//    {
//        cout << *iter << "   ";
//    }
//    cout << endl;
//}


//#include <iostream>
//#include <vector>
//using namespace std;
//
//int movecount;   //총 움직일 횟수
//class MoveHis
//{
//public:
//	int start;
//	int dest;   
//	MoveHis(int start, int dest) : start(start), dest(dest){}
//};
//
//vector<MoveHis> v;  //MoveHis를 저장해놓을 데이터가 필요
//void MoveChunk(int start, int dest, int block) 
//{
//	int layover = ((start + 1) % 3) + 1;
//
//	if (layover == dest)
//	{
//		//start도 아니도 dest도 아닌 tower번호를 찾는다 layover는 경유지 라는 뜻
//		layover = ((dest + 1) % 3) + 1;
//	}
//	if (block == 1)
//	{
//		// 블럭이 1이면 start에서 dest로 바로 움직일 수 있다
//		v.push_back(MoveHis(start, dest));
//		movecount++;
//	}
//	else if (block <= 20)
//	{ // 블럭이 N일 때  1 start   2  layover  3 dest   n-1개의 블럭들을 경유지 tower로 옮김 
//		MoveChunk(start, layover, block - 1);
//		v.push_back(MoveHis(start, dest));    //n번 블럭을 목적지로 이동
//		movecount++;
//		MoveChunk(layover, dest, block - 1);
//	}
//	else
//	{
//		cout << "숫자가 범위를 벗어 남!" << endl;
//		return;
//	}
//}
//int main()
//{
//	int N;
//
//	cin >> N;
//
//	movecount = 0;
//	MoveChunk(1, 3, N);
//	cout << movecount << endl;
//	vector <MoveHis>::iterator iter;  // movehis를 순회 할 iter 선언
//	for (iter = v.begin(); iter != v.end(); iter++) //His 출력
//	{
//		cout << (iter->start) << ' ' << (iter->dest) << endl;
//	}
//	return 0;
//}