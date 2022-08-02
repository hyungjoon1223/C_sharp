// 220719 _ Ȳ���� _ �ϳ��� ž
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
	cout <<  movecount << " �� �̵��ؾ�" <<  endl;
	cout << endl;
	vector <MoveHis>::iterator iter;  
	for (iter = v.begin(); iter != v.end(); iter++) 
	{
		cout  << (iter->start) << "   " << (iter->dest) << endl;
	}
}

//// 220719 _ Ȳ���� _ ���þ� �귿
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
//int movecount;   //�� ������ Ƚ��
//class MoveHis
//{
//public:
//	int start;
//	int dest;   
//	MoveHis(int start, int dest) : start(start), dest(dest){}
//};
//
//vector<MoveHis> v;  //MoveHis�� �����س��� �����Ͱ� �ʿ�
//void MoveChunk(int start, int dest, int block) 
//{
//	int layover = ((start + 1) % 3) + 1;
//
//	if (layover == dest)
//	{
//		//start�� �ƴϵ� dest�� �ƴ� tower��ȣ�� ã�´� layover�� ������ ��� ��
//		layover = ((dest + 1) % 3) + 1;
//	}
//	if (block == 1)
//	{
//		// ���� 1�̸� start���� dest�� �ٷ� ������ �� �ִ�
//		v.push_back(MoveHis(start, dest));
//		movecount++;
//	}
//	else if (block <= 20)
//	{ // ���� N�� ��  1 start   2  layover  3 dest   n-1���� ������ ������ tower�� �ű� 
//		MoveChunk(start, layover, block - 1);
//		v.push_back(MoveHis(start, dest));    //n�� ���� �������� �̵�
//		movecount++;
//		MoveChunk(layover, dest, block - 1);
//	}
//	else
//	{
//		cout << "���ڰ� ������ ���� ��!" << endl;
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
//	vector <MoveHis>::iterator iter;  // movehis�� ��ȸ �� iter ����
//	for (iter = v.begin(); iter != v.end(); iter++) //His ���
//	{
//		cout << (iter->start) << ' ' << (iter->dest) << endl;
//	}
//	return 0;
//}